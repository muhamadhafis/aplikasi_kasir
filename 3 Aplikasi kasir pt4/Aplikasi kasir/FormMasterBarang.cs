﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Data.SqlClient;

namespace Aplikasi_kasir
{
    public partial class FormMasterBarang : Form
    {
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;

        void munculSatuan()
        {
            comboBox1.Items.Add("PCS");
            comboBox1.Items.Add("BOX");
            comboBox1.Items.Add("BOTOL");
            comboBox1.Items.Add("PAX");
            comboBox1.Items.Add("KILO");
            comboBox1.Items.Add("KARUNG");
        }
        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            munculSatuan();
            MunculDataBarang();
        }
        void MunculDataBarang()
        {
            SqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from TBL_BARANG", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TBL_BARANG");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TBL_BARANG";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }
        public FormMasterBarang()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormMasterBarang_Load(object sender, EventArgs e)
        {
            KondisiAwal();
        }
    }
}
