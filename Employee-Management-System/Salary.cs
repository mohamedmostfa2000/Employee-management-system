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
    public partial class Salary : Form
    {
        Functions Con;
        public Salary()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSalaryList();
            GetEmployees();
        }

        private void ShowSalaryList()
        {
            string Query = "Select * from SalaryTbl";
            SalaryList.DataSource = Con.GetData(Query);
        }
         private void GetEmployees()
        {
            string Query = "Select * from EmployeeTbl";
            EmpCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpCb.DataSource = Con.GetData(Query);
        }

    }
}
