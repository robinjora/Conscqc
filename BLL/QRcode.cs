using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZGZY.BLL
{
    /// <summary>
    /// 企业（BLL）
    /// </summary>
    public class QRcode
    {
        private static readonly ZGZY.IDAL.IQRcode dal = ZGZY.DALFactory.Factory.GetQRcodeDAL();
        /// <summary>
        /// 企业下拉数据
        /// </summary>
        public string ConfirmQRcode(string qrCode)
        {
            DataTable dt = dal.ConfirmQRcode(qrCode);
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append(row["factname"].ToString() + "|" +
                               row["shipdate"].ToString() + "|" +
                               row["custname"].ToString() + "|" +
                               row["engname"].ToString() + "|" +
                               row["workpart"].ToString() + "|" +
                               row["strength"].ToString() + "|" +
                               row["ph17"].ToString());
                }
                //str.Append("[");
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    DataRow row = dt.Rows[i];
                //    str.Append("{\"factid\":\"" + row["factid"].ToString() + "\",\"factname\":\"" + row["factname"].ToString() + "\"},");
                //}

                //str.Remove(str.Length - 1, 1);
                //str.Append("]");
            }
            else
            {
                str.Append("none");
            }

            return str.ToString();
        }
    }
}
