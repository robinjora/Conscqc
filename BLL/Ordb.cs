using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ZGZY.BLL
{
    /// <summary>
    /// 合同强度（BLL）
    /// </summary>
    public class Ordb
    {
        private static readonly ZGZY.IDAL.IOrdb dal = ZGZY.DALFactory.Factory.GetOrdbDAL();

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columns">要取的列名（逗号分开）</param>
        /// <param name="order">排序</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="where">查询条件</param>
        /// <param name="totalCount">总记录数</param>
        public string GetPager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            DataTable dt = ZGZY.Common.SqlPagerHelper.GetPager(tableName, columns, order, pageSize, pageIndex, where, out totalCount);
            return ZGZY.Common.JsonHelper.ToJson(dt);
        }

        public string GetPagerFooter(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount, string sumName, out decimal sumValue)
        {
            DataTable dt = ZGZY.Common.SqlPagerHelper.GetPager(tableName, columns, order, pageSize, pageIndex, where, out totalCount);
            if (dt.Rows.Count > 0)
            {
                sumValue = (decimal)dt.Compute("sum(" + sumName + ")", "");
            }
            else
            {
                sumValue = 0;
            }
            return ZGZY.Common.JsonHelper.ToJson(dt);
        }

        public string GetPagerNewFooter(string tableName, string columns, string order, int pageSize, int pageIndex, string where, string columns2, out int totalCount, string sumName, out decimal sumValue)
        {
            DataTable dt = ZGZY.Common.SqlPagerHelper.GetPagerNew(tableName, columns, order, pageSize, pageIndex, where, columns2, out totalCount);
            if (dt.Rows.Count > 0)
            {
                sumValue = (decimal)dt.Compute("sum(" + sumName + ")", "");
            }
            else
            {
                sumValue = 0;
            }
            return ZGZY.Common.JsonHelper.ToJson(dt);
        }

        /// <summary>
        /// 添加合同强度ordb
        /// </summary>
        public int AddOrdb(Model.ordb ordb)
        {
            return dal.AddOrdb(ordb);
        }

        /// <summary>
        /// 修改合同强度
        /// </summary>
        public bool EditOrdb(Model.ordb ordb)
        {
            return dal.EditOrdb(ordb);
        }

        /// <summary>
        /// 删除合同强度
        /// </summary>
        public bool DeleteOrdb(string compid, string factid, string ordid, string stgid)
        {
            return dal.DeleteOrdb(compid, factid, ordid, stgid);
        }

        /// <summary>
        /// 通用数据验证
        /// </summary>
        public void BeforeSave(Model.ordb ordb)
        {
            
        }
    }
}
