using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UOU.Online.BusinessLayer
{
    public class SqlFunctions
    {
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ToString();
        DataTable _dt;
        DataSet _ds;

        public SqlFunctions()
        {
            _dt = new DataTable();
        }

        public int executeNonQueryWithProc(string procName, params SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int executeNonQueryWithQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public object executeScalerWithQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
        public DataTable returnDTWithQuery_executeReader(string query)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                _dt = new DataTable();
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                _dt.Load(rd);
                return _dt;
            }
        }

        public object executeScalerWithProc(string procName, params SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        public DataTable returnDTWithProc_executeReader(string procName, params SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                _dt = new DataTable();
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                _dt.Load(rd);

                return _dt;
            }
        }
        public DataTable returnDTWithProc_adapter(string procName, params SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(procName, conStr);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        da.SelectCommand.Parameters.Add(p);
                    }
                }

                con.Open();
                da.Fill(_dt);

                return _dt;
            }
        }
        public DataSet returnDSWithProc_adapter(string procName, params SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(procName, conStr);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        da.SelectCommand.Parameters.Add(p);
                    }
                }

                con.Open();
                _ds = new DataSet();
                da.Fill(_ds);

                return _ds;
            }
        }
    }
}
