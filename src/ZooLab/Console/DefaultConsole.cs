﻿namespace ZooLab.Console;

public class DefaultConsole:IConsole
{
    public void WriteLine(string message)
    {
        System.Console.WriteLine(message);
    }
}