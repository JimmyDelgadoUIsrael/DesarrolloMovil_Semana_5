namespace jdelgadoS5A
{
    public class FileAccesHelper
    {
        public static string GetLocalFilePath(string filename)
        {

            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }

    }
}
