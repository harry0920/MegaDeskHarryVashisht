using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk2HarryVashisht
{
	public partial class MainMenu : Form
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		private void addQuoteButton_Click(object sender, EventArgs e)
		{
			AddQuote addNewQuoteForm = new AddQuote(this);
			addNewQuoteForm.Tag = this;
			addNewQuoteForm.Show(this);
			Hide();
		}

		private void viewQuotesButton_Click(object sender, EventArgs e)
		{
			try
			{
				ViewAllQuotes viewAllQuotesFrom = new ViewAllQuotes(this);
				viewAllQuotesFrom.Tag = this;
				viewAllQuotesFrom.Show(this);
				Hide();
			} catch (Exception)
			{
				MessageBox.Show("There are no quotes available.");
			}
		}

		private void searchQuoteButton_Click(object sender, EventArgs e)
		{
			SearchQuotes searchQuotesForm = new SearchQuotes(this);
			searchQuotesForm.Tag = this;
			searchQuotesForm.Show(this);
			Hide();
		}

		private void exitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MainMenu_Load(object sender, EventArgs e)
		{

		}
	}
}
