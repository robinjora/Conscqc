using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 文件上传（SQL Server数据库实现）
    /// </summary>
    public class FileUpload : ZGZY.IDAL.IFileUpload
    {
        /// <summary>
        /// 文件上传
        /// </summary>
        public int AddFileUpload(Model.fileupload fileupload)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into fileupload(compid,factid,ordid,filename,filetype,address)");
            strSql.Append(" values ");
            strSql.Append("(@compid,@factid,@ordid,@filename,'',@address)");
            strSql.Append(";SELECT 1 from fileupload where compid = @compid and factid = @factid and ordid = @ordid and filename=@filename");
            SqlParameter[] paras = { 
                                   new SqlParameter("@compid",fileupload.compid),
                                   new SqlParameter("@factid",fileupload.factid),
                                   new SqlParameter("@ordid",fileupload.ordid),
                                   new SqlParameter("@filename",fileupload.filename),
                                   new SqlParameter("@address",fileupload.address)
                                   };
            return Convert.ToInt32(ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras));
        }
    }
}
