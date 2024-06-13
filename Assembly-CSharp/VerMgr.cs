using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;

public class VerMgr
{
    public void LoadVerInfo(string path, string dumpPath)
    {
        MemoryStream ms = new MemoryStream(File.ReadAllBytes(path));
        BinaryFormatter bf = new BinaryFormatter();
        this.netData = bf.Deserialize(ms) as VerInfo;
        using (StreamWriter sw = new StreamWriter(dumpPath))
        {
            Console.WriteLine("Dumping version info to " + dumpPath + "...");
            foreach (ABVerData abVerData in this.netData.abDataList)
            {
                sw.WriteLine(abVerData.name);
            }
        }
    }
    
    private VerInfo netData;
}