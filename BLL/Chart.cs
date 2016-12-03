using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZGZY.BLL
{
    public class Chart
    {
        private static readonly ZGZY.IDAL.IChart dal = ZGZY.DALFactory.Factory.GetChartDAL();

        public string GetChartMonth()
        {
            DataTable dt = dal.GetChartMonth();
            return ZGZY.Common.JsonHelper.ToJson(dt);
        }

        public string GetChartFact()
        {
            DataTable dt = dal.GetChartFact();
            return ZGZY.Common.JsonHelper.ToJson(dt);
        }


        public string GetChart1Data()
        {
            DataTable dt = dal.GetChart1Data();
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{ name : '" + row["factname"].ToString() + 
                            "', data : [ " + row["ym1qty"].ToString() + 
                            " , " + row["ym2qty"].ToString() + 
                            " , " + row["ym3qty"].ToString() + 
                            " , " + row["ym4qty"].ToString() + 
                            " , " + row["ym5qty"].ToString() + 
                            " , " + row["ym6qty"].ToString() + "]},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        public string GetChart2Data()
        {
            DataTable dt = dal.GetChart2Data();
            StringBuilder str = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    str.Append("{ name : '" + row["qtytype"].ToString() +
                            "', data : [ " + row["f1qty"].ToString() +
                            " , " + row["f2qty"].ToString() +
                            " , " + row["f3qty"].ToString() + "], index:" + (dt.Rows.Count - i - 1).ToString() + "},");
                }

                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            return str.ToString();
        }

        /// <summary>
        /// cqcp590408 企业数据
        /// </summary>
        public string cqcp590408GetData(string factid,string userid)
        {
            DataTable dt = dal.cqcp590408GetData(factid, userid);
            StringBuilder str = new StringBuilder();

            DataRow[] rows = dt.Select();

            if (rows.Length > 0)
            {
                str.Append("{\"factid\":\"" + rows[0]["factid"].ToString() +
                                "\",\"factname\":\"" + rows[0]["factname"].ToString() +
                                "\",\"bujino_count\":\"" + rows[0]["bujino_count"].ToString() +
                                "\",\"bujino1\":\"" + rows[0]["bujino1"].ToString() +
                                "\",\"bujidayqty1\":\"" + rows[0]["bujidayqty1"].ToString() +
                                "\",\"bujimonqty1\":\"" + rows[0]["bujimonqty1"].ToString() +
                                "\",\"bujistate1\":\"" + rows[0]["bujistate1"].ToString() +
                                "\",\"bujino2\":\"" + rows[0]["bujino2"].ToString() +
                                "\",\"bujidayqty2\":\"" + rows[0]["bujidayqty2"].ToString() +
                                "\",\"bujimonqty2\":\"" + rows[0]["bujimonqty2"].ToString() +
                                "\",\"bujistate2\":\"" + rows[0]["bujistate2"].ToString() +
                                "\",\"bujino3\":\"" + rows[0]["bujino3"].ToString() +
                                "\",\"bujidayqty3\":\"" + rows[0]["bujidayqty3"].ToString() +
                                "\",\"bujimonqty3\":\"" + rows[0]["bujimonqty3"].ToString() +
                                "\",\"bujistate3\":\"" + rows[0]["bujistate3"].ToString() +
                                "\",\"bujino4\":\"" + rows[0]["bujino4"].ToString() +
                                "\",\"bujidayqty4\":\"" + rows[0]["bujidayqty4"].ToString() +
                                "\",\"bujimonqty4\":\"" + rows[0]["bujimonqty4"].ToString() +
                                "\",\"bujistate4\":\"" + rows[0]["bujistate4"].ToString() +
                                "\",\"bujino5\":\"" + rows[0]["bujino5"].ToString() +
                                "\",\"bujidayqty5\":\"" + rows[0]["bujidayqty5"].ToString() +
                                "\",\"bujimonqty5\":\"" + rows[0]["bujimonqty5"].ToString() +
                                "\",\"bujistate5\":\"" + rows[0]["bujistate5"].ToString() +
                                "\",\"factdayqty\":\"" + rows[0]["factdayqty"].ToString() +
                                "\",\"factmonqty\":\"" + rows[0]["factmonqty"].ToString() +
                                "\",\"maxbujino\":\"" + rows[0]["maxbujino"].ToString() +
                                "\",\"factstate\":\"" + rows[0]["factstate"].ToString());
                str.Append("\"}");
            }
            return str.ToString();
        }

        /// <summary>
        /// cqcp590408 总数据
        /// </summary>
        public string cqcp590408GetSum(string userid)
        {
            DataTable dt = dal.cqcp590408GetSum(userid);
            StringBuilder str = new StringBuilder();

            DataRow[] rows = dt.Select();

            if (rows.Length > 0)
            {
                str.Append("{\"compname\":\"" + rows[0]["compname"].ToString() +
                           "\",\"dayqty\":\"" + rows[0]["dayqty"].ToString() +
                           "\",\"monqty\":\"" + rows[0]["monqty"].ToString());
                str.Append("\"}");
            }
            return str.ToString();
        }
    }
}
