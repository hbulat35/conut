using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Base.Filtering
{
    public class OrderingModel : SimpleOrderingModel
    {
        public List<SimpleOrderingModel>? OrderThen { get; set; }

    }

    public class SimpleOrderingModel
    {
        public string OrderBy { get; set; }
        public OrderDirection Direction { get; set; }
    }

    public enum OrderDirection
    {
        Ascending,
        Descending,
    }
}
