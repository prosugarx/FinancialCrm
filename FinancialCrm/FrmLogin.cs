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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
          //  var userName = db.Users.Find(x=>x.UserName).ToString;
            
        }

        private void btnUserEnter_Click(object sender, EventArgs e)
        {
            //nasıl verileri sqlden çekicem bulamadım
            //var userName =db.Users.(x=>x.UserName).FirstOrDefault();
            //var userPassword =db.Users.Select(x=>x.UserPassword).FirstOrDefault();


            if (txtUserName.Text == "" && txtUserPassword.Text == "")
            {
                MessageBox.Show("Boş alan bırakmayınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtUserName.Text == "rumeysa" && txtUserPassword.Text == "1234" || txtUserName.Text == "ali" && txtUserPassword.Text == "4321"|| txtUserName.Text == "kenan" && txtUserPassword.Text == "2525")
                {
                    FrmBanks frm = new FrmBanks();
                    frm.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Yanlış Kullanıcı adı/şifre girişi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            txtUserName.Text = "";
            txtUserPassword.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtUserPassword.Text = "";
        }
    }
}
