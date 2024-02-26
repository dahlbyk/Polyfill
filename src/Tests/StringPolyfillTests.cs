// ReSharper disable PartialTypeWithSinglePart

[TestFixture]
partial class StringPolyfillTest
{
    [Test]
    public void Join()
    {
        Assert.AreEqual("bac", StringPolyfill.Join('a', ["b", "c"]));
        Assert.AreEqual("bac", StringPolyfill.Join('a', new object[]
        {
            "b",
            "c"
        }));
    }
#if FeatureMemory
    [Test]
    public void CreateAction()
    {
        char[] buffer =
        [
            'a',
            'e',
            'i',
            'o',
            'u'
        ];
        var result = StringPolyfill.Create(
            buffer.Length,
            buffer,
            (c, b) =>
            {
                for (var i = 0; i < c.Length; i++)
                {
                    c[i] = b[i];
                }
            });
        Assert.AreEqual("aeiou", result);
    }
    [Test]
    public void Create()
    {
        var _parameterCount = 10;
        Span<char> paramNameBuffer = stackalloc char[8];
        var paramName = StringPolyfill.Create(null, paramNameBuffer, $"@Param{_parameterCount}");
        Assert.AreEqual("@Param10", paramName);
    }
#endif
}