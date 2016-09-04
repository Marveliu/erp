using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Demo.DAL
{
    public partial class proc_BOM
    {
        public proc_BOM()
        { }
        
        public int proc_IsNesting(string location, string materialNO)
        {
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@location", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@materialNO", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@result", SqlDbType.Int) 
			 			 };
            parameters[0].Value = location;
            parameters[1].Value = materialNO;
            parameters[2].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("proc_IsNesting", parameters).Close();
            return int.Parse(parameters[2].Value.ToString());
        }

        public DataSet proc_reverseSearch_BOM(int reverseLevel, string materialNO)
        {
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@reverseLevel", SqlDbType.Int), 
			 			 new SqlParameter("@materialNO", SqlDbType.NVarChar,64) 
			 			 };
            parameters[0].Value = reverseLevel;
            parameters[1].Value = materialNO;
            return DbHelperSQL.RunProcedure("proc_reverseSearch_BOM", parameters,"Result");
        }

        public DataSet proc_search_BOM(string materialNO)
        {
            SqlParameter[] parameters = {
			 			 new SqlParameter("@materialNO", SqlDbType.NVarChar,64) 
			 			 };
            parameters[0].Value = materialNO;
            return DbHelperSQL.RunProcedure("proc_search_BOM", parameters, "Result");
        }
    } 
}
