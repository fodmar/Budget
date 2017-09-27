using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public interface IFinder<T> where T : IIdentifiable
    {
        Task<T> GetById(int id);
    }
}
