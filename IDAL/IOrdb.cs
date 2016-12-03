using System.Collections.Generic;
using System.Data;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 合同强度（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IOrdb
    {
        /// <summary>
        /// 添加合同强度
        /// </summary>
        int AddOrdb(ZGZY.Model.ordb ordb);

        /// <summary>
        /// 修改合同强度
        /// </summary>
        bool EditOrdb(ZGZY.Model.ordb ordb);

        /// <summary>
        /// 删除合同强度
        /// </summary>
        bool DeleteOrdb(string compid, string factid, string ordid, string stgid);
    }
}
