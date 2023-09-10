using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Base.Filtering
{
    public class PagedQueryParams<TFilter>
    {
        public TFilter? Filter { get; set; }
        public PagingModel Paging { get; set; } = new PagingModel
        {
            Count = 10,
            Page = 0
        };
        public OrderingModel? Order { get; set; }

        public async Task<PagedResult<TModel>> ApplyAsync<TModel>(IQueryable<TModel> query)
        {
            return new PagedResult<TModel>
            {
                Result = await ApplyPaging(ApplyOrdering(query)).ToListAsync()
            };
        }

        public IQueryable<TDbModel> ApplyPaging<TDbModel>(IQueryable<TDbModel> dbQuery)
        {
            return dbQuery.Skip(Math.Max(Paging.Count, 1) * Math.Max(Paging.Page - 1, 0)).Take(Paging.Count);
        }

        public IQueryable<TDbModel> ApplyOrdering<TDbModel>(IQueryable<TDbModel> dbQuery)
        {
            if (Order != null)
            {
                dbQuery = Order.Direction == OrderDirection.Ascending
                    ? dbQuery.OrderBy(x => EF.Property<object>(x, Order.OrderBy))
                    : dbQuery.OrderByDescending(x => EF.Property<object>(x, Order.OrderBy));

                if (Order.OrderThen != null)
                {
                    foreach (var order in Order.OrderThen)
                    {
                        dbQuery = order.Direction == OrderDirection.Ascending
                            ? dbQuery.OrderBy(x => EF.Property<object>(x, order.OrderBy))
                            : dbQuery.OrderByDescending(x => EF.Property<object>(x, order.OrderBy));
                    }
                }
            }
            return dbQuery;
        }
    }
}
