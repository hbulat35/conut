using ConutBackend.Database.Models;
using ConutBackend.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConutBackend.Base.Filtering;
using Microsoft.EntityFrameworkCore;

namespace ConutBackend.Base.Services.Abstract
{
    public abstract class GetPagedQueryBase<TDbModel, TModel, TFilter>
        : IRequest<PagedResult<TModel>>
        where TModel : class
        where TDbModel : class
        where TFilter : class
    {
        public PagedQueryParams<TFilter> Query { get; set; }
    }

    public abstract class GetPagedQueryHandlerBase<TDbModel, TModel, TFilter, TRequest>
        : IRequestHandler<TRequest, PagedResult<TModel>>
        where TModel : class
        where TDbModel : class
        where TFilter : class
        where TRequest : GetPagedQueryBase<TDbModel, TModel, TFilter>
    {
        protected readonly DatabaseContext _databaseContext;

        public GetPagedQueryHandlerBase(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public virtual async Task<PagedResult<TModel>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var dbQuery = request.Query.Filter == null
                ? _databaseContext.Set<TDbModel>().AsNoTracking()
                : Filter(_databaseContext.Set<TDbModel>().AsNoTracking(), request.Query.Filter);
            return await request.Query.ApplyAsync(Select(dbQuery));
        }

        public abstract IQueryable<TModel> Select(IQueryable<TDbModel> query);

        public abstract IQueryable<TDbModel> Filter(IQueryable<TDbModel> query, TFilter filter);
    }
}
