using System;
using System.IO.FileSystem.Watcher.Polling;
using System.Linq;

namespace PollingFileWatcher
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
            PollingFileSystemWatcher fileSystemWatcher = new PollingFileSystemWatcher(path);
            fileSystemWatcher.ChangedDetailed += FileSystemWatcher_Changed;
            fileSystemWatcher.Start();
        }

        private static void FileSystemWatcher_Changed(object sender, PollingFileSystemEventArgs e) =>
            Console.WriteLine($@"File changed: {string.Join(',', e.Changes.Select(x => $"{x.ChangeType}: {x.Name}"))}");
    }
}