using System;
using System.IO;

namespace HW8._2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке");
            string DirName = Console.ReadLine();
            Console.WriteLine($"Размер папки {DirName} - {FolderSize(DirName)} байт.");
        }

        static long FolderSize(string dirName)
        {
            long folderSize = 0;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);

                if (dirInfo.Exists)
                {
                    FileInfo[] files = dirInfo.GetFiles();

                    foreach (var item in files)
                    {
                        folderSize += item.Length;
                    }

                    DirectoryInfo[] subfolders = dirInfo.GetDirectories();

                    foreach (var item in subfolders)
                    {
                        folderSize += FolderSize(item.FullName);
                    }
                }

                else
                {
                    Console.WriteLine("Указан неверный путь к директории");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return folderSize;
        }
    }
}

