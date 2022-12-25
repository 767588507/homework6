
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace TriStu.DAL
{
    public class DBHelper
    {
        //数据库连接字符串--记得改
        public static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\24040\source\repos\TriStu\TriStu\bin\Debug\StuDB.mdf;Integrated Security=True;Connect Timeout=30";
        //定义数据库连接对象
        public static SqlConnection conn = new SqlConnection(connString);

        #region 获取数据的方法
        /// <summary>
        /// 获取数据的方法
        /// </summary>
        /// <param name="sqlStr">select语句</param>
        /// <returns>返回DaraTable对象</returns>
        public static DataTable GetDataTable(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataAdapter dapt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dapt.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
        #region 获取数据的重载方法
        /// <summary>
        /// 获取数据的重载方法
        /// </summary>
        /// <param name="sqlStr">select语句</param>
        /// <param name="param">SqlParameter对象数组</param>
        /// <returns>返回DataTable对象</returns>
        public static DataTable GetDataTable(string sqlStr, SqlParameter[] param)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddRange(param);
                SqlDataAdapter dapt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dapt.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
        #region 执行更新方法
        /// <summary>
        /// 执行更新方法
        /// </summary>
        /// <param name="sqlStr">insert|update|delete语句</param>
        /// <returns>返回一个bool值</returns>
        public static bool ExcuteCommand(string sqlStr)
        {
            try
            {
                //conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
        #region 执行更新的重载方法
        /// <summary>
        /// 执行更新的重载方法
        /// </summary>
        /// <param name="sqlStr">insert|update|delete语句</param>
        /// <param name="param">SqlParameter对象数组</param>
        /// <returns>返回一个bool值</returns>
        public static bool ExcuteCommand(string sqlStr, SqlParameter[] param)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        public static bool ExcuteCommand(List<String> sqlStr, List<SqlParameter[]> param)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand();
            using (TransactionScope ts = new TransactionScope())
            {
                cmd.Connection = conn;
                conn.Open();
                try
                {
                    foreach (string item in sqlStr)
                    {
                        //设置命令类型为SQL文本命令
                        cmd.CommandType = CommandType.Text;
                        //设置对数据源执行的SQL语句
                        cmd.CommandText = item;
                        //添加参数
                        cmd.Parameters.AddRange(param[i]);
                        //执行SQL语句并返回受影响的行数
                        cmd.ExecuteNonQuery();
                        i++;
                    }
                    ts.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                    return false;
                }
                finally
                {
                    conn.Close();
                    sqlStr.Clear();
                }
            }
        }
    }
}