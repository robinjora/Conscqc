using System.Collections.Generic;
using System.Data;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 合同加价（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IOrdc
    {
        /// <summary>
        /// 添加合同加价
        /// </summary>
        int AddOrdc(ZGZY.Model.ordc ordc);

        /// <summary>
        /// 修改合同加价
        /// </summary>
        bool EditOrdc(ZGZY.Model.ordc ordc);

        /// <summary>
        /// 删除合同加价
        /// </summary>
        bool DeleteOrdc(string compid, string factid, string ordid, string addid);
    }
}
