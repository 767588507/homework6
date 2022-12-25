
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
        #region 添加学生
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="newStu">学生</param>
        /// <returns>返回bool值</returns>
        public bool AddStudent(Student newStu)
        {
            return stu.AddStudent(newStu);
        }
        #endregion
        #region 修改学生信息
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="s">学生</param>
        /// <returns>返回bool值</returns>
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