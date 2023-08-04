using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace GrupaDotNet.CSharpVersions;

public class MagicBenchmark
{
    [Params(10_000)]
    public int Lenght { get; set; }
    
    [Benchmark]
    public void ConvertNormal()
    {
        var rgb = GenerateRGBArray(Lenght);
        var rgbStructs = new RGB[Lenght];
        for (int i = 0; i < Lenght; i++)
        {
            var index = i * 3;
            rgbStructs[i].R = rgb[index];
            rgbStructs[i].G = rgb[index + 1];
            rgbStructs[i].B = rgb[index + 2];
        }
    }

    [Benchmark]
    public void Magic()
    {
        var rgb = GenerateRGBArray(Lenght);
        var rgbStructs = MemoryMarshal.Cast<byte, RGB>(rgb);
    }
    
    [Benchmark]
    public void DoubleMagic()
    {
        Span<byte> rgb = stackalloc byte[Lenght * 3];
        GenerateRGBArrayStack(rgb);
        var rgbStructs = MemoryMarshal.Cast<byte, RGB>(rgb);
    }
    
    private byte[] GenerateRGBArray(int rgbCount)
    {
        var rgb = new byte[rgbCount * 3];
        var rgbIndex = 0;
        for (int i = 0; i < rgbCount; i++)
        {
            rgb[rgbIndex++] = (byte)(i % 256);
            rgb[rgbIndex++] = (byte)(i % 256);
            rgb[rgbIndex++] = (byte)(i % 256);
        }
        return rgb;
    }

    private void GenerateRGBArrayStack(Span<byte> rgb)
    {
        var rgbCount = rgb.Length / 3;
        var rgbIndex = 0;
        for (int i = 0; i < rgbCount; i++)
        {
            rgb[rgbIndex++] = (byte)(i % 256);
            rgb[rgbIndex++] = (byte)(i % 256);
            rgb[rgbIndex++] = (byte)(i % 256);
        }
    }
    
    private struct RGB
    {
        public byte R;
        public byte G;
        public byte B;
    }
}