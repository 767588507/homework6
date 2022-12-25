
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace TriStu.DAL
{
    public class DBHelper
    {
        //���ݿ������ַ���--�ǵø�
        public static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\24040\source\repos\TriStu\TriStu\bin\Debug\StuDB.mdf;Integrated Security=True;Connect Timeout=30";
        //�������ݿ����Ӷ���
        public static SqlConnection conn = new SqlConnection(connString);

        #region ��ȡ���ݵķ���
        /// <summary>
        /// ��ȡ���ݵķ���
        /// </summary>
        /// <param name="sqlStr">select���</param>
        /// <returns>����DaraTable����</returns>
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
        #region ��ȡ���ݵ����ط���
        /// <summary>
        /// ��ȡ���ݵ����ط���
        /// </summary>
        /// <param name="sqlStr">select���</param>
        /// <param name="param">SqlParameter��������</param>
        /// <returns>����DataTable����</returns>
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
        #region ִ�и��·���
        /// <summary>
        /// ִ�и��·���
        /// </summary>
        /// <param name="sqlStr">insert|update|delete���</param>
        /// <returns>����һ��boolֵ</returns>
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
        #region ִ�и��µ����ط���
        /// <summary>
        /// ִ�и��µ����ط���
        /// </summary>
        /// <param name="sqlStr">insert|update|delete���</param>
        /// <param name="param">SqlParameter��������</param>
        /// <returns>����һ��boolֵ</returns>
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
                        //������������ΪSQL�ı�����
                        cmd.CommandType = CommandType.Text;
                        //���ö�����Դִ�е�SQL���
                        cmd.CommandText = item;
                        //��Ӳ���
                        cmd.Parameters.AddRange(param[i]);
                        //ִ��SQL��䲢������Ӱ�������
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