using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriStu.Models;

namespace TriStu.DAL
{
    public class StuService
    {
        public List<Student> GetStudentList()
        {
            string sqlstr = "select * from T_Stu";
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            List<Student> list = new List<Student>();
            foreach (DataRow r in dt.Rows)
            {
                Student stu = new Student();
                stu.ID = int.Parse(r["ID"].ToString());
                stu.Name = r["name"].ToString();
                stu.Age = int.Parse(r["age"].ToString());
                list.Add(stu);
            }
            return list;
        }
        #region ���ѧ����Ϣ
        /// <summary>
        /// ���ѧ����Ϣ
        /// </summary>
        /// <param name="newStu">ѧ��</param>
        /// <returns>����boolֵ</returns>
        public bool AddStudent(Student newStu)
        {
            string sqlStr = "insert into T_Stu values(@ID,@name,@age)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID",newStu.ID),
                new SqlParameter("@name",newStu.Name),
                new SqlParameter("@age",newStu.Age)
            };
            return DBHelper.ExcuteCommand(sqlStr, param);
        }
        #endregion
        #region �޸�ѧ����Ϣ
        /// <summary>
        /// �޸�ѧ����Ϣ
        /// </summary>
        /// <param name="stu">ѧ��</param>
        /// <returns>����boolֵ</returns>
        public bool UpdateStudent(Student stu)
        {
            string sqlstr = "update T_Stu set name=@name,age=@age where ID=@id";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID",stu.ID),
                new SqlParameter("@name",stu.Name),
                new SqlParameter("@age",stu.Age)
            };
            return DBHelper.ExcuteCommand(sqlstr, param);
        }
        #endregion
        public bool DelStudent(int id)
        {
            List<String> strSqls = new List<string>();
            List<SqlParameter[]> param = new List<SqlParameter[]>();
            string strDeletel = "DELETE from T_Stu where ID=@id";

            strSqls.Add(strDeletel);
            SqlParameter[] param1 = new SqlParameter[]
            {
                new SqlParameter("@ID",id)
            };
            param.Add(param1);

            //������δ���뵽T_Sc�����ﲻɾ������������
            //string strDelete2 = "DELETE from T_Stu where Sno=@sno";
            //strSqls.Add(strDelete2);
            //SqlParameter[] param2 = new SqlParameter[]
            //{
            //    new SqlParameter("@sno",id)
            //};
            //param.Add(param2);

            return DBHelper.ExcuteCommand(strSqls, param);
        }
    }
}