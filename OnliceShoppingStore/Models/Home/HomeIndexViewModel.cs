using OnliceShoppingStore.DAL;
using OnliceShoppingStore.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnliceShoppingStore.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        dbMyOnlineShoppingEntities context = new dbMyOnlineShoppingEntities();
        public IEnumerable<Tbl_Product> ListOfProducts { get; set; }
        public HomeIndexViewModel CreatedModel(string search, int ? page)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@search", search??(object)DBNull.Value)
            };
            IEnumerable<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, 3);
            return new HomeIndexViewModel
            {
                ListOfProducts = data
            };
        }
    }
}