using System;
using System.IO;

namespace Liftoff.Logging
{
    public interface IManageFiles
    {
        void Move(string sourcePath, string destinationPath);
        void Delete(string path);
        bool Exists(string path);
        DateTime GetLastWriteDate(string path);
        StreamWriter OpenStreamWriter(string path, FileAccess fileAccess, FileShare fileShare);
    }

    public class DefaultFileManager : IManageFiles
    {
        private static readonly Lazy<IManageFiles> InternalInstance = new Lazy<IManageFiles>(() => new DefaultFileManager());
        public static IManageFiles Instance => InternalInstance.Value;

        private DefaultFileManager()
        {
        }

        public void Move(string sourcePath, string destinationPath)
        {
            File.Move(sourcePath, destinationPath);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public DateTime GetLastWriteDate(string path)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(path);
            return new DateTime(lastWriteTime.Year, lastWriteTime.Month, lastWriteTime.Day);
        }

        public StreamWriter OpenStreamWriter(string path, FileAccess fileAccess, FileShare fileShare)
        {
            string folder = Path.GetDirectoryName(path);

            if (folder == null)
                throw new DirectoryNotFoundException($"Directory can't be extracted from '{path}'");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var stream = new FileStream(path, FileMode.OpenOrCreate, fileAccess, fileShare);
            stream.Seek(0, SeekOrigin.End);
            return new StreamWriter(stream);
        }
    }
}
