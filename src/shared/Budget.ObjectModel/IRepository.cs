using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public interface IRepository<T> : IReader<T>, ISaver<T>, IUpdater<T>, IRemover<T>, IFinder<T> where T : IIdentifiable
    {
    }
}
