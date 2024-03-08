namespace GameDevStudy.Monotris.Domain.Services
{
    internal class FileWrapper : IFileWrapper
    {
        public string ReadAllText(string file)
        {
            if (!File.Exists(file))
            {
                using (File.Create(file)); 
            }
            return File.ReadAllText(file);
        }

        public void WriteAllText(string file, string text)
        {
            File.WriteAllText(file, text);
        }
    }
}
