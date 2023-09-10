using ConutBackend.Database.Models;
using ConutBackend.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Base.Services.Abstract
{
    public abstract class GetSingleQueryBase<TDbModel, TModel>
        : IRequest<TModel>
        where TModel : class
        where TDbModel : class, IModelWithId
    {
        public int Id { get; set; }
    }

    public abstract class GetSingleQueryHandlerBase<TDbModel, TModel, TRequest>
        : IRequestHandler<TRequest, TModel>
        where TModel : class
        where TDbModel : class, IModelWithId
        where TRequest : GetSingleQueryBase<TDbModel, TModel>
    {
        protected readonly DatabaseContext _databaseContext;

        public GetSingleQueryHandlerBase(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public virtual async Task<TModel> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var dbModel = await Select(_databaseContext.Set<TDbModel>().Where(x => x.Id == request.Id))
                .SingleAsync();
            return dbModel;
        }

        public abstract IQueryable<TModel> Select(IQueryable<TDbModel> query);
    }
}
