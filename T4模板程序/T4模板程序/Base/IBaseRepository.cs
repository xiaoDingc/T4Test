using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBaseRepository<TEntity>
    {

        #region 查询相关方法

        List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where);


        List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] TableNames);


        List<TEntity> QueryOrderBy<Tkey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, Tkey>> order);

        List<TEntity> QueryOrderByDescending<TKey>(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TKey>> order);


        List<TEntity> QueryByPage<TKey>(int pageindex, int pagesize, out int rowcount,
            Expression<Func<TEntity, TKey>> order, Expression<Func<TEntity, bool>> where);

        #endregion

        #region 3.0  编辑相关方法

        void Edit(TEntity model, string[] propertys);

        void Update(TEntity model);

        #endregion

        #region 4.0  删除相关方法

        void Delete(TEntity model, bool isadded);


        #endregion

        #region 5.0  新增相关方法

        void Add(TEntity model);


        void AddRange(List<TEntity> models);

        #endregion

        #region 6.0  统一提交

        void SaveChanges();

        void SaveChangesAsync();

        #endregion
    }
}
