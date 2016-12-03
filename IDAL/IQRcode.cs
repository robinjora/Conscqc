using System;
using System.Data;
using System.Collections.Generic;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 二维码验证接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IQRcode
    {
        DataTable ConfirmQRcode(string qrCode);
    }
}
