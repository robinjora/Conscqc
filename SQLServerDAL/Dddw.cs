using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 企业（SQL Server数据库实现）
    /// </summary>
    public class Dddw : ZGZY.IDAL.IDddw
    {
        /// <summary>
        /// 企业下拉数据
        /// </summary>
        public DataTable GetDwFactory(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select factid,factname from factory");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where factid <> '99' " + where);
            }
            strSql.Append(" order by factid");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 混凝土标记下拉数据
        /// </summary>
        public DataTable GetDwSpec(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct spec from shiph");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            strSql.Append(" order by spec asc");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 强度下拉数据
        /// </summary>
        public DataTable GetDwStrength(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct strength from strength");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            strSql.Append(" order by strength asc");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 龄期下拉数据
        /// </summary>
        public DataTable GetDwDays()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select days from dayslist order by days");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 合同类别下拉数据
        /// </summary>
        public DataTable GetDwOrdtype(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 'ZZ' code, 'ALL' name union select code,name from  other ");
            strSql.Append(" WHERE other.otherid = 'C1'  AND other.useing = '1' ");
            strSql.Append(" order by code desc");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 合同下拉数据
        /// </summary>
        public DataTable GetDwOrdid(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ordid, ordh12 from consc.dbo.ordh");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 机别下拉数据
        /// </summary>
        public DataTable GetDwBujino()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct bujino from v_receibuji");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        public DataTable ExportSP(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        /// <summary>
        /// 职位下拉数据
        /// </summary>
        public DataTable GetDwPosid()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select posid,posname from position WHERE POSID IN ('1000','2000','3000','4000','4400') order by posid asc");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 检测类别下拉数据
        /// </summary>
        public DataTable GetDwSubcategory()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select subcategoryid,subcategoryname FROM subcategory WHERE categoryid = 'SAIT' order by subcategoryid asc");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 加价ID（addid）下拉数据
        /// </summary>
        public DataTable GetDwAddid(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select addid,addname,useing from t_add where useing = 'Y' ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" and " + where);
            }
            strSql.Append(" order by addid asc");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 加价ID（addid）是否存在
        /// </summary>
        public bool IfAddidExist(string addid)
        {
            string strSql;
            strSql = String.Format("select count(*) from t_add where addid = '{0}'", addid);
            if ((int)ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 客户代号（custid）下拉数据
        /// </summary>
        public DataTable GetDwCustid(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select custid,shortname,longname,empid from cust where useing = 'Y' ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" and " + where);
            }
            strSql.Append(" order by custid asc");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

        /// <summary>
        /// 员工代号（empid）下拉数据
        /// </summary>
        public DataTable GetDwEmpid(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select empid,empname from employee where 1=1 ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" and " + where);
            }
            strSql.Append(" order by empid asc");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }
    }
}
