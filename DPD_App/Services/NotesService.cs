namespace DPD_App;

public class NotesService
{
    public static AppSettings Settings { get; set; }

    public static string SaveNoteToFile(string text, string filename)
    {
        string docPath = "./";
        
        docPath = Globals.SaveLocation + "/" + Settings.NoteSaveLocation;
        
        Directory.CreateDirectory(docPath);

        using (StreamWriter w = File.CreateText(Path.Combine(docPath, filename+".md")))
        {
            w.WriteLine(text);
        }
        
        return filename;
    }
    
    public static void CreateNewNote(string filename)
    {
        string docPath = "./";
        
        docPath = Globals.SaveLocation + "/" + Settings.NoteSaveLocation;
        
        Directory.CreateDirectory(docPath);

        using (StreamWriter w = File.AppendText(Path.Combine(docPath, filename+".md")))
        {
            w.WriteLine("");
        }
    }

    public static List<string> GetNotes()
    {
        var path = Globals.SaveLocation + "/" + Settings.NoteSaveLocation;
        var files = new List<string>();
        Directory.CreateDirectory(path);
        var d = new DirectoryInfo(path);
        foreach (var file in d.GetFiles("*.md"))
        {
            // Rest of the code goes here 
            files.Add(file.Name.Substring(0, file.Name.Length - file.Extension.Length));
        }

        return files;
    }

    public static string GetNoteContent(string filename)
    {
        var path = Globals.SaveLocation + "/" + Settings.NoteSaveLocation;
        try
        {
            return File.ReadAllText(path + "/" + filename + ".md");
        }
        catch (FileNotFoundException e)
        {
            return "File was not found";
        }
    }
}