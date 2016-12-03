using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 客户（SQL Server数据库实现）
    /// </summary>
    public class Cust : ZGZY.IDAL.ICust
    {
        /// <summary>
        /// 检测custid是否存在
        /// </summary>
        public bool IfCustidExist(string custid)
        {
            string strSql;
            strSql = String.Format("select count(*) from cust where custid = '{0}'", custid);
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
