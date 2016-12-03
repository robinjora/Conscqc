using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 员工（SQL Server数据库实现）
    /// </summary>
    public class Employee : ZGZY.IDAL.IEmployee
    {
        /// <summary>
        /// 检测empid是否存在
        /// </summary>
        public bool IfEmpidExist(string empid)
        {
            string strSql;
            strSql = String.Format("select count(*) from employee where empid = '{0}'", empid);
            if ((int)ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
