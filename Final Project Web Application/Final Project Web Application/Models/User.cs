using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Security.Cryptography;

namespace Final_Project_Web_Application.Models
{
    public class User
    {
        public enum SecurityLevel
        {
            User,
            Admin,
            Owner
        }

        [Key] public int ID { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public SecurityLevel SecLevel { get; set; }

        public User(string username, string password, SecurityLevel secLevel)
        {
            Username = username;
            Password = password;
            SecLevel = secLevel;
        }

        // Encrypt a String So that it cannot be read as Plain Text.
        public static string EncryptString(string CleanString)
        {
            string EncryptionKey = "KeyCode|LPQ246s!2";

            byte[] ClearBytes = Encoding.Unicode.GetBytes(CleanString);
            using (Aes Encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                Encryptor.Key = pdb.GetBytes(32);
                Encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, Encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(ClearBytes, 0, ClearBytes.Length);
                        cs.Close();
                    }

                    CleanString = Convert.ToBase64String(ms.ToArray());
                }
            }

            return CleanString;
        }

        // Decrypt an Encrypted String so that it can be read as Plain Text.
        public static string DecryptString(string EncryptedString)
        {
            string EncryptionKey = "KeyCode|LPQ246s!2";
            EncryptedString = EncryptedString.Replace(" ", "+");
            byte[] CipherBytes = Convert.FromBase64String(EncryptedString);

            using (Aes Encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes PDB = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                Encryptor.Key = PDB.GetBytes(32);
                Encryptor.IV = PDB.GetBytes(16);

                using (MemoryStream MemStream = new MemoryStream())
                {
                    using (CryptoStream CStream = new CryptoStream(MemStream, Encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        CStream.Write(CipherBytes, 0, CipherBytes.Length);
                        CStream.Close();
                    }

                    EncryptedString = Encoding.Unicode.GetString(MemStream.ToArray());
                }
            }

            return EncryptedString;
        }
    }
}
