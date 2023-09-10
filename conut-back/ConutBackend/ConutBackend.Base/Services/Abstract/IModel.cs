using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Base.Services.Abstract
{
    public interface IModel<TDbModel>
    {
        void BindFields(TDbModel model);
    }
}
