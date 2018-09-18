using System;
using System.IO;

namespace FileWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\draycir\MockData\Signal";
            MonitorDirectory(path);
            Console.ReadKey();
        }

        private static void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher {Path = path};
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e) =>
            Console.WriteLine("File created: {0}", e.Name);

        private static void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e) =>
            Console.WriteLine("File renamed: {0}", e.Name);

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine("File deleted: {0}", e.Name);
    }
}