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
        int d = 0;
        int DSal = 0;
        private void GetSalary()
        {
            string Query = "Select * from EmployeeTbl where EmpId = {0} ";
            Query = string.Format(Query, EmpCb.SelectedValue.ToString());
            foreach (DataRow dr in Con.GetData(Query).Rows) 
            {
                DSal = Convert.ToInt32(dr["EmpSal"].ToString());
            
            }
            if (DaysTb.Text == "")
            {
                SalaryTb.Text = "Rs " + (d * DSal);
            }
            else if (Convert.ToInt32(DaysTb.Text) > 31)
            {
                MessageBox.Show("Days can not be greater than 31 days");
            }
            else
            {
                d = Convert.ToInt32(DaysTb.Text);
                SalaryTb.Text = "Rs " + (d * DSal);
            }
           
        }

        private void EmpCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSalary();
        }
        string Period = "";
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DaysTb.Text == "" || PeriodTb.Text == "" || EmpCb.SelectedIndex == -1 )
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Period = PeriodTb.Value.Date.Month.ToString() + "_" + PeriodTb.Value.Date.Year.ToString();
                    int Amount = DSal * Convert.ToInt32(DaysTb.Text);
                    int Days = Convert.ToInt32(DaysTb.Text);

                    string Query = "insert into SalaryTbl values({0},{1},'{2}',{3},'{4}')";
                    Query = string.Format(Query, EmpCb.SelectedValue.ToString(), Days, Period, Amount, DateTime.Today.Date);
                    Con.SetData(Query);
                    ShowSalaryList();
                    MessageBox.Show("Salary Paid");
                    DaysTb.Text = "";
                   
                    
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
