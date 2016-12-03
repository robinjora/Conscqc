using System;
using System.Data;
using System.Collections.Generic;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 企业接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IDddw
    {

        /// <summary>
        /// 企业下拉数据
        /// </summary>
        DataTable GetDwFactory(string where);

        /// <summary>
        /// 混凝土标记下拉数据
        /// </summary>
        DataTable GetDwSpec(string where);

        /// <summary>
        /// 强度下拉数据
        /// </summary>
        DataTable GetDwStrength(string where);

        /// <summary>
        /// 龄期
        /// </summary>
        DataTable GetDwDays();

        /// <summary>
        /// 合同类别下拉数据
        /// </summary>
        DataTable GetDwOrdtype(string where);

        /// <summary>
        /// 合同下拉数据
        /// </summary>
        DataTable GetDwOrdid(string where);

        /// <summary>
        /// 机别下拉数据
        /// </summary>
        DataTable GetDwBujino();

        /// <summary>
        /// 职位下拉数据
        /// </summary>
        DataTable GetDwPosid();

        /// <summary>
        /// 检测类别下拉数据
        /// </summary>
        DataTable GetDwSubcategory();

        /// <summary>
        /// 加价ID（addid）下拉数据
        /// </summary>
        DataTable GetDwAddid(string where);

        /// <summary>
        /// 加价ID（addid）是否存在
        /// </summary>
        bool IfAddidExist(string addid);

        /// <summary>
        /// 客户代号（custid）下拉数据
        /// </summary>
        DataTable GetDwCustid(string where);

        /// <summary>
        /// 员工代号（empid）下拉数据
        /// </summary>
        DataTable GetDwEmpid(string where);

        /// <summary>
        /// 执行sp_cqcp590203_web
        /// </summary>
        DataTable ExportSP(string spname, string[] sparasname, string[] sparas);

    }
}
