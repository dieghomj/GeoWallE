using Gsharp;

public class BoundImportStatement : BoundStatement
{
    public BoundImportStatement(BoundExpression path)
    {
        Path = path;
    }

    public BoundExpression Path { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        string code = "";
        string directory = (string)Path.Evaluate(visibleVariables).GetValue();

        switch (Compiler.GetState(directory))
        {
            case NodeState.UnProcessed:
                Compiler.AddState(directory, NodeState.Processing);
                break;
            case NodeState.Processing:
                System.Console.WriteLine("Compilation Error: There is a cycle in file imports");
                return;
            case NodeState.Processed:
                return;
        }

        try
        {
            StreamReader file = new StreamReader(directory);

            string? line = file.ReadLine();

            while (line != null)
            {
                code += line;
                line = file.ReadLine();
            }

            file.Close();

            Compiler.GetSyntaxStatements(code);

            Compiler.AddState(directory, NodeState.Processed);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}
