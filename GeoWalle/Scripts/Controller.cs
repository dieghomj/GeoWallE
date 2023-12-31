using Godot;
using Gsharp;
using System;
using System.IO;

public partial class Controller : Control
{
	private TabContainer TabContainer;
	private Button RunButton;
	private PanelContainer Editor;
	private SplitContainer DrawAndDebug;
	private SplitContainer Workspace;
	private TextEdit DebugConsole;

	public override void _Ready()
	{
		DebugConsole = (TextEdit)GetNode("Workspace/Draw and Debug/DebugConsole/TextEdit");
		Workspace = (SplitContainer)GetNode("Workspace");
		TabContainer = (TabContainer)GetNode("Workspace/Editor/EditorsTabs");
		RunButton = (Button)GetNode("Buttons/ButtonContainer/RunButton");
		Editor = (PanelContainer)GetNode("Workspace/Editor");
		DrawAndDebug = (SplitContainer)GetNode("Workspace/Draw and Debug");
	}
	public override void _Process(double delta) { }

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
			DebugConsole.AddThemeColorOverride("font_readonly_color",Godot.Color.Color8(230,100,100));
			DebugConsole.Text =
				e.Message + "\n" + e.InnerException + "\n" + e.StackTrace + "\n" + e.Source;
			GD.PrintErr(e.Message + "\n" + e.InnerException + "\n" + e.StackTrace + "\n" + e.Source);
			return;
		}
		RunButton.Disabled = false;
	}

	public void _OnRunButtonButtonDown()
	{
		try
		{
			Compiler.Evaluate();
			DebugConsole.AddThemeColorOverride("font_readonly_color",Godot.Color.Color8(244,244,244));
			DebugConsole.Text = Compiler.Print("");
		}
		catch (Exception e)
		{
			DebugConsole.AddThemeColorOverride("font_readonly_color",Godot.Color.Color8(230,100,100));
			DebugConsole.Text =
				e.Message + "\n" + e.InnerException + "\n" + e.StackTrace + "\n" + e.Source;
			;
			GD.PrintErr(e.Message + "\n" + e.InnerException + "\n" + e.StackTrace + "\n" + e.Source);
			RunButton.Disabled = true;
			return;
		}
	}

	public void OnCodeEditCodeCompletionRequested()
	{
		var currentCode = (CodeEdit)TabContainer.GetCurrentTabControl();
		GD.Print(currentCode.Name);
		foreach (var keyword in SyntaxFacts.Keywords.Keys)
		{
			currentCode.AddCodeCompletionOption(
				CodeEdit.CodeCompletionKind.Class,
				keyword,
				keyword
			);
		}

		currentCode.UpdateCodeCompletionOptions(true);
	}

	private string saveCode;
	public void OnSaveButtonButtonDown()
	{
		var lineEdit = GetNode<LineEdit>("Buttons/ButtonContainer/SaveButton/LineEdit");
		var code = (CodeEdit)TabContainer.GetCurrentTabControl();
		saveCode = code.Text;
		lineEdit.Visible = !lineEdit.Visible;
	}

	public void OnLineEditTextSubmitted(string fileName)
	{
		var file = File.Create($"{fileName}");
		using (StreamWriter writer = new StreamWriter(file))
		{
			writer.Write(saveCode);
		}
		var lineEdit = GetNode<LineEdit>("Buttons/ButtonContainer/SaveButton/LineEdit");
		var code = TabContainer.GetCurrentTabControl();
		code.Name = fileName;
		lineEdit.Visible = false;
	}

	public void _OnCodeEditTextChanged()
	{
		RunButton.Disabled = true;
	}
}
