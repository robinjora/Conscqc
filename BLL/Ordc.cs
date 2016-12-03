using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ZGZY.BLL
{
    /// <summary>
    /// 合同加价（BLL）
    /// </summary>
    public class Ordc
    {
        private static readonly ZGZY.IDAL.IOrdc dal = ZGZY.DALFactory.Factory.GetOrdcDAL();

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
            else {
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
        /// 添加合同加价ordc
        /// </summary>
        public int AddOrdc(Model.ordc ordc)
        {
            return dal.AddOrdc(ordc);
        }

        /// <summary>
        /// 修改合同
        /// </summary>
        public bool EditOrdc(Model.ordc ordc)
        {
            return dal.EditOrdc(ordc);
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        public bool DeleteOrdc(string compid, string factid, string ordid, string addid)
        {
            return dal.DeleteOrdc(compid, factid, ordid, addid);
        }

        /// <summary>
        /// 新增数据验证
        /// </summary>
        public void AddBeforeSave(Model.ordc ordc,int rownumber)
        {
            //检测合同方量
            if (! new ZGZY.BLL.Dddw().IfAddidExist(ordc.addid))
            {
                throw new Exception("加价代号不存在！|" + rownumber.ToString() + "|Y");
            }

            //检测合同方量
            if (ordc.addmoney <= 0)
            {
                throw new Exception("加价金额需大于0！|" + rownumber.ToString() + "|Y");
            }
        }

        /// <summary>
        /// 通用数据验证
        /// </summary>
        public void BeforeSave(Model.ordc ordc,int rownumber)
        {
            //检测合同方量
            if (ordc.addmoney <= 0)
            {
                throw new Exception("第[" + rownumber.ToString() + "]笔数据,加价金额需大于0！|" + rownumber.ToString());
            }
        }
    }
}
