using Godot;
using Gsharp;
using System;

public partial class Controller : Control
{
    private TabContainer TabContainer;
    private Button RunButton;
    private PanelContainer Editor;
    private SplitContainer DrawAndDebug;
    private SplitContainer Workspace;


    public override void _Ready()
    {
        Workspace = (SplitContainer)GetNode("Workspace");
        TabContainer = (TabContainer)GetNode("Workspace/Editor/EditorsTabs");
        RunButton = (Button)GetNode("Buttons/ButtonContainer/RunButton");
        Editor = (PanelContainer)GetNode("Workspace/Editor");
        DrawAndDebug = (SplitContainer)GetNode("Workspace/Draw and Debug");
    }

    public override void _Process(double delta)
    {
    }
    public void OnCompileButtonButtonDown()
    {
        var codeEdit = (CodeEdit)TabContainer.GetCurrentTabControl();
        var codeText = codeEdit.Text;
        try
        {
            Compiler.Compile(codeText);
        }
        catch (Exception e)
        {
            GD.PrintErr(e.Message, e.Message, e.InnerException, e.StackTrace, e.Source);
            return;
        }
        RunButton.Disabled = false;
    }
    public void _OnRunButtonButtonDown()
    {
        try
        {
            Compiler.Evaluate();
        }
        catch (Exception e)
        {
            GD.PrintErr(e.Message, e.InnerException, e.StackTrace, e.Source);
            return;
        }
    }

    public void OnCodeEditCodeCompletionRequested()
    {
        var currentCode = (CodeEdit)TabContainer.GetCurrentTabControl();
        GD.Print(currentCode.Name);
        foreach (var keyword in SyntaxFacts.Keywords.Keys)
        {
            currentCode.AddCodeCompletionOption(CodeEdit.CodeCompletionKind.Class,keyword,keyword);
        }

        // foreach (var variable in Compiler.bindVariables.Keys)
        // {
        //     currentCode.AddCodeCompletionOption(CodeEdit.CodeCompletionKind.Variable,variable,variable);
        // }

        currentCode.UpdateCodeCompletionOptions(true);
    }

    public void _OnCodeEditTextChanged()
    {
        RunButton.Disabled = true;
    }
}
