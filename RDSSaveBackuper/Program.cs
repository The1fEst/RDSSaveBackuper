using System;
using System.IO;
using System.Linq;

namespace RDSSaveBackuper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Any())
            {
                var path = args[0];
                if (Directory.Exists(path))
                {
                    Console.WriteLine($"\n\"{path}\" - directory exist");

                    var files = Directory.GetFiles(path);

                    Console.WriteLine($"\nDirectory include files...\n[{string.Join("]\n[", files)}]");
                    var backupPath = $"{path}/backup_{DateTime.Now:yyyyMMddhhmmss}";

                    if (!Directory.Exists(backupPath))
                    {
                        Console.WriteLine($"\nCreating new directory for backup...\n[{backupPath}]");
                        Directory.CreateDirectory(backupPath);
                    }

                    var currentSaves = files.Where(x => x.Contains(".fp4"));

                    foreach (var currentSave in currentSaves)
                    {
                        var fileName = Path.GetFileName(currentSave);
                        Console.WriteLine(
                            $"\nTrying to backup your save...\nFrom [{currentSave}] to [{backupPath}/{fileName}]");
                        File.Copy(currentSave, $"{backupPath}/{fileName}");
                    }

                    Console.WriteLine($"\nBackup complited...");
                }
            }
            else
            {
                Console.WriteLine("ah shit here we go again");
            }
        }
    }
}