using CommandLine;

namespace CrossCore
{
    public class Options
    {
        [Option('i', "infile", Required = true, HelpText = "Input lua file to be processed.")]
        public string InFile { get; set; }

        [Option('o', "outfile", Required = true, HelpText = "Output processed lua file.")]
        public string OutFile { get; set; }

        [Option('e', "encrypt", Default = false, HelpText = "Encrypt the lua file.")]
        public bool Encrypt { get; set; }

        [Option('d', "decrypt", Default = false, HelpText = "Decrypt the lua file.")]
        public bool Decrypt { get; set; }
        
        [Option('p', "platform", Default = "Android", HelpText = "Platform(Android/iOS).")]
        public string Platform { get; set; }

        [Option("nofix", Default = false, HelpText = "Do not fix the file.")]
        public bool NoFix { get; set; }
        
        [Option("ver-bytes", Default = false, HelpText = "Read version data from file.")]
        public bool VerBytes { get; set; }
        
        [Option('h', "help", Default = false, HelpText = "Show help.")]
        public bool Help { get; set; }
    }
    
    internal static class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (o.Encrypt)
                    {
                        string platform = o.Platform.ToLower(); 
                        switch (platform)
                        {
                            case "android":
                                LuaScripts.GenEncryptABData(o.InFile, o.OutFile, true, !o.NoFix);
                                break;
                            case "ios":
                                LuaScripts.GenEncryptABData(o.InFile, o.OutFile, false, !o.NoFix);
                                break;
                            default:
                                throw new Exception($"Invalid platform: {o.Platform}");
                        }
                    }
                    else if (o.Decrypt)
                    {
                        LuaScripts.GenDecryptABData(o.InFile, o.OutFile);
                    }
                    else if (o.VerBytes)
                    {
                        VerMgr verMgr = new VerMgr();
                        verMgr.LoadVerInfo(o.InFile, o.OutFile);
                    }
                    else if (o.Help)
                    {
                        Console.WriteLine("Help");
                    }
                });
        }
    }
}