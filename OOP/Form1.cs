﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP.Models;
using System.Data.SqlClient;
using OOP.Validation.Employee;

namespace OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
          
            db_view view = new db_view();
            view.view_table(dgr , view.student_all);
            view.view_table(dgr_class , view.class_all);
            
        }

        private void dgr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            db_view view = new db_view();
            using (SqlConnection DBCON = new SqlConnection(view.connectionString))
            {
                try
                {
                    DBCON.Open();
                    string DATA = "INSERT INTO tbl_class (name,floor,des)VALUES(@name,@floor,@des)";
                    using (SqlCommand cmd = new SqlCommand(DATA , DBCON))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@name", txt_name.Text);
                            cmd.Parameters.AddWithValue("@floor", txt_floor.Text);
                            cmd.Parameters.AddWithValue("@des" , txt_des.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data has been Saved!");
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                       
                    }
                } catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void txt_des_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click_Click(object sender, EventArgs e)
        {
            db_view view = new db_view();
            if (chk_search_by_code.Checked == true)
            {
                view.view_table(dgr, view.student_all, txt_search.Text);
            }
            if (chk_search_by_all.Checked == true)
            {
                view.view_table(dgr, view.student_all);
            }
            if (chk_search_by_id.Checked == true)
            {
                view.view_table(dgr , view.student_all , Convert.ToInt16(txt_search.Text));
            }
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            Validation.Employee.Employee em = new Validation.Employee.Employee();
            em.Name = txt_name.Text;
            txt_name.Text = em.Name;

        }
    }
        
}
