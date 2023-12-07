using Godot;
using System;

public partial class TabController : TabContainer
{
    private Node CodeEdit;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		GetTabControl(0).Name = "Code";
		CodeEdit = GetTabControl(0).Duplicate();
		CodeEdit.Name = "Code";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnTabHovered(int tab)
	{
		if(tab == GetTabCount() - 1)
		{
			DragToRearrangeEnabled = false;
		}
		else DragToRearrangeEnabled = true;
	}

	public void OnTabClicked(int tab)
	{
        bool isNewButton;
        if (tab == GetTabCount() - 1)
		{
			var newTabButton = GetTabControl(tab).Duplicate();
			GetTabControl(tab).Free();

			var newCodeEdit = CodeEdit.Duplicate();
			AddChild(newCodeEdit);
			newCodeEdit.Name = "Code";
			AddChild(newTabButton);
			newTabButton.Name = "+";
		
		}
	}
}
