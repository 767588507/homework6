
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TriStu.BLL;
using TriStu.Models;

namespace TriStu
{
    public partial class Form1 : Form
    {
        StuManager stu = new StuManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = stu.GetStudentList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student newStu = new Student();
            newStu.ID = int.Parse(txtID.Text);
            newStu.Name = txtName.Text;
            newStu.Age = int.Parse(txtAge.Text);
            if (stu.AddStudent(newStu))
            {
                MessageBox.Show("��ӳɹ�");
                dataGridView1.DataSource = stu.GetStudentList();
            }
            else
            {
                MessageBox.Show("���ʧ��");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //�ж��Ƿ�ѡ��dataGridView1���һ��
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("��ѡ��һ�н��в���");
                return;
            }
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtAge.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //�ж��Ƿ�ѡ��dataGridView1���һ��
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("��ѡ��һ�н��в���");
                return;
            }
            Student newStu = new Student();
            newStu.ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            newStu.Name = txtName.Text;
            newStu.Age = int.Parse(txtAge.Text);

            //�����޸�
            if (stu.UpdateStudent(newStu))
            {
                MessageBox.Show("�޸ĳɹ�");
                dataGridView1.DataSource = stu.GetStudentList();
            }
            else
            {
                MessageBox.Show("�޸�ʧ��");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id;
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("��ѡ��һ�н��в���");
                return;
            }
            id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //ɾ��
            if (stu.DelStudent(id))
            {
                MessageBox.Show("ɾ���ɹ�");
                dataGridView1.DataSource = stu.GetStudentList();
                txtID.Text = "";
                txtName.Text = "";
                txtAge.Text = "";
            }
            else
            {
                MessageBox.Show("ɾ��ʧ��");
            }
        }
    }
}