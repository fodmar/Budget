using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;
using Budget.WebApi.Client;
using NUnit.Framework;
using Rhino.Mocks;

namespace Budget.IntegrationTests.WebApi.Client
{
    [TestFixture]
    [Ignore]
    class CallUserApi
    {
        [Test]
        [Ignore]
        public async void GetUser()
        {
            UserClient client = this.CreateClient();
            User result = await client.FindUser(new UserPassword("marcin", "d5fad0cda8f1079681ec510bb20a586c"));
        }

        private UserClient CreateClient()
        {
            var configurationProvider = MockRepository.GenerateStub<IConfigurationProvider>();
            configurationProvider.Stub(s => s.BudgetApiUrl).Return(@"http://localhost:19808/");

            var headersProvider = MockRepository.GenerateStub<IHeadersProvider>();
            headersProvider.Stub(s => s.CorrelationId).Return(Guid.Parse("AAAAFFFF-0000-0000-0000-000000000000"));

            return new UserClient(configurationProvider, headersProvider);
        }
    }
}
