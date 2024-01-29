using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EntityBase : IEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }
    }
}
