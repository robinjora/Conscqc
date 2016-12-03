using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZGZY.BLL
{
    /// <summary>
    /// 企业（BLL）
    /// </summary>
    public class Dddw
    {
        private static readonly ZGZY.IDAL.IDddw dal = ZGZY.DALFactory.Factory.GetDddwDAL();

        /// <summary>
        /// 企业下拉数据
        /// </summary>
        public string GetDwFactory(string where)
        {
            DataTable dt = dal.GetDwFactory(where);
            StringBuilder str = new StringBuilder();
            
            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{\"factid\":\"" + row["factid"].ToString() + "\",\"factname\":\"" + row["factname"].ToString() + "\"},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// 混凝土标记下拉数据
        /// </summary>
        public string GetDwSpec(string where)
        {
            DataTable dt = dal.GetDwSpec(where);
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{\"spec\":\"" + row["spec"].ToString() + "\"},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// 混凝土标记下拉数据
        /// </summary>
        public string GetDwStrength(string where)
        {
            DataTable dt = dal.GetDwStrength(where);
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{\"strength\":\"" + row["strength"].ToString() + "\"},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// 混凝土标记下拉数据
        /// </summary>
        public string GetDwDays()
        {
            DataTable dt = dal.GetDwDays();
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{\"days\":\"" + row["days"].ToString() + "\"},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// 合同类别下拉数据
        /// </summary>
        public string GetDwOrdtype(string where)
        {
            DataTable dt = dal.GetDwOrdtype(where);
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{\"code\":\"" + row["code"].ToString() + "\",\"name\":\"" + row["name"].ToString() + "\"},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// 合同下拉数据
        /// </summary>
        public string GetDwOrdid(string where)
        {
            DataTable dt = dal.GetDwOrdid(where);
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{\"ordid\":\"" + row["ordid"].ToString() + "\",\"ordh12\":\"" + row["ordh12"].ToString() + "\"},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// 机别下拉数据
        /// </summary>
        public string GetDwBujino()
        {
            DataTable dt = dal.GetDwBujino();
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{\"bujino\":\"" + row["bujino"].ToString() + "\"},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// 职位下拉数据
        /// </summary>
        public string GetDwPosid()
        {
            DataTable dt = dal.GetDwPosid();
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{\"posid\":\"" + row["posid"].ToString() + "\",\"posname\":\"" + row["posname"].ToString() + "\"},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// 检测类别下拉数据
        /// </summary>
        public string GetDwSubcategory()
        {
            DataTable dt = dal.GetDwSubcategory();
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{\"subcategoryid\":\"" + row["subcategoryid"].ToString() + "\",\"subcategoryname\":\"" + row["subcategoryname"].ToString() + "\"},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// 加价ID（addid）下拉数据
        /// </summary>
        public string GetDwAddid(string where)
        {
            DataTable dt = dal.GetDwAddid(where);
            return ZGZY.Common.JsonHelper.ToJson(dt);
        }

        /// <summary>
        /// 加价ID（addid）是否存在
        /// </summary>
        public bool IfAddidExist(string addid)
        {
            return dal.IfAddidExist(addid);
        }

        /// <summary>
        /// 客户代号（custid）下拉数据
        /// </summary>
        public string GetDwCustid(string where)
        {
            DataTable dt = dal.GetDwCustid(where);
            return ZGZY.Common.JsonHelper.ToJson(dt);
        }

        /// <summary>
        /// 员工代号（empid）下拉数据
        /// </summary>
        public string GetDwEmpid(string where)
        {
            DataTable dt = dal.GetDwEmpid(where);
            return ZGZY.Common.JsonHelper.ToJson(dt);
        }

        /// <summary>
        /// 执行sp_cqcp590203_web
        /// </summary>
        public DataTable ExportSP(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.ExportSP(spname, sparasname, sparas);
            return dt;
        }


        public string robintest()
        {
            string str = "select tel from factory where factid = 'JY'";
            string tel = "";
            DataTable dt = ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, str.ToString(), null);

            if (dt.Rows.Count > 0) {
                tel = (string)dt.Rows[0]["tel"];
            }

            return tel;
        }
    }
}
