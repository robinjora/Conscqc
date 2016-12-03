using System.Collections.Generic;
using System.Data;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 文件上传接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IFileUpload
    {
        /// <summary>
        /// 文件上传
        /// </summary>
        int AddFileUpload(Model.fileupload fileupload);
    }
}
