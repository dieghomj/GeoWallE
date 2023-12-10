System.Console.WriteLine("Entry code: (and end it with \"exit\" keyword in a new line) \n");

string code = "";

while (true)
{
    string line = Console.ReadLine()!;

    if (line == "exit")
        break;

    code += line + " ";
}

foreach(var token in new Lexer(code))
    System.Console.WriteLine(token.Kind);

// Parser parser = new Parser(code);

// Binder binder = new Binder(parser.Parse());

// Dictionary<string, GObject> visibleVariables = new Dictionary<string, GObject>();

// foreach (var boundStatement in binder.Bind(new Dictionary<string, GType>()))
//     boundStatement.EvaluateStatement(visibleVariables);
