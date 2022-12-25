
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriStu.DAL;
using TriStu.Models;

namespace TriStu.BLL
{
    public class StuManager
    {
        StuService stu = new StuService();
        public List<Student> GetStudentList()
        {
            return stu.GetStudentList();
        }
        #region ���ѧ��
        /// <summary>
        /// ���ѧ��
        /// </summary>
        /// <param name="newStu">ѧ��</param>
        /// <returns>����boolֵ</returns>
        public bool AddStudent(Student newStu)
        {
            return stu.AddStudent(newStu);
        }
        #endregion
        #region �޸�ѧ����Ϣ
        /// <summary>
        /// �޸�ѧ����Ϣ
        /// </summary>
        /// <param name="s">ѧ��</param>
        /// <returns>����boolֵ</returns>
        public bool UpdateStudent(Student s)
        {
            return stu.UpdateStudent(s);
        }
        #endregion

        public bool DelStudent(int id)
        {
            return stu.DelStudent(id);
        }
    }
}