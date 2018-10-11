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
        private ClearSearchResults clearSearchResults; // delegeate for calling functionality of clearing search results in object whick called this window

        // Commented to exclude possibility to create this class in wrong way
        /*public SearchForm()
        {
            InitializeComponent();
        }*/

        public SearchForm(FindByTextFunction func, ClearSearchResults funcClear)
        {
            InitializeComponent();

            searchByText = func;
            clearSearchResults = funcClear;
        }

        private void CloseSearchDialogButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int searchResult = 0;

            // Find button was clicked ...
            if (searchByText != null)
                searchResult = searchByText(searchText.Text);

            if (searchResult == 0)
                MessageBox.Show("Tag '" + searchText.Text + "' was not found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                numberOfFoundNodesLabel.Text = searchResult.ToString() + " nodes";
            }
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            clearSearchResults();
        }
    }
}
