using CompanyWatchlistAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CompanyWatchlistAPI.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly IConfiguration _configuration;

        public EncryptionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool EncryptedEquals(string cipherText1, string cipherText2)
        {
            return Decrypt(cipherText1) == Decrypt(cipherText2);
        }

        public string Encrypt(string plainText)
        {
            using (SymmetricAlgorithm algorithm = DES.Create())
            {
                ICryptoTransform transform = algorithm.CreateEncryptor(Encoding.Default.GetBytes(_configuration["Key"]), Encoding.Default.GetBytes(_configuration["IV"]));
                byte[] inputbuffer = Encoding.Unicode.GetBytes(plainText);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                return Convert.ToBase64String(outputBuffer);
            }
        }

        public string Decrypt(string cipherText)
        {
            using (SymmetricAlgorithm algorithm = DES.Create())
            {
                ICryptoTransform transform = algorithm.CreateDecryptor(Encoding.Default.GetBytes(_configuration["Key"]), Encoding.Default.GetBytes(_configuration["IV"]));
                byte[] inputbuffer = Convert.FromBase64String(cipherText);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                return Encoding.Unicode.GetString(outputBuffer);
            }
        }
    }
}
