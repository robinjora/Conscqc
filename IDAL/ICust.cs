using System.Collections.Generic;
using System.Data;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 客户接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface ICust
    {
        /// <summary>
        /// 检测custid是否存在
        /// </summary>
        bool IfCustidExist(string custid);
    }
}
