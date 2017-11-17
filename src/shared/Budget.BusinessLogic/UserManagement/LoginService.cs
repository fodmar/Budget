using System.Threading.Tasks;
using Budget.ObjectModel;
using Budget.Utils.Extensions;

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
            UserPassword userPassword = new UserPassword(login, password.ToMD5String());

            User user = await this.userProvider.FindUser(userPassword);
            LoginAttempt attempt = new LoginAttempt(user);

            return attempt;
        }
    }
}
