using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Repositories
{
    public class DbFactory
    {
        /// <summary>
        /// SqlSugarClient属性
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetSqlSugarClient()
        {
            var sqlSugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = DbConfig.ConnectionString,
                DbType = DbConfig.DbType,
                IsAutoCloseConnection = DbConfig.IsAutoCloseConnection,
                InitKeyType = InitKeyType.Attribute
            });

            return sqlSugarClient;
        }
    }
}
