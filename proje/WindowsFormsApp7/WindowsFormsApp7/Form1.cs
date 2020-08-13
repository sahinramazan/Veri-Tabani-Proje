using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string cs = "Host=localhost;Username=postgres;Password=123456;Database=odev4";
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        NpgsqlDataAdapter da1;
        NpgsqlDataAdapter da2;
        NpgsqlDataAdapter da3;
        NpgsqlDataAdapter da4;
        NpgsqlDataAdapter da5;
        NpgsqlDataAdapter da6;
        NpgsqlDataAdapter da7;
        DataSet ds;
        DataSet ds1;
        DataSet ds2;
        DataSet ds3;
        DataSet ds4;
        DataSet ds5;
        DataSet ds6;
        DataSet ds7;
        NpgsqlCommandBuilder cmdb;
        void liste()
        {
            con = new NpgsqlConnection(cs);
            con.Open();
            da = new NpgsqlDataAdapter("Select kitap_ad,kat_ad,tur_ad from kitap inner join kategori on(kat_id=katag_id) inner join tur on (tur.tur_id=kitap.tur_id)", con);
            cmdb = new NpgsqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables[0];
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandText = "Select kitap_ad from kitap";
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            NpgsqlDataReader dr;
            dr = komut.ExecuteReader();
            comboBox1.Items.Clear();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["kitap_ad"]);
            }
            con.Close();
        }
        void listeara()
        {
            con = new NpgsqlConnection(cs);
            con.Open();
            da = new NpgsqlDataAdapter("Select kitap_ad,kat_ad,tur_ad from kitap inner join kategori on(kat_id=katag_id) inner join tur on (tur.tur_id=kitap.tur_id) where kitap_ad like'%"+textBox3.Text+"%'", con);
            cmdb = new NpgsqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables[0];
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandText = "Select kitap_ad from kitap";
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            NpgsqlDataReader dr;
            dr = komut.ExecuteReader();
            comboBox1.Items.Clear();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["kitap_ad"]);
            }
            con.Close();
        }
        void listekat()
        {
            con = new NpgsqlConnection(cs);
            con.Open();
            da1 = new NpgsqlDataAdapter("Select kat_ad from kategori", con);
            cmdb = new NpgsqlCommandBuilder(da1);
            ds1 = new DataSet();
            da1.Fill(ds1, "kategori");
            dataGridView2.DataSource = ds1.Tables[0];
            con.Close();
        }
        void listetur()
        {
            con = new NpgsqlConnection(cs);
            con.Open();
            da2 = new NpgsqlDataAdapter("Select tur_ad from tur", con);
            cmdb = new NpgsqlCommandBuilder(da2);
            ds2 = new DataSet();
            da2.Fill(ds2, "tur");
            dataGridView3.DataSource = ds2.Tables[0];
            con.Close();
        }
        void listekul()
        {
            con = new NpgsqlConnection(cs);
            con.Open();
            da3 = new NpgsqlDataAdapter("Select k_ad,k_pass from kullanici", con);
            cmdb = new NpgsqlCommandBuilder(da3);
            ds3 = new DataSet();
            da3.Fill(ds3, "kullanici");
            dataGridView4.DataSource = ds3.Tables[0];
            con.Close();
        }
        void listeuye()
        {
            con = new NpgsqlConnection(cs);
            con.Open();
            da4 = new NpgsqlDataAdapter("Select uye_ad from uye", con);
            cmdb = new NpgsqlCommandBuilder(da4);
            ds4 = new DataSet();
            da4.Fill(ds4, "uye");
            dataGridView5.DataSource = ds4.Tables[0];
            con.Close();
        }
        void listeal()
        {
            con = new NpgsqlConnection(cs);
            con.Open();
            da5 = new NpgsqlDataAdapter("Select kitap_ad from alinan_kitap inner join kitap on(kitap.kitap_id=alinan_kitap.al_kitap_id)", con);
            cmdb = new NpgsqlCommandBuilder(da5);
            ds5 = new DataSet();
            da5.Fill(ds5, "alinan_kitap");
            dataGridView6.DataSource = ds5.Tables[0];
            con.Close();
        }

        void listever()
        {
            con = new NpgsqlConnection(cs);
            con.Open();
            da6 = new NpgsqlDataAdapter("Select kitap_ad from ver_kitap inner join kitap on(kitap.kitap_id=ver_kitap.ver_kitap_id)", con);
            cmdb = new NpgsqlCommandBuilder(da6);
            ds6 = new DataSet();
            da6.Fill(ds6, "ver_kitap");
            dataGridView7.DataSource = ds6.Tables[0];
            con.Close();
        }
        void listeih()
        {
            con = new NpgsqlConnection(cs);
            con.Open();
            da7 = new NpgsqlDataAdapter("SELECT kitap_ad,sum(ihtiyac_miktar) as miktar FROM stok_ihtiyac inner join kitap on (ih_kitap_id=kitap_id) group by kitap_ad", con);
            cmdb = new NpgsqlCommandBuilder(da7);
            ds7 = new DataSet();
            da7.Fill(ds7, "stok_ihtiyac");
            dataGridView8.DataSource = ds7.Tables[0];
            con.Close();
        }
        void seckitap() {
            con = new NpgsqlConnection(cs);
            con.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            NpgsqlCommand komut2 = new NpgsqlCommand();
            komut.CommandText = "Select kat_ad from kategori";
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            NpgsqlDataReader dr;
            dr = komut.ExecuteReader();
            comboBox2.Items.Clear();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["kat_ad"]);
            }con.Close();
            con.Open();
            komut2.CommandText = "Select tur_ad from tur";
            komut2.Connection = con;
            komut2.CommandType = CommandType.Text;
            NpgsqlDataReader dr2;
            dr2 = komut2.ExecuteReader();
            comboBox3.Items.Clear();
            while (dr2.Read())
            {
                comboBox3.Items.Add(dr2["tur_ad"]);
            }
            con.Close();
        }
        void selected()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Kitap Güncelle";
            button2.Text = "Kategori Güncelle";
            button3.Text = "Tür Güncelle";
            button4.Text = "Üye Güncelle";
            button5.Text = "Kullanıcı Güncelle";
            button6.Text = "Alınan kitap Güncelle";
            button7.Text = "Verilen kitap Güncelle";
            button8.Text = "Gelicek kitap Güncelle";
            button9.Text = "Kitap ekle";
            button10.Text = "Kitap Düzenle";
            button11.Text = "Kitap sil";
            button12.Text = "Kitap ara";
            tabPage1.Text = "Kitap İşlemleri";
            tabPage2.Text = "Kategori ve tür İşlemleri";
            tabPage3.Text = "Kullanıcı ve Üye İşlemleri";
            tabPage4.Text = "Alınan,Verilen ve Gelicek Kitap İşlemleri";
            label1.Text = "Kitap adı";
            label2.Text = "Eklenicek miktar";
            label3.Text = "Kitap adı    :";
            label4.Text = "Kategori adı :";
            label5.Text = "Tür adı      :";
            label6.Text = "Aranıcak kitap adı:";
            liste();
            listekat();
            listetur();
            listeuye();
            listekul();
            listeal();
            listever();
            listeih();
            seckitap();
            comboBox1.SelectedIndex = 0;
        }

            private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kitap Kayıt güncellendi");
            liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            da1.Update(ds1, "kategori");
            MessageBox.Show("Kategori Kayıt güncellendi");
            listekat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            da2.Update(ds2, "tur");
            MessageBox.Show("Tür Kayıt güncellendi");
            listetur();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            da3.Update(ds3, "kullanici");
            MessageBox.Show("Kullanıcı Kayıt güncellendi");
            listekul();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            da4.Update(ds4, "uye");
            MessageBox.Show("Üye Kayıt güncellendi");
            listeuye();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NpgsqlCommand find = new NpgsqlCommand("select kitap_id from kitap where kitap_ad='" + comboBox1.Text + "'", con);
            con.Open();
            int kitap_id = (int)find.ExecuteScalar();

            NpgsqlCommand ins = new NpgsqlCommand("insert into alinan_kitap (al_kitap_id) values(" + kitap_id + ")", con);
            ins.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Alınan kitap Kayıt güncellendi");
            listeal();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NpgsqlCommand find = new NpgsqlCommand("select kitap_id from kitap where kitap_ad='" + comboBox1.Text + "'", con);
            con.Open();
            int kitap_id = (int)find.ExecuteScalar();

            NpgsqlCommand ins = new NpgsqlCommand("insert into ver_kitap(ver_kitap_id) values(" + kitap_id +")", con);
            ins.ExecuteNonQuery();
            MessageBox.Show("Verilen kitap Kayıt güncellendi");
            con.Close();
            listever();
            liste();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int miktar = int.Parse(textBox1.Text);
            NpgsqlCommand find = new NpgsqlCommand("select kitap_id from kitap where kitap_ad='"+comboBox1.Text+"'",con);
            con.Open();
            int kitap_id=(int)find.ExecuteScalar();
            
            NpgsqlCommand ins = new NpgsqlCommand("insert into stok_ihtiyac(ih_kitap_id,ihtiyac_miktar) values(" + kitap_id + "," + miktar+")",con);
            ins.ExecuteNonQuery();
            MessageBox.Show("Gelicek kitap Kayıt güncellendi");
            con.Close();
            listeih();
            liste();
        }
        string selectedrow_ad="";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells[0].Value.ToString();
                selectedrow_ad = row.Cells[0].Value.ToString();
                int index1 = comboBox2.Items.IndexOf(row.Cells[1].Value.ToString());
                comboBox2.SelectedIndex = index1;
                comboBox3.SelectedIndex = comboBox3.Items.IndexOf(row.Cells[2].Value.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int kat_id, tur_id;
            string kitap_ad = textBox2.Text;
            NpgsqlCommand find = new NpgsqlCommand("select kat_id from kategori where kat_ad='" + comboBox2.Text + "'", con);
            NpgsqlCommand find2 = new NpgsqlCommand("select tur_id from tur where tur_ad='" + comboBox3.Text + "'", con);
            if (kitap_ad != "" && comboBox3.Text != "" && comboBox2.Text != "")
            {
                con.Open();
                kat_id = (int)find.ExecuteScalar();
                tur_id = (int)find2.ExecuteScalar();
                NpgsqlCommand komut = new NpgsqlCommand();
                komut.CommandText = "insert into kitap(kitap_ad,katag_id,tur_id) values('" + kitap_ad + "'," + kat_id + "," + tur_id + " )";
                komut.Connection = con;
                komut.CommandType = CommandType.Text;
                komut.ExecuteNonQuery();

                con.Close();
            }
            else
                MessageBox.Show("Lütfen veri yazdıgınıza emin olunuz");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try { 
            int kat_id, tur_id;
            string kitap_ad = selectedrow_ad;
            NpgsqlCommand find = new NpgsqlCommand("select kat_id from kategori where kat_ad='" + comboBox2.Text + "'", con);
            NpgsqlCommand find2 = new NpgsqlCommand("select tur_id from tur where tur_ad='" + comboBox3.Text + "'", con);
            NpgsqlCommand find3 = new NpgsqlCommand("select kitap_id from kitap where kitap_ad='"+ kitap_ad+"'" , con);
                if(kitap_ad!="" && comboBox3.Text!=""&& comboBox2.Text != "") {
            con.Open();
            kat_id = (int)find.ExecuteScalar();
            tur_id = (int)find2.ExecuteScalar();
            int kitap_id= (int)find3.ExecuteScalar(); 
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandText = "update kitap set kitap_ad='" + textBox2.Text + "',katag_id=" + kat_id + ",tur_id=" + tur_id + " where kitap_id="+kitap_id;
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            komut.ExecuteNonQuery();

            con.Close();
                }
                else
                    MessageBox.Show("Lütfen veri sectiğinize emin olunuz");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Lütfen veri sectiğinize emin olunuz");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string kitap_ad = selectedrow_ad;
            NpgsqlCommand find3 = new NpgsqlCommand("select kitap_id from kitap where kitap_ad='" + kitap_ad + "'", con);
            NpgsqlCommand komut = new NpgsqlCommand();
            if (kitap_ad != "")
            {
                con.Open();
            int kitap_id = (int)find3.ExecuteScalar();
            con.Close();
            komut.CommandText = "delete from kitap where kitap_id=" + kitap_id;
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
        }
                else
                    MessageBox.Show("Lütfen veri sectiğinize emin olunuz");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listeara();
        }
    }
}
