using System.Runtime.Serialization.Formatters.Binary;

public class LuaScripts
{
    public static void GenEncryptABData(string rawfile, string outfile, bool fix = true)
    {
        ABCustom abCustom = new ABCustom();
        byte[] rawBytes = File.ReadAllBytes(rawfile);
        if (fix)
        {
            string luaFileURL = "https://cdn.megagamelog.com/cross/release/android/curr/Custom/luascripts";
            var wwwMgr = new WWWMgr();
            var tcs = new TaskCompletionSource<bool>();
            wwwMgr.GetFileSizeAsync(luaFileURL).ContinueWith(task =>
            {
                if (task.IsFaulted || task.IsCanceled)
                {
                    Console.WriteLine("Error: " + task.Exception.Message);
                    tcs.SetResult(false);
                }
                else
                {
                    long len = task.Result - 153;
                    Console.WriteLine("Lua file size should be: " + len);
                    if (rawBytes.Length <= len)
                    {
                        Console.WriteLine("Resizing rawBytes to fit the Lua file size.");
                        Array.Resize(ref rawBytes, (int)len);
                        tcs.SetResult(true);
                    }else
                    {
                        throw new Exception("rawBytes is too long");
                    }
                }
            });
            tcs.Task.Wait();
        }
        abCustom.bytes = rawBytes;
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
                bytes = br.ReadBytes((int)(fs.Length - 152 - 1));
            }
        }
        ABCustom.DdooEennccyypptt(ref bytes);
        File.WriteAllBytes(outfile, bytes);
    }
}
