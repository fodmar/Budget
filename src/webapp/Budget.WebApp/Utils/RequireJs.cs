using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Budget.WebApp.Utils
{
    public static class RequireJs
    {
        public static IHtmlString Require(string path)
        {
            string scriptsPath = VirtualPathUtility.ToAbsolute("~/Scripts/");

            string script = string.Format(
                @"<script src='/Scripts/lib/require.js'></script>
                  <script>
                    require(['{0}require.config.js'], function () {{
                         require(['{1}'], function (module) {{
                             module.init();
                         }});
                    }});
                  </script>", scriptsPath, path);

            return new HtmlString(script);
        }
    }
}