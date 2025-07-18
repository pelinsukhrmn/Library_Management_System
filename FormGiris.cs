using System.Data.SqlClient;

namespace KutuphaneYonetimSistemi
{
    public partial class FormGiris : Form
    {
        FormKitaplar formKitaplar;
        public FormGiris()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DbYTAKutuphane;Integrated Security=True");
        private void buttonGiris_Click(object sender, EventArgs e)
        {
            string sifre = "";

            // Bug-fix II:
            if ((textBoxKullaniciAdi.Text == "") || (textBoxSifre.Text ==""))
            {
                MessageBox.Show("Kullan�c� Ad� veya �ifre hatal� !");
                return;
            }

            try
            {
                baglanti.Open();
                SqlCommand sqlKomut = new SqlCommand("SELECT Sifre FROM TableKutuphaneYoneticileri WHERE KullaniciAdi = @p1", baglanti);
                sqlKomut.Parameters.AddWithValue("@p1", textBoxKullaniciAdi.Text);
                SqlDataReader sqlDataReader = sqlKomut.ExecuteReader();
                
                while(sqlDataReader.Read())
                {
                    sifre = sqlDataReader[0].ToString();                    
                }
                //label3.Text = sifre;

                if (sifre == textBoxSifre.Text)
                {                   
                    formKitaplar = new FormKitaplar();
                    this.Hide();
                    formKitaplar.Show();
                }
                else
                {
                    MessageBox.Show("Kullan�c� Ad� veya �ifre hatal� !");
                    textBoxKullaniciAdi.Text = "";
                    textBoxSifre.Text = "";
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ba�lant� hatas�! " + ex.Message);                
            }
            finally
            {
                baglanti.Close();
            }

        }
    }
}