using System.Text;

namespace AOC2023.Tests;

public static class MethodsForTesting
{
    public static StreamReader StringToStreamReader(string input)
    { 
        byte[] byteArray = Encoding.UTF8.GetBytes(input);
        MemoryStream stream = new(byteArray);
        StreamReader reader = new(stream);
        return reader;
    }
}