using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private BaseDBContext db
        {
            get
            {
                object obj = CallContext.GetData("BaseDBContext");
                if (obj == null)
                {
                    obj = new BaseDBContext();
                    CallContext.SetData("BaseDBContext", obj);
                }

                return obj as BaseDBContext;
            }
        }

        private DbSet<TEntity> _dbSet;

        public BaseRepository()
        {
            _dbSet = db.Set<TEntity>();
        }
        #region 查询相关方法

        public List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] TableNames)
        {
            if (TableNames.Any())
            {
                throw new Exception("连表操作的表名称至少要有一个");
            }

            DbQuery<TEntity> query = _dbSet;
            foreach (var tableName in TableNames)
            {
                query = query.Include(tableName);
            }

            return query.Where(where).ToList();
        }

        public List<TEntity> QueryOrderBy(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, bool>> order)
        {
            return _dbSet.Where(where).OrderBy(order).ToList();
        }
        public List<TEntity> QueryOrderByDescending<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> order)
        {
            return _dbSet.Where(where).OrderByDescending(order).ToList();
        }

        public List<TEntity> QueryByPage<TKey>(int pageindex, int pagesize, out int rowcount, Expression<Func<TEntity, TKey>> order, Expression<Func<TEntity, bool>> where)
        {
            //1.0 计算当前分页要跳过的数据行数
            int skipCount = (pageindex - 1) * pagesize;

            //2.0 获取当前满足条件的所有数据总条数
            rowcount = _dbSet.Count(where);

            //3.0 获取分页数据
            return _dbSet.Where(where).OrderByDescending(order).Skip(skipCount).Take(pagesize).ToList();
        }
        #endregion

        #region 3.0  编辑相关方法

        public void Edit(TEntity model, string[] propertys)
        {
            if (model == null)
            {
                throw new Exception("实体不能为空");
            }

            if (propertys.Any() == false)
            {
                throw new Exception("要修改的属性至少要有一个");
            }

            //2.0 将model追击到EF容器
            System.Data.Entity.Infrastructure.DbEntityEntry entry = db.Entry(model);

            entry.State = EntityState.Unchanged;
            foreach (var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }

            //3.0 关闭EF对于实体的合法性验证参数
            db.Configuration.ValidateOnSaveEnabled = false;
        }
        /// <summary>
        /// 更改实体信息
        /// </summary>
        /// <param name="model"></param>
        public void Update(TEntity model)
        {
            _dbSet.Attach(model);
            db.Entry<TEntity>(model).State = EntityState.Modified;
        }

        #endregion

        #region 4.0  删除相关方法

        public void Delete(TEntity model, bool isadded)
        {
            //(!isadded)表示当前model没有追加到EF容器中
            if (!isadded)
            {
                _dbSet.Attach(model);
            }
            _dbSet.Remove(model);
        }

        #endregion

        #region 5.0  新增相关方法

        public void Add(TEntity model)
        {
            _dbSet.Add(model);
        }

        public void AddRange(List<TEntity> models)
        {
            _dbSet.AddRange(models);
        }

        #endregion

        #region 6.0  统一提交

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void SaveChangesAsync()
        {
           db.SaveChanges();
        }

        public List<TEntity> QueryOrderBy<Tkey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, Tkey>> order)
        {
            return _dbSet.Where(where).OrderBy(order).ToList();
        }
        #endregion

    }
}