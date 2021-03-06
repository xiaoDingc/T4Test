﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IServices;
using Repository;


namespace Services
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        //1.0 定义数据仓储的接口
        public IBaseRepository<TEntity> baseDal;

        #region 2.0  查询相关方法

        /// <summary>
        /// 根据labmda表达式进行查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where)
        {
            return baseDal.QueryWhere(where);
        }

        /// <summary>
        /// 连表操作
        /// </summary>
        /// <param name="where"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] tableNames)
        {
            return baseDal.QueryJoin(where, tableNames);
        }

        /// <summary>
        /// 按照条件查询出数据以后，根据外部指定的字段进行升序排列
        /// </summary>
        /// <typeparam name="TKey">表示从TEntity中获取的属性类型</typeparam>
        /// <param name="where">条件</param>
        /// <param name="order">排序lambda表达式</param>
        /// <returns></returns>
        public List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> order)
        {
            return baseDal.QueryOrderBy(where, order);
        }

        /// <summary>
        /// 按照条件查询出数据以后，根据外部指定的字段进行倒序排列
        /// </summary>
        /// <typeparam name="TKey">表示从TEntity中获取的属性类型</typeparam>
        /// <param name="where">条件</param>
        /// <param name="order">排序lambda表达式</param>
        /// <returns></returns>
        public List<TEntity> QueryOrderByDescending<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> order)
        {
            return baseDal.QueryOrderByDescending(where, order);
        }

        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="TKey">要指定的排序属性名称 Tentity.property</typeparam>
        /// <param name="pageindex">分页页码</param>
        /// <param name="pagesize">页容量</param>
        /// <param name="rowcount">总行数</param>
        /// <param name="order">排序lambda表达式</param>
        /// <param name="where">查询条件lambda表达式</param>
        /// <returns></returns>
        public List<TEntity> QueryByPage<TKey>(int pageindex, int pagesize, out int rowcount, Expression<Func<TEntity, TKey>> order, Expression<Func<TEntity, bool>> where)
        {
            return baseDal.QueryByPage(pageindex, pagesize, out rowcount, order, where);
        }

        #endregion

        #region 3.0  编辑相关方法

        public void Edit(TEntity model, string[] propertys)
        {
            baseDal.Edit(model, propertys);
        }
        public void Update(TEntity model)
        {
            baseDal.Update(model);
        }
        #endregion

        #region 4.0  删除相关方法

        public void Delete(TEntity model, bool isadded)
        {
            baseDal.Delete(model, isadded);
        }

        #endregion

        #region 5.0  新增相关方法

        public void Add(TEntity model)
        {
            baseDal.Add(model);
        }

        public void AddRange(List<TEntity> models)
        {
            baseDal.AddRange(models);
        }


        #endregion

        #region 6.0  统一提交

        public void SaveChanges()
        {
            baseDal.SaveChanges();
        }


        public void SaveChangesAsync()
        {
            baseDal.SaveChangesAsync();
        }


        #endregion
    }
}
