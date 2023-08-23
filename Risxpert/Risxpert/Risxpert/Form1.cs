using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;

// Xadiel Martinez Santana 2022-0141

namespace Risxpert
{

    public partial class Form1 : Form
    {
        int Row = 0;

        List<Riesgo> listRiesgos = new List<Riesgo>();

        public Form1()
        {
            InitializeComponent();

            //Iniciar LiteDB e insertar los datos de listaPersonas en la base de datos
            /*using (var db = new LiteDatabase("C:\\Temp\\Risxpert")) //Ubicacion
            {
                var riesgoCollection = db.GetCollection<Riesgo>("Riesgos");
                riesgoCollection.DeleteAll();
                //riesgoCollection.Insert(listRiesgo);

                foreach (Riesgo r in listRiesgos)
                {
                    riesgoCollection.Insert(r);
                }
            }
            */

        }

        public class riesgos
        {
            int ID;
            string Analista;
            string Activo;
            string daño;
            DateTime Fecha;
            int Fun, Sus, Prof, Ext, Agres, Vul;
        }

        int quantity = 0;

        private void Form1_Load(object sender, EventArgs e) // App general
        {
            //lblDate.Text = DateTime.Now.ToLongDateString();
            //lblDate2.Text = DateTime.Now.ToLongDateString();

        }

