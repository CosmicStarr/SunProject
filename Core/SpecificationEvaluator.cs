using Core.Data.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{

        public class SpecificationEvaluator<TEntity> where TEntity : BaseClass
        {
            public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> Spec)
            {
                var query = inputQuery;
                if (Spec.Criteria != null)
                {
                    query = query.Where(Spec.Criteria);
                }
                if (Spec.Orderby != null)
                {
                    query = query.OrderBy(Spec.Orderby);
                }
                if (Spec.OrderbyDescending != null)
                {
                    query = query.OrderByDescending(Spec.OrderbyDescending);
                }
                if (Spec.IsPagingEnable)
                {
                    query = query.Skip(Spec.Skip).Take(Spec.Take);
                }
                query = Spec.Include.Aggregate(query, (current, include) => current.Include(include));
                return query;
            }
        }
    
}
