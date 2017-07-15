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

            scenario.UserProvider.AssertWasCalled(p => p.FindUser(Arg<UserPassword>.Is.Anything));
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
            IUserProvider userProvider = MockRepository.GenerateStub<IUserProvider>();
            userProvider.Stub(s => s.FindUser(Arg<UserPassword>.Is.Anything)).WhenCalled(p =>
            {
                UserPassword password = (UserPassword)p.Arguments[0];
                User returnValue = null;

                if (password.UserLogin == "a" && password.Hash == "0CC175B9C0F1B6A831C399E269772661") // password: a
                {
                    returnValue = new User { Name = "A" };
                }

                p.ReturnValue = returnValue;
            });

            SecureString pass = new SecureString();
            pass.AppendChar('a');
            pass.MakeReadOnly();

            yield return new Scenario
            {
                UserProvider = userProvider,
                Login = "a",
                Password = pass,
                ExpectedUser = new User { Name = "A" }
            };

            yield return new Scenario
            {
                UserProvider = userProvider,
                Login = "b",
                Password = pass,
                ExpectedUser = null
            };
        }
    }
}
