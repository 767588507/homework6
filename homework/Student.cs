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
        #region ���췽��
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="name">����</param>
        /// <param name="age">����</param>
        public Student(int ID, string name, int age)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
        }
        #endregion
    }
}