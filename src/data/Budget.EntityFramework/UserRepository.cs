﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Budget.BusinessLogic.UserManagement;
using Budget.EntityFramework;
using Budget.ObjectModel;

namespace Budget.EntityFramework
{
    public class UserRepository : IUserProvider
    {
        private readonly IBudgetDatabase budgetDatabase;

        public UserRepository(IBudgetDatabase budgetDatabase)
        {
            this.budgetDatabase = budgetDatabase;
        }

        public async Task<User> FindUser(UserPassword password)
        {
            return await
                (from userPassword in this.budgetDatabase.Table<UserPassword>()
                 join user in this.budgetDatabase.Table<User>() on userPassword.UserId equals user.Id
                 where userPassword.UserLogin == password.UserLogin && userPassword.Hash == password.Hash
                 select user)
                 .SingleOrDefaultAsync();
        }
    }
}
