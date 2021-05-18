using HollowMindsDev.BackEnd.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Interfaces
{
    public interface IRepository<TEntity, TPrimaryKey>
            where TEntity : Entity<TPrimaryKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById (TPrimaryKey id);
        void Insert(TEntity model);
        void Update(TEntity model);
        void Delete(TPrimaryKey id);
    }
}
