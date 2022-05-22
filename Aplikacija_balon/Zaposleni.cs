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

            adapter = new SqlDataAdapter("select * from korisnik", Konekcija.Connect());
            tabela = new DataTable();
            adapter.Fill(tabela);
            cmb_korisnik.DataSource = tabela;
            cmb_korisnik.ValueMember = "id";
            cmb_korisnik.DisplayMember = "email";
            cmb_korisnik.SelectedIndex = -1;

            adapter = new SqlDataAdapter("select * from objekat", Konekcija.Connect());
            tabela = new DataTable();
            adapter.Fill(tabela);
            cmb_objekat.DataSource = tabela;
            cmb_objekat.ValueMember = "id";
            cmb_objekat.DisplayMember = "naziv";
            cmb_objekat.SelectedIndex = -1;

            grid_popuni();
        }

        private void grid_popuni()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select korisnik.email, objekat.naziv, datum, pocetak, kraj from rezervacija join korisnik on korisnik.id = rezervacija.korisnik_id join objekat on objekat.id = rezervacija.objekat_id", Konekcija.Connect());
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
        }

        private void Zaposleni_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cmb_objekat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_objekat.IsHandleCreated && cmb_objekat.Focused)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from termini where objekat_id = " + cmb_objekat.SelectedValue + " and datum = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", Konekcija.Connect());
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);

                cmb_pocetak.DataSource = tabela.Copy();
                cmb_pocetak.DisplayMember = "vreme";
                cmb_pocetak.SelectedIndex = -1;

                cmb_kraj.DataSource = tabela.Copy();
                cmb_kraj.DisplayMember = "vreme";
                cmb_kraj.SelectedIndex = -1;
            }
        }

        private void cmb_pocetak_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_pocetak.IsHandleCreated && cmb_pocetak.Focused)
            {
                try
                {
                    SqlConnection veza = Konekcija.Connect();
                    SqlCommand komanda = new SqlCommand("select cena from termini where objekat_id = " + cmb_objekat.SelectedValue + " and datum = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND vreme = " + cmb_pocetak.Text, veza);

                    veza.Open();
                    txt_posatu.Text = komanda.ExecuteScalar().ToString();
                    veza.Close();
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message);
                }                
            }
        }

        private void cmb_kraj_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_kraj.IsHandleCreated && cmb_kraj.Focused)
            {
                if (Convert.ToInt32(cmb_kraj.Text) - Convert.ToInt32(cmb_pocetak.Text) <= 0)
                {
                    MessageBox.Show("Unesite odgovarajuca vremena!");
                }
                else
                {
                    if (Convert.ToInt32(cmb_kraj.Text) - Convert.ToInt32(cmb_pocetak.Text) >= 4)
                    {
                        MessageBox.Show("Ne mozete rezervisati na toliko vremena!");
                    }
                    else
                    {
                        txt_brojsati.Text = Convert.ToString(Convert.ToInt32(cmb_kraj.Text) - Convert.ToInt32(cmb_pocetak.Text));
                        txt_ukupno.Text = Convert.ToString(Convert.ToInt32(txt_posatu.Text) * Convert.ToInt32(txt_brojsati.Text));
                    }
                }
            }
        }

        private void btn_dodaj_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("insert into rezervacija values(");
            naredba.Append(cmb_korisnik.SelectedValue + ", ");
            naredba.Append(cmb_objekat.SelectedValue + ", '");
            naredba.Append(dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', ");
            naredba.Append(cmb_pocetak.Text + ", ");
            naredba.Append(cmb_kraj.Text + ")");

            SqlConnection veza = Konekcija.Connect();
            SqlCommand komanda = new SqlCommand(naredba.ToString(), veza);

            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();

                grid_popuni();
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message);
            }
        }
    }
}
