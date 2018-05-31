﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    /// <summary>
    /// 通用仓库接口
    /// </summary>
    /// <typeparam name="T">泛型实体类</typeparam>
    public interface IRepository<T> where T : class, new()
    {
        /// <summary>
        /// 根据主值查询单条数据
        /// </summary>
        /// <param name="pkValue">主键值</param>
        /// <returns>泛型实体</returns>
        T FindById(object pkValue);

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="predicate">条件表达式树</param>
        /// <param name="orderBy">排序</param>
        /// <returns>泛型实体集合</returns>
        IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "");

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="predicate">条件表达式树</param>
        /// <returns></returns>
        T FindByClause(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查询所有记录数
        /// </summary>
        /// <returns></returns>
        int FindCount();

        /// <summary>
        /// 根据条件查询条数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int FindCountByClause(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        long Insert(T entity);

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        bool Delete(T entity);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="predicate">过滤条件</param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteById(object id);

        /// <summary>
        /// 删除指定ID集合的数据(批量删除)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteByIds(object[] ids);

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="predicate">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">页面记录数</param>
        /// <returns></returns>
        IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20);
    }
}