﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using ShapeDrawing;

public class ShapeDrawingForm : Form
{
	private List<Shape> shapes;

	public ShapeDrawingForm() 
	{
        MenuStrip menuStrip;
        menuStrip = new MenuStrip();

        ToolStripDropDownItem menu;
        menu = new ToolStripMenuItem("File");
		menu.DropDownItems.Add("Open...", null, openFileHandler);
		menu.DropDownItems.Add("Export...", null, exportHandler);
        menu.DropDownItems.Add("Exit", null, closeHandler);
        menuStrip.Items.Add(menu);

        Controls.Add(menuStrip);
		// Some basic settings
		Text = "Shape Drawing and Converter";
		Size = new Size(400, 400);
		CenterToScreen();
		SetStyle(ControlStyles.ResizeRedraw, true);
		
		// Initialize shapes
        shapes = new List<Shape>();
		
		// Listen to Paint event to draw shapes
		Paint += new PaintEventHandler(OnPaint); 
	}

    // What to do when the user closes the program
    private void closeHandler(object sender, EventArgs e)
    {
        Close();
    }

    // What to do when the user opens a file
    private void openFileHandler(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "";
        dialog.Title = "Open file...";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            shapes = Parser.ParseShapes(dialog.FileName);
            Refresh();
        }

    }

    // What to do when the user wants to export a TeX file
	private void exportHandler (object sender, EventArgs e)
	{
		Stream stream;
		SaveFileDialog saveFileDialog = new SaveFileDialog();

		saveFileDialog.Filter = "svg files|*.svg";
		saveFileDialog.RestoreDirectory = true;
		
		if(saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			if((stream = saveFileDialog.OpenFile()) != null)
			{
				// Insert code here that generates the string of SVG
                //   commands to draw the shapes
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    GenerateSVG generateSVG = new GenerateSVG() { streamWriter = writer };
                    writer.WriteLine("<?xml version= \"1.0\" standalone=\"no\"?>");
                    writer.WriteLine("<!DOCTYPE svg PUBLIC \" -//W3C//DTD SVG 1.1//EN\"");
                    writer.WriteLine("  \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">");
                    writer.WriteLine("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">");
                    foreach (Shape shape in shapes)
                    {
                        Console.WriteLine("hij doet een shapie");
                        shape.Draw(generateSVG);
                    }
                    writer.WriteLine("</svg>");
                }				
			}
		}
	}

    private void OnPaint(object sender, PaintEventArgs e)
	{
        // Draw all the shapes
        WindowsForm wf = new WindowsForm();
        wf.graphics = e.Graphics;
		foreach(Shape shape in shapes)
			shape.Draw(wf);
	}
}