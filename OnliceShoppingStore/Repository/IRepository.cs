using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OnliceShoppingStore.Repository
{
    public interface IRepository<Tbl_Entity> where Tbl_Entity: class
    {
        IEnumerable<Tbl_Entity> GetAllRecords();
        IQueryable<Tbl_Entity> GetAllRecordsIQueryable();
        int GetAllRecordCount();
        void Add(Tbl_Entity entity);
        void Update(Tbl_Entity entity);
        void UpdateByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPridict);
        Tbl_Entity GetFirstoreDefault(int recordId);
        void Remove(Tbl_Entity entity);
        void RemoveByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict);
        void RemoveRangeByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict);
        void InactiveAndDeleteMarkByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPridict);
        Tbl_Entity GetFirstorDefaultByParamater(Expression<Func<Tbl_Entity, bool>> wherePredict);
        IEnumerable<Tbl_Entity> GetListParamater(Expression<Func<Tbl_Entity, bool>> wherePredict);
        IEnumerable<Tbl_Entity> GetResultBySqlProcedure(string query, params object[] paramaters);
        IEnumerable<Tbl_Entity> GetRecordToShow(int PageNo, int PageSize, int CurrentPage, Expression<Func<Tbl_Entity, bool>> wherePredict, Expression<Func<Tbl_Entity, int>>orderByPredict);
    }
}