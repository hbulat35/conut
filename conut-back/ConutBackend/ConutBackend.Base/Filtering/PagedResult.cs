using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Base.Filtering
{
    public class PagedResult<TModel>
    {
        public List<TModel> Result { get; set; }
    }
}
