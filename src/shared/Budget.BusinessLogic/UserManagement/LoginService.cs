using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.BusinessLogic.UserManagement
{
    public class LoginService : ILoginService
    {
        private IUserProvider userProvider;

        public LoginService(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        public LoginAttempt Login(string login, SecureString password)
        {
            string hash = this.CalculateHash(password);

            UserPassword userPassword = new UserPassword { UserLogin = login, Hash = hash };

            User user = this.userProvider.FindUser(userPassword);
            LoginAttempt attempt = new LoginAttempt(user);

            return attempt;
        }

        private string CalculateHash(SecureString password)
        {
            // never do crypto yourself :)

            char[] passwordChars = new char[password.Length];
            IntPtr passwordPointer = Marshal.SecureStringToBSTR(password);

            // password is visible now
            Marshal.Copy(passwordPointer, passwordChars, 0, passwordChars.Length);

            // delete password from memory
            Marshal.ZeroFreeBSTR(passwordPointer);
            password = null;

            // hash
            byte[] hash;
            using (MD5 algorithm = MD5.Create())
            {
                hash = algorithm.ComputeHash(Encoding.ASCII.GetBytes(passwordChars));
            }

            // delete copy of password from memory
            for (int i = 0; i < passwordChars.Length; i++)
            {
                passwordChars[i] = '\0';
            }

            StringBuilder stringBuiler = new StringBuilder();
            foreach (byte item in hash)
            {
                stringBuiler.Append(item.ToString("X2"));
            }

            return stringBuiler.ToString();
        }
    }
}
