System.Console.WriteLine("Entry code: (and end it with exit keyword in a new line) \n");

string code = "";

while (true)
{
    string line = Console.ReadLine()!;

    if (line == "exit")
        break;

    code += line;
}

// foreach(var token in new Lexer(code))
//     System.Console.WriteLine(token.Kind);

Parser parser = new Parser(code);

foreach (var statement in parser.Parse())
    System.Console.WriteLine(statement.GetType());
