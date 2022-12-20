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

        private void EditBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
