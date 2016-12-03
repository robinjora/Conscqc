using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZGZY.BLL
{
    /// <summary>
    /// 企业（BLL）
    /// </summary>
    public class Report
    {
        private static readonly ZGZY.IDAL.IReport dal = ZGZY.DALFactory.Factory.GetReportDAL();

        /// <summary>
        /// 执行sp_cqcp590101_web_new
        /// </summary>
        public DataTable cqcp590101(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590101(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590101_st1_web_new
        /// </summary>
        public DataTable cqcp590101_st1(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590101_st1(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590102_web_new
        /// </summary>
        public DataTable cqcp590102(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590102(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590103_web_new
        /// </summary>
        public DataTable cqcp590103(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590103(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590203_web_new
        /// </summary>
        public DataTable cqcp590203(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590203(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590205_web_new
        /// </summary>
        public DataTable cqcp590205(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590205(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590206_web_new
        /// </summary>
        public DataTable cqcp590206(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590206(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590209_web_new
        /// </summary>
        public DataTable cqcp590209(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590209(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590209_st1_web_new
        /// </summary>
        public DataTable cqcp590209_st1(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590209_st1(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590301_web_new
        /// </summary>
        public DataTable cqcp590301(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590301(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590302_web_new
        /// </summary>
        public DataTable cqcp590302(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590302(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590303_web_new
        /// </summary>
        public DataTable cqcp590303(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590301(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590401_web_new
        /// </summary>
        public DataTable cqcp590401(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590401(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590402_web_new
        /// </summary>
        public DataTable cqcp590402(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590402(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590405_web_new
        /// </summary>
        public DataTable cqcp590405(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590405(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590407_web_new
        /// </summary>
        public DataTable cqcp590407(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590407(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_cqcp590409_web_new
        /// </summary>
        public DataTable cqcp590409(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.cqcp590409(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_webp585102dx141
        /// </summary>
        public DataTable rpt585102dx141(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.rpt585102dx141(spname, sparasname, sparas);
            return dt;
        }

        /// <summary>
        /// 执行sp_webp585202dx141
        /// </summary>
        public DataTable rpt585202dx141(string spname, string[] sparasname, string[] sparas)
        {
            DataTable dt = dal.rpt585202dx141(spname, sparasname, sparas);
            return dt;
        }
    }
}
