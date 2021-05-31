using OnliceShoppingStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnliceShoppingStore.Repository
{
    public class GenericUnitOfWork:IDisposable
    {
        private dbMyOnlineShoppingEntities DBEntity = new dbMyOnlineShoppingEntities();
        public IRepository<Tbl_EntityType> GetRepositoryInstance<Tbl_EntityType>() where Tbl_EntityType : class
        {
            return new GenericRepository<Tbl_EntityType>(DBEntity); 
        }
        public void SaveChanges()
        {
            DBEntity.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DBEntity.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}