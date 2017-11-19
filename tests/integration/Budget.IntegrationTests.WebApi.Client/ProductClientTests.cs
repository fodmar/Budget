﻿using System;
using Budget.ObjectModel;
using Budget.Utils.Http;
using Budget.WebApi.Client;
using NUnit.Framework;
using Rhino.Mocks;

namespace Budget.IntegrationTests.WebApi.Client
{
    [TestFixture]
    class ProductClientTests
    {
        [Test]
        [Ignore]
        public async void GetAll()
        {
            ProductClient client = this.CreateClient();
            var result = await client.ReadAll();
        }

        [Test]
        [Ignore]
        public async void Insert()
        {
            ProductClient client = this.CreateClient();
            var result = await client.Save(new Product { Id = 11111, Name = "dupb" });
        }

        [Test]
        [Ignore]
        public async void Update()
        {
            ProductClient client = this.CreateClient();
            await client.Update(new Product { Id = 8, Name = "dupc" });
        }

        [Test]
        [Ignore]
        public async void Delete()
        {
            ProductClient client = this.CreateClient();
            await client.Remove(new Product { Id = 10, Name = "dupx" });
        }

        private ProductClient CreateClient()
        {
            var configurationProvider = MockRepository.GenerateStub<IConfigurationProvider>();
            configurationProvider.Stub(s => s.BudgetApiUrl).Return(@"http://marcin-lenovo/budget/");

            var headersProvider = MockRepository.GenerateStub<IHeadersProvider>();
            headersProvider.Stub(s => s.CorrelationId).Return(Guid.Parse("AAAAFFFF-0000-1234-0000-000000000000"));

            IApiClient client = new ApiClient();

            return new ProductClient(client, configurationProvider, headersProvider);
        }
    }
}
