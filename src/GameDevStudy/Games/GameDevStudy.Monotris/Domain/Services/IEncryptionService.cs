namespace GameDevStudy.Monotris.Domain.Services
{
    public interface IEncryptionService
    {
        string Encrypt(string input); 

        string Decrypt(string input);
    }
}