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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jView
{
    public partial class jViewForm : Form
    {
        private string jsonFileName;

        private void GetFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                jsonFileName = dlg.FileName;

                // Load json file into Tree and text window
                LoadNodesFromFile(jsonFileName);

                this.Text = jsonFileName;
            }
        }

        private void LoadNodesFromFile(string FileName)
        {
            // try to read the file and load it into json object
            try
            {
                using (StreamReader file = File.OpenText(FileName))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = JObject.Load(reader);
                    originalFileText.Text = o.ToString();

                    //Load nodes into tree
                    TreeNode rootNode = null;

                    LoadJsonIntoTree(o, ref rootNode);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadJsonIntoTree(JObject jsonObject, ref TreeNode parentNode)
        {
            //
            jNodesTree.BeginUpdate();

            if (null == parentNode)
            {
                jNodesTree.Nodes.Clear();

                TreeNode node = new TreeNode("JSON");

                jNodesTree.Nodes.Add(node);

                //jNodesTree.Nodes[0].Nodes.Add(new TreeNode("Item 1"));
                //node.Nodes.Add(new TreeNode("Item 1"));
            }

            jNodesTree.EndUpdate();
        }

        public jViewForm()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            //
            GetFile();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            //
            GetFile();
        }
    }
}
