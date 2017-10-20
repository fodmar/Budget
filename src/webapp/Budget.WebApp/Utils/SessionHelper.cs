using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Budget.ObjectModel;

namespace Budget.WebApp.Utils
{
    class SessionHelper : ISessionHelper
    {
        public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

        public User User
        {
            get
            {
                return this.Get<User>(SessionKeys.UserId);
            }
            set
            {
                this.Put(SessionKeys.UserId, value);
            }
        }

        protected T Get<T>(SessionKeys sessionKey)
        {
            return (T)HttpContext.Current.Session[sessionKey.ToString()];
        }

        protected void Put<T>(SessionKeys sessionKey, T item)
        {
            HttpContext.Current.Session.Add(sessionKey.ToString(), item);
        }
    }
}