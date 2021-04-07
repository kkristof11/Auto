using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoProjekt
{
	public partial class Form1 : Form
	{
		private List<Auto> autokLista;
		private DataTable raktarTable;
		public Form1()
		{

			InitializeComponent();
			raktarTable = new DataTable();
			autokLista = new List<Auto>();
			autokLista.Add(new Auto("pál", "BMW", "Zöld"));
			autokLista.Add(new Auto("Laci", "VW", "Piros"));
			autokLista.Add(new Auto("Béla", "Opel", "Kék"));
			autokLista.Add(new Auto("Gyuri", "BMW", "Sárga"));

			tablatKeszit();
			feltoltes();

			dataGridView1.DataSource = raktarTable;
		}

		public void tablatKeszit()
		{
			DataColumn gyartoColumn = new DataColumn("Gyártó", typeof(string));
			DataColumn szinColumn = new DataColumn("Szín", typeof(string));
			DataColumn nevColumn = new DataColumn("Név", typeof(string));
			DataColumn idColumn = new DataColumn("ID", typeof(int));
			idColumn.Caption = "Autó ID";
			idColumn.ReadOnly = true;
			idColumn.AllowDBNull = false;
			idColumn.Unique = true;
			idColumn.AutoIncrement = true;
			idColumn.AutoIncrementSeed = 0;
			idColumn.AutoIncrementStep = 1;

			raktarTable.Columns.AddRange(new DataColumn[] { idColumn, gyartoColumn, szinColumn, nevColumn });
		}

		public void feltoltes()
        {
			//int i = 0;
            foreach (Auto auto in autokLista)
            {
				DataRow dr = raktarTable.NewRow();
				//dr["ID"] = i;
				dr["Gyártó"] = auto.Gyarto;
				dr["Szín"] = auto.Szin;
				dr["Név"] = auto.Nev;
				raktarTable.Rows.Add(dr);
				//i++;
			}
        }

        private void torol_Click(object sender, EventArgs e)
        {
            try
            {
				raktarTable.Rows[int.Parse(txtTorol.Text)].Delete();
				raktarTable.AcceptChanges();
			}
            catch (Exception ex)
            {
				MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

			raktarTable.Rows.Clear();
			raktarTable.AcceptChanges();
			//tablatKeszit();
			feltoltes();
			dataGridView1.DataSource = raktarTable;
		}
    }
}
