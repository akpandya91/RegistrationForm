using System.Security.Cryptography;
using System.Text;

namespace VoingPracticalTestAPI.Comman_func
{
    public static class comman
    {
        public static bool ValidateEmailId(string email)
        {
            try
            {
                var trimmedEmail = email.Trim();

                if (trimmedEmail.EndsWith("."))
                {
                    return false; // suggested by @TK-421
                }
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == trimmedEmail;
                }
                catch
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
