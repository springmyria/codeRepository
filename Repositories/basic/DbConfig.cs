using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class DbConfig
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionString; }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        private static readonly string _dbType = ConfigurationManager.AppSettings["DbType"].ToString().Trim();

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static SqlSugar.DbType DbType
        {
            get
            {
                if (_dbType.Equals("MySql"))
                {
                    return SqlSugar.DbType.MySql;
                }
                else if (_dbType.Equals("Oracle"))
                {
                    return SqlSugar.DbType.Oracle;
                }
                else if (_dbType.Equals("SqlServer"))
                {
                    return SqlSugar.DbType.SqlServer;
                }
                else
                {
                    return SqlSugar.DbType.Sqlite;
                }
            }
        }

        /// <summary>
        /// 是否自动关闭连接
        /// </summary>
        private static readonly string _isAutoCloseConnection = ConfigurationManager.AppSettings["IsAutoCloseConnection"].ToString().Trim().Length > 0 ? ConfigurationManager.AppSettings["IsAutoCloseConnection"].ToString().Trim() : "false";

        public static bool IsAutoCloseConnection
        {
            get { return Convert.ToBoolean(_isAutoCloseConnection); }
        }
    }
}
