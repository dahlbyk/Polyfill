﻿#pragma warning disable IL2026

[TestFixture]
public class SanityChecks
{
    [Test]
    public void NoPublicTypes()
    {
        var visibleTypes = typeof(SanityChecks).Assembly
            .GetExportedTypes()
            .Where(type => type.Namespace?.StartsWith("System") == true);
#if PolyPublic
#if !NET7_0_OR_GREATER
        Assert.That(visibleTypes, Is.Not.Empty);
#endif
#else
        Assert.That(visibleTypes, Is.Empty);
#endif
    }
#if DEBUG
    [Test]
    public void CodeChecks()
    {
        var dir = Path.Combine(SolutionDirectoryFinder.Find(), "Polyfill");
        var errors = new List<string>();
        foreach (var file in Directory.EnumerateFiles(dir, "*.cs"))
        {
            var content = File.ReadAllText(file);
            var requiredText = new[]
            {
                "// <auto-generated />",
                "#pragma warning disable"
            };
            foreach (var required in requiredText)
            {
                if (!content.Contains(required))
                {
                    errors.Add($"{file} must contain '{required}'");
                }
            }
        }

        if (errors.Count > 0)
        {
            throw new(string.Join("\n", errors));
        }
    }
#endif
    [Test]
    public void ReflectionChecks()
    {
        var errors = new List<string>();
        foreach (var type in typeof(SanityChecks).Assembly.GetTypes())
        {
            if (type.Namespace != null && !type.Namespace.StartsWith("System"))
            {
                continue;
            }


            if (type.IsNested)
            {
                continue;
            }
            if (type.GetCustomAttribute(typeof(TestFixtureAttribute)) != null)
            {
                continue;
            }

            var name = type.Name;
            if (name.EndsWith("Usage") ||
                name.Contains("<") ||
                name.Contains("Sample") ||
                name == "SolutionDirectoryFinder" ||
                name == "IsReadOnlyAttribute" ||
                name == "IsByRefLikeAttribute" ||
                name == "NullableAttribute" ||
                name == "NullableContextAttribute" ||
                name == "ScopedRefAttribute" ||
                name == "RefSafetyRulesAttribute" ||
                name == "Guard")
            {
                continue;
            }

            if (type is {IsInterface: false, IsEnum: false})
            {
                try
                {

                    if (type.GetCustomAttribute(typeof(ExcludeFromCodeCoverageAttribute)) == null)
                    {
                        errors.Add($"{name} must have ExcludeFromCodeCoverageAttribute");
                    }

                    if (type.GetCustomAttribute(typeof(DebuggerNonUserCodeAttribute)) == null)
                    {
                        errors.Add($"{name} must have DebuggerNonUserCode");
                    }
                }
                catch (Exception e)
                {
                    throw new($"Failed to get attributes from {name}", e);
                }
            }
        }

        if (errors.Count > 0)
        {
            throw new(string.Join("\n", errors));
        }
    }
}
