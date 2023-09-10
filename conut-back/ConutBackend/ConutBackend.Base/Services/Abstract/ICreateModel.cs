using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Base.Services.Abstract
{
    public interface ICreateModel<TDbModel> : IModel<TDbModel>
    {
        TDbModel ToDbModel();
    }
}
