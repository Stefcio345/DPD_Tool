using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using Markdig.Parsers.Inlines;
using MudBlazor;
using MudBlazor.Components.Highlighter;

namespace DPD_App;

public class MarkdownService
{
    static readonly Regex HeaderChecker = new Regex(@"^[#]+$");
    public static string ToHtml(string text)
    {
        if (text is null)
        {
            return "";
        }

        string endHtml = "";
        var headerStack = new Stack<int>();

        //Breakdown by lines
        var lines = text.Split('\n').ToList().Select(line => new line(line)).ToList();

        foreach (var line in lines)
        {
            //Check for header
            if (HeaderChecker.IsMatch(line.Split()[0]))
            {
                line.header = line.Split()[0].Length;
                line.content = line.content[(line.Split()[0].Length + 1)..];

                while (headerStack.Count > 0 && line.header <= headerStack.Peek())
                {
                    endHtml += $"</div header={headerStack.Pop()}>";
                }

                headerStack.Push(line.header);
                endHtml += $"<div header={line.header}>";
            }
            if(line.header < 7) endHtml += $"<h{line.header}>{line}</h{line.header}>";
            else endHtml += $"<div>{line}</div>";
            
        }

        foreach (var header in headerStack)
        {
            // End all divs
            endHtml += $"</div header={header}>";
        }

        return endHtml;
    }
}

class line
{
    public string content;
    public int header;

    public line(string content, int header = 10)
    {
        this.content = content;
        this.header = header;
    }

    public string[] Split(string? splitter = null)
    {
        return splitter is null ? content.Split() : content.Split(splitter);
    }

    public override string ToString()
    {
        return content;
    }
}

class Page
{
    
}

class Header
{
    
}