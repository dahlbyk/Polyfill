// <auto-generated />
#pragma warning disable

#if !NET5_0_OR_GREATER

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Link = System.ComponentModel.DescriptionAttribute;

static partial class Polyfill
{
    /// <summary>
    /// Instructs the Process component to wait for the associated process to exit, or
    /// for the <paramref name="cancellationToken"/> to be canceled.
    /// </summary>
    /// <remarks>
    /// Calling this method will set <see cref="EnableRaisingEvents"/> to <see langword="true" />.
    /// </remarks>
    /// <returns>
    /// A task that will complete when the process has exited, cancellation has been requested,
    /// or an error occurs.
    /// </returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.waitforexitasync")]
    public static async Task WaitForExitAsync(this Process target, CancellationToken cancellationToken = default)
    {
        // Because the process has already started by the time this method is called,
        // we're in a race against the process to set up our exit handlers before the process
        // exits. As a result, there are several different flows that must be handled:
        //
        // CASE 1: WE ENABLE EVENTS
        // This is the "happy path". In this case we enable events.
        //
        // CASE 1.1: PROCESS EXITS OR IS CANCELED AFTER REGISTERING HANDLER
        // This case continues the "happy path". The process exits or waiting is canceled after
        // registering the handler and no special cases are needed.
        //
        // CASE 1.2: PROCESS EXITS BEFORE REGISTERING HANDLER
        // It's possible that the process can exit after we enable events but before we register
        // the handler. In that case we must check for exit after registering the handler.
        //
        //
        // CASE 2: PROCESS EXITS BEFORE ENABLING EVENTS
        // The process may exit before we attempt to enable events. In that case EnableRaisingEvents
        // will throw an exception like this:
        //     System.InvalidOperationException : Cannot process request because the process (42) has exited.
        // In this case we catch the InvalidOperationException. If the process has exited, our work
        // is done and we return. If for any reason (now or in the future) enabling events fails
        // and the process has not exited, bubble the exception up to the user.
        //
        //
        // CASE 3: USER ALREADY ENABLED EVENTS
        // In this case the user has already enabled raising events. Re-enabling events is a no-op
        // as the value hasn't changed. However, no-op also means that if the process has already
        // exited, EnableRaisingEvents won't throw an exception.
        //
        // CASE 3.1: PROCESS EXITS OR IS CANCELED AFTER REGISTERING HANDLER
        // (See CASE 1.1)
        //
        // CASE 3.2: PROCESS EXITS BEFORE REGISTERING HANDLER
        // (See CASE 1.2)

        if (!target.HasExited)
        {
            // Early out for cancellation before doing more expensive work
            cancellationToken.ThrowIfCancellationRequested();
        }

        try
        {
            // CASE 1: We enable events
            // CASE 2: Process exits before enabling events (and throws an exception)
            // CASE 3: User already enabled events (no-op)
            target.EnableRaisingEvents = true;
        }
        catch (InvalidOperationException)
        {
            // CASE 2: If the process has exited, our work is done, otherwise bubble the
            // exception up to the user
            if (target.HasExited)
            {
                return;
            }

            throw;
        }

        var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

        EventHandler handler = (_, _) => tcs.TrySetResult(null);
        target.Exited += handler;

        try
        {
            if (target.HasExited)
            {
                // CASE 1.2 & CASE 3.2: Handle race where the process exits before registering the handler
            }
            else
            {
                // CASE 1.1 & CASE 3.1: Process exits or is canceled here
                using (cancellationToken.UnsafeRegister(static (s, cancellationToken) => ((TaskCompletionSource<object>)s!).TrySetCanceled(cancellationToken), tcs))
                {
                    await tcs.Task.ConfigureAwait(false);
                }
            }
        }
        finally
        {
            target.Exited -= handler;
        }
    }
}

#endif
