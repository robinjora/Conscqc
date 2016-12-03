using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 二维码验证（SQL Server数据库实现）
    /// </summary>
    public class QRcode : ZGZY.IDAL.IQRcode
    {
        /// <summary>
        /// 任务单MD5验证
        /// </summary>
        public DataTable ConfirmQRcode(string qrCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select factory.factname,
	                       left(shipdate, 4) + '-' +substring(shipdate,5,2) +'-' + right(shipdate, 2) as shipdate,
	                       isnull(custname,'') as custname,
	                       isnull(engname,'') as engname,
	                       isnull(workpart,'') as workpart,
	                       isnull(spec,'') as strength,
	                       cast(isnull(ph17,0) as decimal(17,1)) as ph17
                            from shiph h join factory on (h.factid = factory.factid)
                            where ([dbo].[f_getsctspecstr](h.factid+'-'+h.shipid, 'MD5')) like '%" + qrCode + "%'");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }
    }
}
