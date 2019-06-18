using System.Linq;
using OZBAY.Core.Entities;

namespace OZBAY.Core.DataAccess
{
    public interface IQueryableRepository<T> where T:class ,IEntity,new()
    {
        IQueryable<T> Table { get; }
    }
}
