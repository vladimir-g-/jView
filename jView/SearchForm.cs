using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jView
{
    public partial class SearchForm : Form
    {
        private FindByTextFunction searchByText; // delegate for calling search functionality

        // Commented to exclude possibility to create this class in wrong way
        /*public SearchForm()
        {
            InitializeComponent();
        }*/

        public SearchForm(FindByTextFunction func)
        {
            InitializeComponent();

            searchByText = func;
        }

        private void CloseSearchDialogButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            bool searchResult = false;

            // Find button was clicked ...
            if (searchByText != null)
                searchResult = searchByText(searchText.Text);

            if (searchResult == false)
                MessageBox.Show("Tag '" + searchText.Text + "' was not found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
