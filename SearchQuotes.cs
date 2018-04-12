using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MegaDesk2HarryVashisht
{
	public partial class SearchQuotes : Form
	{
		private Form MainMenuForm;

		private List<Desk.SurfaceMaterial> materials;

		public SearchQuotes(Form mainMenu)
		{
			MainMenuForm = mainMenu;
			InitializeComponent();
			populateDropBox();
		}

		private void populateDropBox()
		{
			materials = new List<Desk.SurfaceMaterial>();
			foreach (Desk.SurfaceMaterial value in Enum.GetValues(typeof(Desk.SurfaceMaterial)))
			{
				materials.Add(value);
			}
			materialDropBox.DataSource = materials;
		}

		private void materialDropBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			dataGrid.Rows.Clear();

			if (materialDropBox.SelectedItem.Equals(Desk.SurfaceMaterial.laminate))
			{
				viewData(Desk.SurfaceMaterial.laminate);
			}
			if (materialDropBox.SelectedItem.Equals(Desk.SurfaceMaterial.oak))
			{
				viewData(Desk.SurfaceMaterial.oak);
			}
			if (materialDropBox.SelectedItem.Equals(Desk.SurfaceMaterial.veneer))
			{
				viewData(Desk.SurfaceMaterial.veneer);
			}
			if (materialDropBox.SelectedItem.Equals(Desk.SurfaceMaterial.rosewood))
			{
				viewData(Desk.SurfaceMaterial.rosewood);
			}
			if (materialDropBox.SelectedItem.Equals(Desk.SurfaceMaterial.pine))
			{
				viewData(Desk.SurfaceMaterial.pine);
			}
		}

		private void viewData(Desk.SurfaceMaterial material)
		{

			char seperator = ',';

			try
			{
				string[] quotes = File.ReadAllLines("quotes.csv");

				foreach (string quote in quotes)
				{
					string[] row = quote.Split(seperator);

					// If material equals to the passed material
					if (row[5].Equals(material.ToString())) {
						dataGrid.Rows.Add(row);
					}
				}
			}
			catch (FileNotFoundException e)
			{
				
			}
		}

		private void SearchQuotes_Load(object sender, EventArgs e)
		{

		}

		private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
		{
			MainMenuForm.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MainMenuForm.Show();
			Close();
		}
	}
}
