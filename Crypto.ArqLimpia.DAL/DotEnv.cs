
using System;
using System.IO;

namespace Crypto.ArqLimpia.DAL
{
    public class DotEnv
    {
          public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }

        public static void LoadEnv(){

            var root = Directory.GetCurrentDirectory();
            var parentDirectory = Directory.GetParent(root)?.FullName;
            var dotenv = Path.Combine(parentDirectory, ".env");
            Load(dotenv);

        }
        
    }
}