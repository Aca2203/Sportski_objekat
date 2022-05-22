using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aplikacija_balon
{
    public partial class Zaposleni : Form
    {
        public Zaposleni()
        {
            InitializeComponent();
        }

        private void Zaposleni_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from zaposleni where id = " + Program.id, Konekcija.Connect());
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            txt_email.Text = tabela.Rows[0]["email"].ToString();
            txt_ime.Text = tabela.Rows[0]["ime"].ToString();
            txt_prezime.Text = tabela.Rows[0]["prezime"].ToString();
        }

        private void Zaposleni_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
