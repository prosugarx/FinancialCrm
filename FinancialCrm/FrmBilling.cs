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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBilList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title = cmbBillTitle.Text;
            decimal amount = decimal.Parse(cmbBillAmount.Text);
            string periot = cmbBillPeriot.Text;

            Bills bills = new Bills();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = periot;
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bie Şeklde Sisteme Eklendi" , "Fatura & Ödeme Sistemi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id=int.Parse(cmbBillId.Text);
            var removeValue = db.Bills.Find(id);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bie Şeklde Sistemden Silindi", "Fatura & Ödeme Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = cmbBillTitle.Text;
            decimal amount = decimal.Parse(cmbBillAmount.Text);
            string periot = cmbBillPeriot.Text;
            int id = int.Parse(cmbBillId.Text);
            var values=db.Bills.Find(id);

            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = periot;
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bie Şeklde Sistemde Güncellendi", "Fatura & Ödeme Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values2 = db.Bills.ToList();
            dataGridView1.DataSource = values2;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            this.Hide();
        }
    }
}
