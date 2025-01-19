using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        int count = 0;
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString();

            var lastBankProcessAmount =db.BankProcesses.OrderByDescending(p => p.BankProcessId).Take(1).Select(x=>x.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString() + " ₺";

            var bankdata = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankdata)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            
            }

            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType=System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);

            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblTotalBalance_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            count++;

            if (count % 5 == 1)
            {
                var elektirikFaturası = db.Bills.Where(x => x.BillTitle == "Elektirik Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillAmount.Text = elektirikFaturası.ToString();
                lblBillTitle.Text = "Elektrik Faturası";

            }
            else if (count % 5 == 2)
            {
                var elektirikFaturası = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillAmount.Text = elektirikFaturası.ToString();
                lblBillTitle.Text = "Doğalgaz Faturası";

            }
            else if (count % 5 == 3)
            {
                var elektirikFaturası = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillAmount.Text = elektirikFaturası.ToString();
                lblBillTitle.Text = "Su Faturası";

            }
            else if (count % 5 == 4)
            {
                var elektirikFaturası = db.Bills.Where(x => x.BillTitle == "Telefon Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillAmount.Text = elektirikFaturası.ToString();
                lblBillTitle.Text = "Telefon Faturası";

            }
            else if (count % 5 == 0)
            {
                var elektirikFaturası = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillAmount.Text = elektirikFaturası.ToString();
                lblBillTitle.Text = "İnternet Faturası";

            }
        }

        private void lblLastBankProcessAmount_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
