using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Metadata.Providers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using Budget.WebApi.ModelBinders;
using NUnit.Framework;
using Rhino.Mocks;

namespace Budget.UnitTests.WebApi
{
    [TestFixture]
    class DateTimeFromUnixTimeStampBinderTests
    {
        [Test]
        public void BindModelTest()
        {
            Test("1499810400", typeof(DateTime), true, new DateTime(2017, 7, 12));
            Test("1499810400", typeof(DateTime?), true, new DateTime(2017, 7, 12));
            Test(string.Empty, typeof(DateTime), false, null);
            Test(string.Empty, typeof(DateTime?), false, null);
            Test("null", typeof(DateTime?), true, (DateTime?)null);
            Test("null", typeof(DateTime), false, null);
            Test("afd23", typeof(DateTime?), false, null);
            Test("fdsf", typeof(DateTime), false, null);
        }

        private void Test(object rawValue, Type currentType, bool expectedResult, DateTime? expectedModel)
        {
            DateTimeFromUnixTimeStampBinder binder = new DateTimeFromUnixTimeStampBinder();
            IValueProvider valueProvider = MockRepository.GenerateStub<IValueProvider>();
            ValueProviderResult valueResult = new ValueProviderResult(rawValue, rawValue.ToString(), CultureInfo.CurrentCulture);
            DataAnnotationsModelMetadataProvider metadataProvider = new DataAnnotationsModelMetadataProvider();

            valueProvider.Stub(s => s.GetValue(Arg<string>.Is.Anything)).Return(valueResult);

            ModelBindingContext context = new ModelBindingContext
            {
                ValueProvider = valueProvider,
                ModelMetadata = metadataProvider.GetMetadataForType(null, currentType)
            };

            bool result = binder.BindModel(null, context);

            Assert.AreEqual(result, expectedResult);
            Assert.AreEqual(expectedModel, context.Model);
        }
    }
}
