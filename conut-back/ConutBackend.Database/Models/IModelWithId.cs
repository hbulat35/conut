using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Database.Models
{
    public interface IModelWithId
    {
        int Id { get; set; }
    }
}
