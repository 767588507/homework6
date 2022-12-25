using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriStu.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student() { }
        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="name">姓名</param>
        /// <param name="age">年龄</param>
        public Student(int ID, string name, int age)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
        }
        #endregion
    }
}