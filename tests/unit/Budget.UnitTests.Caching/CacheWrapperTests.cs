using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Budget.Caching;
using NUnit.Framework;
using Rhino.Mocks;

namespace Budget.UnitTests.Caching
{
    [TestFixture]
    public class CacheWrapperTests
    {
        public class Example
        {
        }

        public interface IExample
        {
            Task<Example> Example();
        }

        [Test]
        public async void ShouldKeepInCache()
        {
            string key = "key";
            IExample repo = MockRepository.GenerateMock<IExample>();
            repo.Stub(e => e.Example()).Return(Task<Example>.FromResult(new Example())).Repeat.Once();

            Func<Task<Example>> func = () =>
            {
                return repo.Example();
            };

            CacheWrapper cache = new CacheWrapper(MemoryCache.Default);
            Example result1 = await cache.GetOrPut(key, func);
            Example result2 = await cache.GetOrPut(key, func);

            Assert.AreSame(result1, result2);
            repo.AssertWasCalled(x => x.Example(), x => x.Repeat.Once());
            repo.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public async void ShouldThrowInvalidCast()
        {
            string key = "key";
            CacheWrapper cache = new CacheWrapper(MemoryCache.Default);

            Func<Task<Example>> func1 = () =>
            {
                return Task<Example>.FromResult(new Example());
            };

            Func<Task<int>> func2 = () =>
            {
                return Task<int>.FromResult(100);
            };

            Example result1 = await cache.GetOrPut(key, func1);
            int result2 = await cache.GetOrPut(key, func2);
        }
    }
}
