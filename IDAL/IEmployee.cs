using System.Collections.Generic;
using System.Data;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 员工接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// 检测empid是否存在
        /// </summary>
        bool IfEmpidExist(string empid);
    }
}