        private void btnAgregar_Click_1(object sender, EventArgs e) // Boton Agregar Tab 1
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtAnalista.Text)
                || string.IsNullOrEmpty(txtActivo.Text))
            {
                //MessageBox.Show("Debe llenar toda la información para continuar!!", "Llene la información para poder continuar", MessageBoxIcon.Exclamation);
                MessageBox.Show("Debe llenar toda la información para continuar!!", "Llene la información para poder continuar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }


            Riesgo r1 = new Riesgo();
            //Row = dataGridView1.Rows.Add();
            r1.Fecha = DateTime.Now;
            r1.IdData = Int32.Parse(txtID.Text);
            r1.Analista = txtAnalista.Text;
            r1.Activo = txtActivo.Text;
            r1.Riesgoo = txtRiesgo.Text;
            r1.Daño = txtDaños.Text;

            listRiesgos.Add(r1);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listRiesgos;

            txtID.Clear();
            txtAnalista.Clear();
            txtActivo.Clear();
            txtRiesgo.Clear();
            txtDaños.Clear();

            /*dataGridView1.Rows.Add(DateTime.Now, txtID.Text, txtAnalista.Text, txtActivo.Text, txtRiesgo.Text, txtDaños.Text);
            txtID.Clear();
            txtAnalista.Clear();
            txtActivo.Clear();
            txtRiesgo.Clear();
            txtDaños.Clear();
            */
        }


        private void tabPage2_Click(object sender, EventArgs e) // Fecha
        {
            //lblDate2.Text = DateTime.Now.ToLongDateString();
        }



        public class Riesgos
        {
            public ObjectId Id { get; set; } // LiteDB requiere un campo de identificación (ObjectId)
            public int ID { get; set; }
            public int Analista { get; set; }
            public string Activo { get; set; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //Transfer de Data GV Tab 1
        {

                string col = dataGridView1.Columns[e.ColumnIndex].Name;
                
                
                
                if (col == "Transfer")
                {

                    dataGridView2.Rows.Add(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());


                } MessageBox.Show("Su informacion ha sido transferida exitosamente!", "Proceso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnDelete_Click(object sender, EventArgs e) //Boton borrar de la fase 1
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            

            if (MessageBox.Show("Seguro que desea borrar la información?", "Borrar informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
            {
                dataGridView1.Rows.RemoveAt(rowIndex);
            } 
            
        }

        private void btnDelete2_Click(object sender, EventArgs e) //Boton borrar de la fase 2
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            if (MessageBox.Show("Seguro que desea borrar la información?", "Borrar informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
            {
                dataGridView2.Rows.RemoveAt(rowIndex);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) //Transfer de Data GV Tab 2
        {

            string col = dataGridView2.Columns[e.ColumnIndex].Name;
            if (col == "Transfer2")
            {
                DataGridViewRow sourceRow = dataGridView2.Rows[e.RowIndex];
                DataGridViewRow newRow = new DataGridViewRow();

                for (int i = 0; i < sourceRow.Cells.Count; i++)
                {
                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = sourceRow.Cells[i].Value });
                }

                dataGridView3.Rows.Add(newRow);

                MessageBox.Show("Su información ha sido transferida exitosamente!", "Proceso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                double f3 = Convert.ToInt32(row.Cells["F3"].Value);
                double s3 = Convert.ToInt32(row.Cells["S3"].Value);
                double p3 = Convert.ToInt32(row.Cells["P3"].Value);
                double e3 = Convert.ToInt32(row.Cells["E3"].Value);
                double a3 = Convert.ToInt32(row.Cells["A3"].Value);
                double v3 = Convert.ToInt32(row.Cells["V3"].Value);


                row.Cells["I"].Value = f3 * s3;
                row.Cells["D"].Value = p3 * e3;
                row.Cells["C"].Value = Convert.ToInt32(row.Cells["I"].Value) + Convert.ToInt32(row.Cells["D"].Value);
                row.Cells["Pb"].Value = a3 * Convert.ToInt32(row.Cells["V3"].Value);
                row.Cells["ER"].Value = Convert.ToInt32(row.Cells["C"].Value) * Convert.ToInt32(row.Cells["Pb"].Value);
            }

            Riesgo r1 = new Riesgo();
            DataGridViewRow row2 = dataGridView2.Rows[e.RowIndex];
            DataGridViewRow row3 = dataGridView3.Rows[e.RowIndex];

            r1.S = Int32.Parse(row2.Cells["S2"].Value.ToString());
            r1.F = Int32.Parse(row2.Cells["F2"].Value.ToString());
            r1.P = Int32.Parse(row2.Cells["P"].Value.ToString());
            r1.A = Int32.Parse(row2.Cells["A"].Value.ToString());
            r1.V = Int32.Parse(row2.Cells["V"].Value.ToString());
            r1.E = Int32.Parse(row2.Cells["E"].Value.ToString());
            r1.I = Int32.Parse(row3.Cells["I"].Value.ToString());
            r1.D = Int32.Parse(row3.Cells["D"].Value.ToString());
            r1.C = Int32.Parse(row3.Cells["C"].Value.ToString());
            r1.Pb = Int32.Parse(row3.Cells["Pb"].Value.ToString());
            r1.ER = Int32.Parse(row3.Cells["ER"].Value.ToString());

            listRiesgos.Add(r1);
            dataGridView2.DataSource = null;

            //dataGridView2.DataSource = listRiesgos;


        }

        private void btnDelete3_Click(object sender, EventArgs e) //Boton borrar de la fase 3
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            if (MessageBox.Show("Seguro que desea borrar la información?", "Borrar informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
            {
                dataGridView3.Rows.RemoveAt(rowIndex);
            }
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //Realizando las operaciones matematicas en la tab 3
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
                row.Cells["I"].Value = Convert.ToDouble(row.Cells["F3"].Value) * Convert.ToDouble(row.Cells["S3"].Value);
            
            foreach (DataGridViewRow row in dataGridView3.Rows)
                row.Cells["D"].Value = Convert.ToDouble(row.Cells["P3"].Value) * Convert.ToDouble(row.Cells["E3"].Value);

            foreach (DataGridViewRow row in dataGridView3.Rows)
                row.Cells["C"].Value = Convert.ToDouble(row.Cells["I"].Value) + Convert.ToDouble(row.Cells["D"].Value);

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e) //Transfer de data GV tab 3
        {

            string col = dataGridView3.Columns[e.ColumnIndex].Name;
            if (col == "Transfer3")
            {

                dataGridView4.Rows.Add(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString(),
                dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(),
                dataGridView3.Rows[e.RowIndex].Cells[13].Value.ToString());

                MessageBox.Show("Su informacion ha sido transferida exitosamente!", "Proceso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            

            Riesgo r1 = new Riesgo();
            //Row = dataGridView1.Rows.Add();
            r1.I = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
            r1.D = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
            r1.Pb = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString());
            r1.ER = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString());
            
            listRiesgos.Add(r1);
            //dataGridView1.DataSource = null;
            dataGridView1.DataSource = listRiesgos;
            //return;
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            /*Riesgo r1 = new Riesgo();
            r1.Fecha = DateTime.Now;
            //r1.IdData = txtID.Text;
            r1.Analista = txtAnalista.Text;
            */
        }

        private void txtAnalista_Leave(object sender, EventArgs e)
        {
            if (txtAnalista.Text != "")
            {
                string text = txtAnalista.Text;
                string firstLetterOfstg = text.Substring(0, 1).ToUpper() + text.Substring(1);

                txtAnalista.Text = firstLetterOfstg;
            }
        }

        private void txtActivo_Leave(object sender, EventArgs e) 
            //Poner primera letra en mayuscula en el textbox de Activo
        {
            if (txtActivo.Text != "")
            {
                string text = txtActivo.Text;
                string firstLetterOfstg = text.Substring(0, 1).ToUpper() + text.Substring(1);

                txtActivo.Text = firstLetterOfstg;
            }
        }

        private void txtRiesgo_Leave(object sender, EventArgs e)
        {
            if (txtRiesgo.Text != "")
            {
                string text = txtRiesgo.Text;
                string firstLetterOfstg = text.Substring(0, 1).ToUpper() + text.Substring(1);

                txtRiesgo.Text = firstLetterOfstg;
            }
        }

        private void txtDaños_Leave(object sender, EventArgs e)
        {
            if (txtDaños.Text != "")
            {
                string text = txtDaños.Text;
                string firstLetterOfstg = text.Substring(0, 1).ToUpper() + text.Substring(1);

                txtDaños.Text = firstLetterOfstg;
            }
        }

        private void btnSaveToDB_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                using (var db = new LiteDatabase("C:\\Temp\\Risxpert")) //Ubicacion
                {
                    var riesgoCollection = db.GetCollection<Riesgo>("Riesgos");
                    riesgoCollection.DeleteAll();
                    //riesgoCollection.Insert(listRiesgo);
                    riesgoCollection.InsertBulk(listRiesgos);

                    /*foreach (Riesgo r in listRiesgos)
                    {
                        riesgoCollection.Insert(r);
                    }
                    */
                }

        }

         /*private void btnSaveToDB_Click(object sender, DataGridViewCellEventArgs e)
         {

             using (var db = new LiteDatabase("C:\\Temp\\Risxpert")) //Ubicacion
             {
                 var riesgoCollection = db.GetCollection<Riesgo>("Riesgos");
                 riesgoCollection.DeleteAll();
                 //riesgoCollection.Insert(listRiesgo);

                 foreach (Riesgo r in listRiesgos)
                 {
                     riesgoCollection.Insert(r);
                 }
             }
         */
         }

        private void btnTransfer_Click(object sender, DataGridViewCellEventArgs e)
        {
            //string col = dataGridView1.Columns[e.ColumnIndex].Name;
            //if (col == "Transfer")
            //{
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView2.Rows.Add(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                } MessageBox.Show("Su informacion ha sido transferida exitosamente!", "Proceso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);


           // }

            MessageBox.Show("Su informacion ha sido transferida exitosamente!", "Proceso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 3 & e.Value != null)
            {
                int ER2 = Convert.ToInt32(e.Value);
                if (ER2 >= 2 && ER2 <= 250)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (ER2 >= 251 && ER2 <= 500)
                {
                    e.CellStyle.BackColor= Color.Green;
                }
                else if (ER2 >= 501 && ER2 <= 750)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (ER2 >= 751 && ER2 <= 1000)
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (ER2 >= 1001 && ER2 <= 1250)
                {
                    e.CellStyle.BackColor = Color.Red;
                }

            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e) 
        // Para que el txt del ID solo acepte numeros
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            //Cambiando colores segun numeros del 1-5
        {
            if (e.ColumnIndex == 3 & e.Value != null)
            {
                int S2 = Convert.ToInt32(e.Value);
                if (S2 == 1)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 2)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 3)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (S2 == 4)
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (S2 == 5)
                {
                    e.CellStyle.BackColor = Color.Red;
                }

            }
            if (e.ColumnIndex == 4 & e.Value != null)
            {
                int S2 = Convert.ToInt32(e.Value);
                if (S2 == 1)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 2)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 3)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (S2 == 4)
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (S2 == 5)
                {
                    e.CellStyle.BackColor = Color.Red;
                }

            }
            if (e.ColumnIndex == 5 & e.Value != null)
            {
                int S2 = Convert.ToInt32(e.Value);
                if (S2 == 1)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 2)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 3)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (S2 == 4)
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (S2 == 5)
                {
                    e.CellStyle.BackColor = Color.Red;
                }

            }
            if (e.ColumnIndex == 6 & e.Value != null)
            {
                int S2 = Convert.ToInt32(e.Value);
                if (S2 == 1)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 2)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 3)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (S2 == 4)
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (S2 == 5)
                {
                    e.CellStyle.BackColor = Color.Red;
                }

            }
            if (e.ColumnIndex == 7 & e.Value != null)
            {
                int S2 = Convert.ToInt32(e.Value);
                if (S2 == 1)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 2)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 3)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (S2 == 4)
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (S2 == 5)
                {
                    e.CellStyle.BackColor = Color.Red;
                }

            }
            if (e.ColumnIndex == 8 & e.Value != null)
            {
                int S2 = Convert.ToInt32(e.Value);
                if (S2 == 1)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 2)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (S2 == 3)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (S2 == 4)
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (S2 == 5)
                {
                    e.CellStyle.BackColor = Color.Red;
                }

            }
        }
    }
    }
    
    

