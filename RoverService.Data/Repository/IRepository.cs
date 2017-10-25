using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverService.Data.Repository
{
    public interface IRepository<TEntity> 
    {
        TEntity GetById(object id);

        void Set(TEntity updatedDto);
    }
}
