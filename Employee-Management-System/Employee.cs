using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    
    public partial class Employee : Form
    {
        Functions Con;
        public Employee()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmpList();
            GetDepartment();
        }

        private void ShowEmpList()
        {
            string Query = "Select * from EmployeeTbl";
            EmpList.DataSource = Con.GetData(Query);


        }

        private void GetDepartment()
        {
            string Query = "Select * from DepartmentTbl";
            DepCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Con.GetData(Query);
        }

       

        private void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || DailySalTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.Date.ToString();
                    string JDate = JDateTb.Value.Date.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);

                    string Query = "insert into EmployeeTbl values('{0}','{1}',{2},'{3}','{4}',{5})";
                    Query = string.Format(Query,Name,Gender,Dep,DOB,JDate,Salary);
                    Con.SetData(Query);
                    ShowEmpList();
                    MessageBox.Show("Employee Added");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int Key = 0;
        private void EmpList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmpList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.Text = EmpList.SelectedRows[0].Cells[2].Value.ToString();
            DepCb.SelectedValue = EmpList.SelectedRows[0].Cells[3].Value.ToString();
            DOBTb.Text = EmpList.SelectedRows[0].Cells[4].Value.ToString();
            JDateTb.Text = EmpList.SelectedRows[0].Cells[5].Value.ToString();
            DailySalTb.Text = EmpList.SelectedRows[0].Cells[6].Value.ToString();

            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmpList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || DailySalTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.Date.ToString();
                    string JDate = JDateTb.Value.Date.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);

                    string Query = "Update EmployeeTbl set EmpName = '{0}',EmpGen = '{1}',EmpDep = {2},EmpDOB = '{3}',EmpJDate = '{4}',EmpSal = {5} where EmpId ={6}";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, Salary,Key);
                    Con.SetData(Query);
                    ShowEmpList();
                    MessageBox.Show("Employee Updated");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                   
                    string Query = "Delete from EmployeeTbl where EmpId ={0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    ShowEmpList();
                    MessageBox.Show("Employee Deleted");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
