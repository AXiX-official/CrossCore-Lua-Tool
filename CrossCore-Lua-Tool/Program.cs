namespace CrossCore
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string rawfile = "";
            string outfile = "";
            bool encrypt = false;
            bool decrypt = false;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--rawfile":
                    case "-r":
                        if (i + 1 < args.Length)
                        {
                            rawfile = args[++i];
                        }
                        break;
                    case "--outfile":
                    case "-o":
                        if (i + 1 < args.Length)
                        {
                            outfile = args[++i];
                        }
                        break;
                    case "--encrypt":
                        encrypt = true;
                        break;
                    case "--decrypt":
                        decrypt = true;
                        break;
                    case "--help":
                    case "-h":
                        Console.WriteLine("Usage: --rawfile <rawfile> --outfile <outfile> [--encrypt] [--decrypt]");
                        return;
                    default:
                        Console.WriteLine($"Unknown argument: {args[i]}");
                        break;
                }
            }

            if (string.IsNullOrEmpty(rawfile) || string.IsNullOrEmpty(outfile))
            {
                Console.WriteLine("Usage: --rawfile <rawfile> --outfile <outfile> [--encrypt] [--decrypt]");
                return;
            }

            if (encrypt)
            {
                AssetBundle.GenEncryptABData(rawfile, outfile);
            }
            else if (decrypt)
            {
                AssetBundle.GenDecryptABData(rawfile, outfile);
            }
        }
    }
}