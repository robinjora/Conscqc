using System.Collections.Generic;
using System.Data;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 合同接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IOrdh
    {
        /// <summary>
        /// 获取新增合同ID:ordid
        /// </summary>
        string GetNewOrdid(string factid, string date);

        /// <summary>
        /// 添加合同
        /// </summary>
        int AddOrdh(ZGZY.Model.ordh ordh);

        /// <summary>
        /// 修改合同
        /// </summary>
        bool EditOrdh(ZGZY.Model.ordh ordh);

        /// <summary>
        /// 删除合同
        /// </summary>
        bool DeleteOrdh(string compid, string factid, string ordid);

        /// <summary>
        /// 根据ID获取合同
        /// </summary>
        Model.ordh GetOrdhById(string compid, string factid, string ordid);

    }
}
