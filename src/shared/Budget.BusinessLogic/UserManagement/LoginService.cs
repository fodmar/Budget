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

        public async Task<LoginAttempt> Login(string login, string password)
        {
            string hash = this.CalculateHash(password);

            UserPassword userPassword = new UserPassword(login, hash);

            User user = await this.userProvider.FindUser(userPassword);
            LoginAttempt attempt = new LoginAttempt(user);

            return attempt;
        }

        private string CalculateHash(string password)
        {
            byte[] hash;
            using (MD5 algorithm = MD5.Create())
            {
                hash = algorithm.ComputeHash(Encoding.ASCII.GetBytes(password));
            }

            StringBuilder stringBuiler = new StringBuilder();
            foreach (byte item in hash)
            {
                stringBuiler.Append(item.ToString("x2"));
            }

            return stringBuiler.ToString();
        }
    }
}
