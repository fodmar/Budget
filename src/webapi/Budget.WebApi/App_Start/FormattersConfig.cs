using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Budget.WebApi
{
    public class FormattersConfig
    {
        public static void Configure(MediaTypeFormatterCollection formatters)
        {
            formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver
                {
                    IgnoreSerializableAttribute = true
                }
            };
        }
    }
}