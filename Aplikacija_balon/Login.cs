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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void dugme_login_Click(object sender, EventArgs e)
        {
            if (txt_email.Text == "" || txt_lozinka.Text == "")
            {
                MessageBox.Show("Niste uneli podatke.");
                return;
            }
            else
            {
                try
                {
                    SqlConnection veza = Konekcija.Povezi();
                    SqlCommand komanda = new SqlCommand("SELECT * FROM Osoba WHERE email = @username", veza);
                    komanda.Parameters.AddWithValue("@username", txt_email.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);

                    int brojac = tabela.Rows.Count;
                    if (brojac == 1)
                    {
                        if (String.Compare(tabela.Rows[0]["pass"].ToString(), txt_pass.Text) == 0)
                        {
                            MessageBox.Show("Успешно сте се улоговали!");
                            Program.ime_korisnika = tabela.Rows[0]["ime"].ToString();
                            Program.prezime_korisnika = tabela.Rows[0]["prezime"].ToString();
                            Program.uloga_korisnika = tabela.Rows[0]["uloga"].ToString();
                            this.Hide();
                            Glavna2 frm_Glavna2 = new Glavna2();
                            frm_Glavna2.Show();
                        }
                        else
                        {
                            MessageBox.Show("Унели сте погрешну лозинку!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Унели сте непостојећу имејл адресу!");
                    }
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message);
                }
            }
        }
    }
}
