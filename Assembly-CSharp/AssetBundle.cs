using System.Runtime.Serialization.Formatters.Binary;

public class AssetBundle
{
    public static void GenEncryptABData(string rawfile, string outfile)
    {
        ABCustom abCustom = new ABCustom();
        abCustom.bytes = File.ReadAllBytes(rawfile);
        ABCustom.DdooEennccyypptt(ref abCustom.bytes);
        
        using (FileStream fs = new FileStream(outfile, FileMode.Create))
        {
#pragma warning disable SYSLIB0011
            BinaryFormatter bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
            bf.Serialize(fs, abCustom);
        }
    }

    public static void GenDecryptABData(string rawfile, string outfile)
    {
        byte[] bytes;
        using (FileStream fs = new FileStream(rawfile, FileMode.Open, FileAccess.Read))
        {
            fs.Seek(152, SeekOrigin.Begin); // Skip the first 152 bytes
            using (BinaryReader br = new BinaryReader(fs))
            {
                bytes = br.ReadBytes((int)(fs.Length - 152));
            }
        }
        ABCustom.DdooEennccyypptt(ref bytes);
        File.WriteAllBytes(outfile, bytes);
    }
}
