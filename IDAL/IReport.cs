using System;
using System.Data;
using System.Collections.Generic;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 报表接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// 执行sp_cqcp590101_web_new
        /// </summary>
        DataTable cqcp590101(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590101_st1_web_new
        /// </summary>
        DataTable cqcp590101_st1(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590102_web_new
        /// </summary>
        DataTable cqcp590102(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590103_web_new
        /// </summary>
        DataTable cqcp590103(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590203_web_new
        /// </summary>
        DataTable cqcp590203(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590205_web_new
        /// </summary>
        DataTable cqcp590205(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590206_web_new
        /// </summary>
        DataTable cqcp590206(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590209_web_new
        /// </summary>
        DataTable cqcp590209(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590209_st1_web_new
        /// </summary>
        DataTable cqcp590209_st1(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590301_web_new
        /// </summary>
        DataTable cqcp590301(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590302_web_new
        /// </summary>
        DataTable cqcp590302(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590303_web_new
        /// </summary>
        DataTable cqcp590303(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590401_web_new
        /// </summary>
        DataTable cqcp590401(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590402_web_new
        /// </summary>
        DataTable cqcp590402(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590405_web_new
        /// </summary>
        DataTable cqcp590405(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590407_web_new
        /// </summary>
        DataTable cqcp590407(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_cqcp590409_web_new
        /// </summary>
        DataTable cqcp590409(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_webp585102_dx141
        /// </summary>
        DataTable rpt585102dx141(string spname, string[] sparasname, string[] sparas);

        /// <summary>
        /// 执行sp_webp585202_dx141
        /// </summary>
        DataTable rpt585202dx141(string spname, string[] sparasname, string[] sparas);
    }
}
