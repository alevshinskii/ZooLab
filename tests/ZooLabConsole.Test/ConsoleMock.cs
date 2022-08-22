using System.Text;
using ZooLab.Console;

namespace ZooLab.Test;

public class ConsoleMock : IConsole
{
    public List<string> Output { get; } = new List<string>();

    public void WriteLine(string message)
    {
        Output.Add(message);
    }
    
}