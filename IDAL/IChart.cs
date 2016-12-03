using System;
using System.Data;
using System.Collections.Generic;

namespace ZGZY.IDAL
{
    public interface IChart
    {
        /// <summary>
        /// 获取半年内月份
        /// </summary>
        DataTable GetChartMonth();

        /// <summary>
        /// 获取企业
        /// </summary>
        DataTable GetChartFact();

        /// <summary>
        /// Chart1数据
        /// </summary>
        DataTable GetChart1Data();

        /// <summary>
        /// Chart2数据
        /// </summary>
        DataTable GetChart2Data();

        /// <summary>
        /// cqcp590408 企业数据
        /// </summary>
        DataTable cqcp590408GetData(string factid, string userid);

        /// <summary>
        /// cqcp590408 总数据
        /// </summary>
        DataTable cqcp590408GetSum(string userid);
    }
}
