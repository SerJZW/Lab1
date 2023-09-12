using Lab1;

Terminal terminal = new Terminal();
string input = Console.ReadLine();
terminal.Logic(input);
string terminalState = terminal.GetTerminalState();
Console.WriteLine(terminalState);
