using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Full_Stack_Project.Models
{
    public class Encrypt_Decrypt
    {
        public string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                //Encoding
                byte[] storePassword = ASCIIEncoding.ASCII.GetBytes(password);

                //convert password into base 64 string
                string encryptedPassword = Convert.ToBase64String(storePassword);
                return encryptedPassword;
            }
        }


        public string DecryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                byte[] encryptedPassword = Convert.FromBase64String(password);
                string decryptedPassword = ASCIIEncoding.ASCII.GetString(encryptedPassword);

                return decryptedPassword;
            }
        }
    }
}
