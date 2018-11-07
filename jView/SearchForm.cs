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
            int nodesFound = 0;

            // Find button was clicked ...
            if (searchByText != null)
            {
                nodesFound = searchByText(searchText.Text);

                // Check if we received 0 or more. Receiving -1 means that tree doesn't contain any suitable node
                if (nodesFound != -1)
                {
                    numberOfFoundNodesLabel.Text = nodesFound.ToString() + " nodes";

                    if (nodesFound == 0)
                        MessageBox.Show("Tag '" + searchText.Text + "' was not found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        if (nodesFound > 1)
                        {
                            findButton.Text = "Find next";
                        }
                    }
                }
            }
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            clearSearchResults();
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            clearSearchResults();
            findButton.Text = "Find";
        }
    }
}
