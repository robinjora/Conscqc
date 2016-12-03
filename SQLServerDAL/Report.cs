using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 报表sp
    /// </summary>
    public class Report : ZGZY.IDAL.IReport
    {
        public DataTable cqcp590101(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590101_st1(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590102(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590103(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590203(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[8],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[9],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[10],SqlDbType.Decimal),
                                   new SqlParameter(sparasname[11],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[12],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[13],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];
            paras[8].Value = sparas[8];
            paras[9].Value = sparas[9];
            paras[10].Value = Convert.ToDecimal(sparas[10]);
            paras[11].Value = sparas[11];
            paras[12].Value = sparas[12];
            paras[13].Value = sparas[13];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590205(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[8],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];
            paras[8].Value = sparas[8];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590206(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590209(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[8],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[9],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[10],SqlDbType.Decimal),
                                   new SqlParameter(sparasname[11],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[12],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[13],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[14],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[15],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[16],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];
            paras[8].Value = sparas[8];
            paras[9].Value = sparas[9];
            paras[10].Value = sparas[10];
            paras[11].Value = sparas[11];
            paras[12].Value = Convert.ToDecimal(sparas[12]);
            paras[13].Value = Convert.ToDecimal(sparas[13]);
            paras[14].Value = sparas[14];
            paras[15].Value = sparas[15];
            paras[15].Value = sparas[16];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590209_st1(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590301(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[8],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[9],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];
            paras[8].Value = sparas[8];
            paras[9].Value = sparas[9];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590302(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[8],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[9],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[10],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[11],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];
            paras[8].Value = sparas[8];
            paras[9].Value = sparas[9];
            paras[10].Value = sparas[10];
            paras[11].Value = sparas[11];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590303(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[8],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[9],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];
            paras[8].Value = sparas[8];
            paras[9].Value = sparas[9];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590401(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[8],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[9],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];
            paras[8].Value = sparas[8];
            paras[9].Value = sparas[9];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590402(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[8],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[9],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];
            paras[8].Value = sparas[8];
            paras[9].Value = sparas[9];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590405(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590407(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable cqcp590409(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable rpt585102dx141(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }

        public DataTable rpt585202dx141(string spname, string[] sparasname, string[] sparas)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter(sparasname[0],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[1],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[2],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[3],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[4],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[5],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[6],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[7],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[8],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[9],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[10],SqlDbType.Decimal),
                                   new SqlParameter(sparasname[11],SqlDbType.Decimal),
                                   new SqlParameter(sparasname[12],SqlDbType.Decimal),
                                   new SqlParameter(sparasname[13],SqlDbType.Decimal),
                                   new SqlParameter(sparasname[14],SqlDbType.Decimal),
                                   new SqlParameter(sparasname[15],SqlDbType.Decimal),
                                   new SqlParameter(sparasname[16],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[17],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[18],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[19],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[20],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[21],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[22],SqlDbType.Decimal),
                                   new SqlParameter(sparasname[23],SqlDbType.VarChar),
                                   new SqlParameter(sparasname[24],SqlDbType.Decimal)
                                   };
            paras[0].Value = sparas[0];
            paras[1].Value = sparas[1];
            paras[2].Value = sparas[2];
            paras[3].Value = sparas[3];
            paras[4].Value = sparas[4];
            paras[5].Value = sparas[5];
            paras[6].Value = sparas[6];
            paras[7].Value = sparas[7];
            paras[8].Value = sparas[8];
            paras[9].Value = sparas[9];
            paras[10].Value = Convert.ToDecimal(sparas[10]);
            paras[11].Value = Convert.ToDecimal(sparas[11]);
            paras[12].Value = Convert.ToDecimal(sparas[12]);
            paras[13].Value = Convert.ToDecimal(sparas[13]);
            paras[14].Value = Convert.ToDecimal(sparas[14]);
            paras[15].Value = Convert.ToDecimal(sparas[15]);
            paras[16].Value = sparas[16];
            paras[17].Value = sparas[17];
            paras[18].Value = sparas[18];
            paras[19].Value = sparas[19];
            paras[20].Value = sparas[20];
            paras[21].Value = sparas[21];
            paras[22].Value = Convert.ToDecimal(sparas[22]);
            paras[23].Value = sparas[23];
            paras[24].Value = Convert.ToDecimal(sparas[24]);

            DataTable dt = (DataTable)ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, spname, paras);

            return dt;
        }
    }
}
