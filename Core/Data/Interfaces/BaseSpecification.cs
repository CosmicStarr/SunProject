﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Include { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> Orderby { get; private set; }

        public Expression<Func<T, object>> OrderbyDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }
        public bool IsPagingEnable { get; private set; }
        protected void ApplyPaging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnable = true;
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Include.Add(includeExpression);
        }

        protected void AddOrderby(Expression<Func<T, object>> orderbyExpression)
        {
            Orderby = orderbyExpression;
        }
        protected void AddOrderbyDescending(Expression<Func<T, object>> orderbyDescedExpression)
        {
            OrderbyDescending = orderbyDescedExpression;
        }
    }
}
