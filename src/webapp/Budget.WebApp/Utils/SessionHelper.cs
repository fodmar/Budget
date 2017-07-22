using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budget.WebApp.Utils
{
    class SessionHelper : ISessionHelper
    {
        public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

        public int UserId
        {
            get
            {
                return this.Get<int>(SessionKeys.UserId);
            }
            set
            {
                this.Put(SessionKeys.UserId, value);
            }
        }

        protected T Get<T>(SessionKeys sessionKey)
        {
            return (T)HttpContext.Current.Session[(int)sessionKey];
        }

        protected void Put<T>(SessionKeys sessionKey, T item)
        {
            HttpContext.Current.Session.Add(((int)sessionKey).ToString(), item);
        }
    }
}