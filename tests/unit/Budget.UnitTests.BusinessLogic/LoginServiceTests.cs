using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Budget.BusinessLogic.UserManagement;
using Budget.ObjectModel;
using NUnit.Framework;
using Rhino.Mocks;

namespace Budget.UnitTests.BusinessLogic
{
    [TestFixture]
    class LoginServiceTests
    {
        [Test]
        [TestCaseSource("Generate")]
        public void LoginServiceTest(Scenario scenario)
        {
            LoginService loginService = new LoginService(scenario.UserProvider);

            LoginAttempt attempt = loginService.Login(scenario.Login, scenario.Password);

            if (scenario.ExpectedUser == null)
            {
                Assert.IsNull(attempt.User);
            }
            else
            {
                Assert.AreEqual(scenario.ExpectedUser.Name, attempt.User.Name);
            }
        }

        public class Scenario
        {
            public string Login { get; set; }

            public SecureString Password { get; set; }

            public IUserProvider UserProvider { get; set; }

            public User ExpectedUser { get; set; }
        }

        public IEnumerable<Scenario> Generate()
        {
            IUserProvider userProvider = new FakeUserProvider();

            SecureString password = new SecureString();
            password.AppendChar('a');
            password.MakeReadOnly();

            yield return new Scenario
            {
                UserProvider = userProvider,
                Login = "a",
                Password = password,
                ExpectedUser = new User { Name = "A" }
            };

            yield return new Scenario
            {
                UserProvider = userProvider,
                Login = "b",
                Password = password,
                ExpectedUser = null
            };
        }

        class FakeUserProvider : IUserProvider
        {
            public User FindUser(UserPassword password)
            {
                if (password.UserLogin == "a" && password.Hash == "0CC175B9C0F1B6A831C399E269772661") // password: a
	            {
                    return new User { Name = "A" };
	            }

                return null;
            }
        }
    }
}
