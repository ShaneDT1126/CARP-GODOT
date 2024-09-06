using Godot;
using System;

public partial class DocumentationsList : VBoxContainer
{
    /* -- TO DO --
       1. Make a tokenizer to convert text to tokens
       2. Make a label template, TextureRect template, and Button template for the convert to documentation in here
       3. Improve more of this and analyze the structure more
     */


    private string directoryPath = "Carp_Documentation";
    [Export] private VBoxContainer documentationBtnList;
    [Export] private ColorRect documentationList;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        GetAllCarpdocFilesInDirectory();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        
    }

    public void GetAllCarpdocFilesInDirectory()
    {
        // Open the directory
        DirAccess dir = DirAccess.Open(directoryPath);
        if (dir == null)
        {
            GD.PrintErr("Failed to open directory: " + directoryPath);
            return;
        }

        // Iterate through the directory contents
        dir.ListDirBegin(); // Start listing the directory contents

        string fileName = dir.GetNext();
        while (fileName != "")
        {
            // Skip special entries "." and ".."
            if (!dir.CurrentIsDir() && fileName.EndsWith(".carpdoc"))
            {
                // Process .carpdoc file
                GD.Print("Carpdoc File: " + fileName);
            }

            fileName = dir.GetNext(); // Get the next file
        }

        dir.ListDirEnd(); // Finish listing the directory contents
    }

}