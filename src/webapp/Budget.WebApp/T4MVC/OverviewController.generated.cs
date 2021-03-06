// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Budget.WebApp.Controllers
{
    public partial class OverviewController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected OverviewController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetReceipts()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetReceipts);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SaveReceipt()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SaveReceipt);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OverviewController Actions { get { return MVC.Overview; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Overview";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Overview";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Overview = "Overview";
            public readonly string GetReceipts = "GetReceipts";
            public readonly string SaveReceipt = "SaveReceipt";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Overview = "Overview";
            public const string GetReceipts = "GetReceipts";
            public const string SaveReceipt = "SaveReceipt";
        }


        static readonly ActionParamsClass_GetReceipts s_params_GetReceipts = new ActionParamsClass_GetReceipts();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetReceipts GetReceiptsParams { get { return s_params_GetReceipts; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetReceipts
        {
            public readonly string start = "start";
            public readonly string end = "end";
        }
        static readonly ActionParamsClass_SaveReceipt s_params_SaveReceipt = new ActionParamsClass_SaveReceipt();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SaveReceipt SaveReceiptParams { get { return s_params_SaveReceipt; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SaveReceipt
        {
            public readonly string saveModel = "saveModel";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Overview = "Overview";
                public readonly string SaveReceipt = "SaveReceipt";
                public readonly string SaveReceiptEntryModelTemplate = "SaveReceiptEntryModelTemplate";
                public readonly string SaveReceiptHeader = "SaveReceiptHeader";
            }
            public readonly string Overview = "~/Views/Overview/Overview.cshtml";
            public readonly string SaveReceipt = "~/Views/Overview/SaveReceipt.cshtml";
            public readonly string SaveReceiptEntryModelTemplate = "~/Views/Overview/SaveReceiptEntryModelTemplate.cshtml";
            public readonly string SaveReceiptHeader = "~/Views/Overview/SaveReceiptHeader.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_OverviewController : Budget.WebApp.Controllers.OverviewController
    {
        public T4MVC_OverviewController() : base(Dummy.Instance) { }

        [NonAction]
        partial void OverviewOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Overview()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Overview);
            OverviewOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void GetReceiptsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.DateTime start, System.DateTime end);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetReceipts(System.DateTime start, System.DateTime end)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetReceipts);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "start", start);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "end", end);
            GetReceiptsOverride(callInfo, start, end);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void SaveReceiptOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Budget.WebApp.Models.SaveReceiptModel saveModel);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SaveReceipt(Budget.WebApp.Models.SaveReceiptModel saveModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SaveReceipt);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "saveModel", saveModel);
            SaveReceiptOverride(callInfo, saveModel);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
