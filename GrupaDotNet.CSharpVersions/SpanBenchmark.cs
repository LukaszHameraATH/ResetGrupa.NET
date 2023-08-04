using BenchmarkDotNet.Attributes;

namespace GrupaDotNet.CSharpVersions;

public class SpanBenchmark
{
    [Params(10_000)]
    public int Lenght { get; set; }
    
    [Benchmark]
    public void SubString()
    {
        var text = GenerateText(Lenght);
        for (int i = 0; i < text.Length; i++)
        {
            var test = text.Substring(0, i);
        }
    }

    [Benchmark(Baseline = true)]
    public void Span()
    {
        var text = GenerateText(Lenght);
        ReadOnlySpan<char> textSpan = text;
        for (int i = 0; i < text.Length; i++)
        {
            var test = textSpan.Slice(0, i);
        }
    }
    
    private string GenerateText(int lenght)
    {
        return string.Join("", Enumerable.Range(0, lenght).Select(x => '0'));
    }
}