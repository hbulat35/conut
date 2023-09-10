using ConutBackend.Database;
using ConutBackend.Database.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Base.Services.Abstract
{
    public abstract class UpdateCommandBase<TModel, TDbModel> : IRequest<int>
        where TModel : class, IModel<TDbModel>, IModelWithId
        where TDbModel : class, IModelWithId
    {
        public TModel Model { get; set; }

        public abstract class Handler : IRequestHandler<UpdateCommandBase<TModel, TDbModel>, int>
        {
            protected readonly DatabaseContext _databaseContext;

            public Handler(DatabaseContext databaseContext)
            {
                _databaseContext = databaseContext;
            }

            public virtual async Task<int> Handle(UpdateCommandBase<TModel, TDbModel> request, CancellationToken cancellationToken)
            {
                var dbItem = await _databaseContext.Set<TDbModel>().SingleAsync(x => x.Id == request.Model.Id, cancellationToken);
                request.Model.BindFields(dbItem);
                _databaseContext.Entry(dbItem).State = EntityState.Modified;
                await _databaseContext.SaveChangesAsync();
                return dbItem.Id;
            }
        }
    }
}
