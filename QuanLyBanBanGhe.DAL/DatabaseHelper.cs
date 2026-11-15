using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanBanGhe.DAL
{
    public static class DatabaseHelper
    {
        private static readonly string defaultConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanBanGhe;Integrated Security=True;TrustServerCertificate=True;";

        public static string ConnectionString
        {
            get
            {
                ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["QuanLyBanBanGheDB"];
                if (setting != null && !string.IsNullOrWhiteSpace(setting.ConnectionString))
                {
                    return setting.ConnectionString;
                }
                return defaultConnectionString;
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static DataTable ExecuteQuery(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            if (p != null)
                            {
                                SqlParameter cloned = (SqlParameter)((ICloneable)p).Clone();
                                if (cloned.Value == null)
                                {
                                    cloned.Value = DBNull.Value;
                                }
                                cmd.Parameters.Add(cloned);
                            }
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable ExecuteQuery(string sql, SqlParameter[] parameters, SqlTransaction trans)
        {
            if (trans != null)
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(sql, trans.Connection, trans))
                {
                    AttachParameters(cmd, parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            return ExecuteQuery(sql, parameters);
        }

        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, SqlTransaction trans = null)
        {
            if (trans != null)
            {
                using (SqlCommand cmd = new SqlCommand(sql, trans.Connection, trans))
                {
                    AttachParameters(cmd, parameters);
                    return cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    AttachParameters(cmd, parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(string sql, SqlTransaction trans)
        {
            return ExecuteNonQuery(sql, null, trans);
        }

        public static object ExecuteScalar(string sql, SqlParameter[] parameters = null, SqlTransaction trans = null)
        {
            if (trans != null)
            {
                using (SqlCommand cmd = new SqlCommand(sql, trans.Connection, trans))
                {
                    AttachParameters(cmd, parameters);
                    return cmd.ExecuteScalar();
                }
            }

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    AttachParameters(cmd, parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static object ExecuteScalar(string sql, SqlTransaction trans)
        {
            return ExecuteScalar(sql, null, trans);
        }

        public static DataTable ExecuteReaderSP(string spName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AttachParameters(cmd, parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable ExecuteReaderSP(string spName, SqlParameter[] parameters, SqlTransaction trans)
        {
            if (trans != null)
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(spName, trans.Connection, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AttachParameters(cmd, parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
            return ExecuteReaderSP(spName, parameters);
        }

        public static int ExecuteNonQuerySP(string spName, SqlParameter[] parameters = null, SqlTransaction trans = null)
        {
            if (trans != null)
            {
                using (SqlCommand cmd = new SqlCommand(spName, trans.Connection, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AttachParameters(cmd, parameters);
                    return cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AttachParameters(cmd, parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuerySP(string spName, SqlTransaction trans)
        {
            return ExecuteNonQuerySP(spName, null, trans);
        }

        public static int ExecuteNonQuerySPTransaction(SqlTransaction transaction, string spName, SqlParameter[] parameters = null)
        {
            return ExecuteNonQuerySP(spName, parameters, transaction);
        }

        public static object ExecuteScalarSP(string spName, SqlParameter[] parameters = null, SqlTransaction trans = null)
        {
            if (trans != null)
            {
                using (SqlCommand cmd = new SqlCommand(spName, trans.Connection, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AttachParameters(cmd, parameters);
                    return cmd.ExecuteScalar();
                }
            }

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AttachParameters(cmd, parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static object ExecuteScalarSP(string spName, SqlTransaction trans)
        {
            return ExecuteScalarSP(spName, null, trans);
        }

        private static void AttachParameters(SqlCommand cmd, SqlParameter[] parameters)
        {
            if (parameters == null)
            {
                return;
            }

            foreach (SqlParameter p in parameters)
            {
                if (p != null)
                {
                    SqlParameter cloned = (SqlParameter)((ICloneable)p).Clone();
                    if (cloned.Value == null)
                    {
                        cloned.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(cloned);
                }
            }
        }

        public static string SinhMaTuDong(string tenBang, string tenCotKhoa, string prefix)
        {
            string cleanTable = tenBang.Replace("dbo.", "");
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_bang", cleanTable),
                new SqlParameter("@ten_cot", tenCotKhoa),
                new SqlParameter("@prefix", prefix)
            };
            object result = ExecuteScalarSP("sp_TienIch_SinhMaTuDong", parameters);
            return result != null ? result.ToString().Trim() : prefix + "0001";
        }
    }
}
