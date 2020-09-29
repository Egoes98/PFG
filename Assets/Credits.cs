using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public TextAsset credits_text;
    public Text credits_displayer;
    string[] text_lines;
    List<string> display_lines = new List<string>();
    int displayedLines;
    public int maxLineDisplay;
    public int totalLines;
    public float delay;
    string dummy_line = " ";

    void Start()
    {
        text_lines = credits_text.text.Split('\n');
        displayedLines = 0;
        display_lines.Add(text_lines[displayedLines]);
        InvokeRepeating("addLine", 1.0f, delay);
    }

    void addLine()
    {
        if (displayedLines >= totalLines)
        {
            if (maxLineDisplay == 0) return;
            maxLineDisplay--;
            display_lines.RemoveAt(0);
            display_lines.Add(dummy_line);
            return;
        }
        if (displayedLines >= maxLineDisplay)
        {
            display_lines.RemoveAt(0);
        }
        displayedLines++;
        display_lines.Add(text_lines[displayedLines]);
    }

    // Update is called once per frame
    void Update()
    {
        credits_displayer.text = "";
        for (int i = 0; i < display_lines.Count; i++)
        {
            credits_displayer.text = credits_displayer.text + '\n' + display_lines[i];
        }
    }
}
