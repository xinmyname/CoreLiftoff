using System;
using System.IO;

namespace Liftoff.Logging {

    public interface IManageFiles{

        void WriteLine(string path, string text);
        void Move(string sourcePath, string destinationPath);
        void Delete(string path);        
    }

    public class DefaultFileManager : IManageFiles {

        public static readonly DefaultFileManager Instance = new DefaultFileManager();

        private DefaultFileManager() {
        }

        public void WriteLine(string path, string text) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (text == null)
                throw new ArgumentNullException(nameof(text));

            string folder = Path.GetDirectoryName(path);

            if (folder == null)
                throw new DirectoryNotFoundException($"Directory can't be extracted from '{path}'");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            File.AppendAllText(path, $"{text}\n");
        }

        public void Move(string sourcePath, string destinationPath) {
            File.Move(sourcePath, destinationPath);
        }

        public void Delete(string path) {
            File.Delete(path);
        }
        
    }
}
