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
	public partial class AddQuote : Form
	{
		DeskQuote quote = new DeskQuote();

		private Form MainMenuForm;

		public AddQuote(Form mainMenu)
		{
			InitializeComponent();
			MainMenuForm = mainMenu;
		}

		// Cancel the quote
		private void cancelButton_Click(object sender, EventArgs e)
		{
			MainMenuForm.Show();
			Close();
		}

		private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
		{
			MainMenuForm.Show();
		}

		private void nameTextBox_TextChanged(object sender, EventArgs e)
		{
			quote.Name = nameTextBox.Text;
		}

		private void submitButton_Click(object sender, EventArgs e)
		{
			quote.Date = DateTime.Now;
			fileQuote(quote);
			var mainMenu = (MainMenu)Tag;
			mainMenu.Show();
			Close();
		}

		private void fileQuote(DeskQuote deskQuote)
		{
			string csvFile = "quotes.csv";

			using (StreamWriter writer = new StreamWriter(csvFile, true))
			{
				writer.WriteLine(
						$"{quote.Date}," +
						$"{quote.Name}," +
						$"{quote.desk.Depth}," +
						$"{quote.desk.Width}," +
						$"{quote.desk.NumDrawers}," +
						$"{quote.desk.Material}," +
						$"{quote.ShippingDays}," +
						$"{quote.CalculateTotalCost()}");
			}		
		}
		
		/**********************************************************************
		 * ************* SURFACE AREA *****************************************
		 * *******************************************************************/

		/* What to do when value changes for width NumericUpDown */
		private void widthNumericEvent(object sender, EventArgs e)
		{
			widthNumeric.Minimum = 24;
			widthNumeric.Maximum = 96;
			
			quote.desk.Width = (int)widthNumeric.Value;
			surfaceAreaBox.Text = quote.desk.SurfaceArea.ToString() + "\"";
			surfaceAreaCostBox.Text = "$" + quote.CalculateSurfaceAreaCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		/* What to do when value changes for depth NumericUpDown */
		private void depthNumeric_ValueChanged(object sender, EventArgs e)
		{
			depthNumeric.Minimum = 12;
			depthNumeric.Maximum = 48;

			quote.desk.Depth = (int)depthNumeric.Value;
			surfaceAreaBox.Text = quote.desk.SurfaceArea.ToString() + "\"";
			surfaceAreaCostBox.Text = "$" + quote.CalculateSurfaceAreaCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		/**********************************************************************
		 * ************* Drawers **********************************************
		 * *******************************************************************/

		/* What to do when value changes for drawer amount */
		private void drawerNumeric_ValueChanged(object sender, EventArgs e)
		{
			drawerNumeric.Minimum = 0;
			drawerNumeric.Maximum = 7;
			quote.desk.NumDrawers = (int)drawerNumeric.Value;
			drawerCostBox.Text = "$" + quote.CalculateDrawerCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		/**********************************************************************
		 * ************* Surface Materials ************************************
		 * *******************************************************************/

		// Oak Selection
		private void oakButton_CheckedChanged(object sender, EventArgs e)
		{
			quote.desk.Material = Desk.SurfaceMaterial.oak;
			materialCostBox.Text = "$" + quote.CalculateSurfaceMaterialCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		// Laminate Selection
		private void laminateButton_CheckedChanged(object sender, EventArgs e)
		{
			quote.desk.Material = Desk.SurfaceMaterial.laminate;
			materialCostBox.Text = "$" + quote.CalculateSurfaceMaterialCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		// Pine Selection
		private void pineButton_CheckedChanged(object sender, EventArgs e)
		{
			quote.desk.Material = Desk.SurfaceMaterial.pine;
			materialCostBox.Text = "$" + quote.CalculateSurfaceMaterialCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		// Rosewood Selection
		private void rosewoodButton_CheckedChanged(object sender, EventArgs e)
		{
			quote.desk.Material = Desk.SurfaceMaterial.rosewood;
			materialCostBox.Text = "$" + quote.CalculateSurfaceMaterialCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		// Veneer Selection
		private void veneerButton_CheckedChanged(object sender, EventArgs e)
		{
			quote.desk.Material = Desk.SurfaceMaterial.veneer;
			materialCostBox.Text = "$" + quote.CalculateSurfaceMaterialCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}


		/**********************************************************************
		 * ************* SHIPPING *********************************************
		 * *******************************************************************/

		// Five Days
		private void fiveDayButton_CheckedChanged(object sender, EventArgs e)
		{
			quote.ShippingDays = 5;
			deliveryCostBox.Text = "$" + quote.CalculateRushOrderCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		// Three Days
		private void threeDayButton_CheckedChanged(object sender, EventArgs e)
		{
			quote.ShippingDays = 3;
			deliveryCostBox.Text = "$" + quote.CalculateRushOrderCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		// Seven Days
		private void sevenDayButton_CheckedChanged(object sender, EventArgs e)
		{
			quote.ShippingDays = 7;
			deliveryCostBox.Text = "$" + quote.CalculateRushOrderCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		// Fourteen Days
		private void fourteenDayButton_CheckedChanged(object sender, EventArgs e)
		{
			quote.ShippingDays = 14;
			deliveryCostBox.Text = "$" + quote.CalculateRushOrderCost().ToString();
			totalCostBox.Text = "$" + quote.CalculateTotalCost().ToString();
		}

		private void AddQuote_Load(object sender, EventArgs e)
		{

		}

		
	}
}
