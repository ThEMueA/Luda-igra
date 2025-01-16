using UnityEngine;
using System.IO;

public class saveSystem
{
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/saves/";
    public static readonly string FILE_EXT = ".json";

    public static void save(string Filename, string dataToSave)
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }

        File.WriteAllText(SAVE_FOLDER+Filename+FILE_EXT , dataToSave);

    }

    public static string Load(string filename)
    {

        string fileLoc = SAVE_FOLDER + filename + FILE_EXT;
        if (File.Exists(fileLoc))
        {string loadedDAta= File.ReadAllText(fileLoc);
            return loadedDAta;
        }
        else
        {
            return null;
        }
    }

}
