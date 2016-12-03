using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ZGZY.BLL
{
    /// <summary>
    /// 合同（BLL）
    /// </summary>
    public class Ordh
    {
        private static readonly ZGZY.IDAL.IOrdh dal = ZGZY.DALFactory.Factory.GetOrdhDAL();

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

        /// <summary>
        /// 获取新ordid
        /// </summary>
        public string GetNewOrdid(string factid, string date)
        {
            string str = dal.GetNewOrdid(factid,date);
            return str;
        }

        /// <summary>
        /// 添加合同ordh
        /// </summary>
        public int AddOrdh(Model.ordh ordh)
        {
            return dal.AddOrdh(ordh);
        }

        /// <summary>
        /// 修改合同
        /// </summary>
        public bool EditOrdh(Model.ordh ordh)
        {
            return dal.EditOrdh(ordh);
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        public bool DeleteOrdh(string compid, string factid, string ordid)
        {
            return dal.DeleteOrdh(compid, factid, ordid);
        }

        /// <summary>
        /// 根据ID获取合同
        /// </summary>
        public Model.ordh GetOrdhById(string compid, string factid, string ordid)
        {
            return dal.GetOrdhById(compid, factid, ordid);
        }

        /// <summary>
        /// 新增数据验证
        /// </summary>
        public void AddBeforeSave(Model.ordh ordh)
        {
            //检测合同代号是否已存在
            ZGZY.Model.ordh ordhCompare = dal.GetOrdhById(ordh.compid, ordh.factid, ordh.ordid);
            if (ordhCompare != null)
            {
                throw new Exception("已经存在此合同！");
            }
        }

        /// <summary>
        /// 通用数据验证
        /// </summary>
        public void BeforeSave(Model.ordh ordh)
        {
            //检测合同方量
            if (ordh.maxqty <= 0)
            {
                throw new Exception("合同方量需大于0！");
            }

            //检测客户代号是否存在
            if (!new ZGZY.BLL.Cust().IfCustidExist(ordh.custid))
            {
                throw new Exception("客户代号不存在！");
            }

            //检测员工代号是否存在
            if (!new ZGZY.BLL.Employee().IfEmpidExist(ordh.empid))
            {
                throw new Exception("业务员代号不存在！");
            }
        }
    }
}
