using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        Expression<Func<T, object>> Orderby { get; }
        Expression<Func<T, object>> OrderbyDescending { get; }
        List<Expression<Func<T, object>>> Include { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnable { get; }
    }
}
