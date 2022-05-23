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
    public partial class Termini : Form
    {
        public Termini()
        {
            InitializeComponent();
        }

        private void Termini_Load(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from zaposleni where id = " + Program.id, veza);
            DataTable tabela = new DataTable();

            txt_email.Text = tabela.Rows[0]["email"].ToString();
        }
    }
}
