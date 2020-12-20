namespace CompanyWatchlistAPI.Services.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
        bool EncryptedEquals(string cipherText1, string cipherText2);
    }
}
