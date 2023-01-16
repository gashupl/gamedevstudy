namespace GameDevStudy.Monotris.Domain.Services
{
    public interface IFileWrapper
    {
        string ReadAllText(string file);
        void WriteAllText(string file, string text); 
    }
}