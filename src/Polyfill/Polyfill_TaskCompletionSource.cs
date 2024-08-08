// <auto-generated />
#pragma warning disable

#if !NET5_0_OR_GREATER

using System;
using System.Threading;
using System.Threading.Tasks;
using Link = System.ComponentModel.DescriptionAttribute;

static partial class Polyfill
{
    /// <summary>
    /// Transitions the underlying <see cref="Task{TResult}"/> into the <see cref="TaskStatus.Canceled"/> state
    /// using the specified token.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token with which to cancel the <see cref="Task{TResult}"/>.</param>
    /// <exception cref="InvalidOperationException">
    /// The underlying <see cref="Task{TResult}"/> is already in one of the three final states:
    /// <see cref="TaskStatus.RanToCompletion"/>,
    /// <see cref="TaskStatus.Faulted"/>, or
    /// <see cref="TaskStatus.Canceled"/>.
    /// </exception>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskcompletionsource-1.setcanceled#system-threading-tasks-taskcompletionsource-1-setcanceled(system-threading-cancellationtoken)")]
    public static void SetCanceled<T>(
        this TaskCompletionSource<T> target,
        CancellationToken cancellationToken)
    {
        if (target.TrySetCanceled(cancellationToken))
        {
            return;
        }

        throw new InvalidOperationException("An attempt was made to transition a task to a final state when it had already completed.");
    }
}
#endif