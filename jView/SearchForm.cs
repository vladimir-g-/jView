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

        public SearchForm(FindByTextFunction findFunction, ClearSearchResults clearSearchResultFunction)
        {
            InitializeComponent();

            searchByText = findFunction;
            clearSearchResults = clearSearchResultFunction;
        }

        private void CloseSearchDialogButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int nodesFound = 0;

            // Find button was clicked ...
            if (searchByText != null && (checkSearchInNames.Checked || checkSearchInValues.Checked))
            {
                SearchOptions options = new SearchOptions();

                // set search options
                options.FindName = checkSearchInNames.Checked;
                options.FindValue = checkSearchInValues.Checked;
                options.CaseSensitive = checkCaseSensitive.Checked;
                options.ExactMatch = checkExactMatch.Checked;

                nodesFound = searchByText(searchText.Text, options);

                // Check if we received 0 or more. Receiving -1 means that tree doesn't contain any suitable node
                if (nodesFound != -1)
                {
                    FindResultsLabel.Text = String.Format("Found: {0} nodes", nodesFound.ToString());

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
            if (clearSearchResults != null)
                clearSearchResults();
        }

        /// <summary>
        /// Reset search conditions. Clear search reasults and prepare for searching from the begining
        /// </summary>
        private void ResetSearchResults()
        {
            if (clearSearchResults != null)
                clearSearchResults();

            findButton.Text = "Find";           // set initial caption for button
            FindResultsLabel.Text = "Found:";   // set initial text for status bar label
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            ResetSearchResults();
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                findButton_Click(sender, null);
        }

        private void checkSearchInNames_CheckedChanged(object sender, EventArgs e)
        {
            ResetSearchResults();
        }

        private void checkSearchInValues_CheckedChanged(object sender, EventArgs e)
        {
            ResetSearchResults();
        }

        private void checkCaseSensitive_CheckedChanged(object sender, EventArgs e)
        {
            ResetSearchResults();
        }

        private void checkExactMatch_CheckedChanged(object sender, EventArgs e)
        {
            ResetSearchResults();
        }
    }
}
