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

                    jNodesTree.BeginUpdate();
                    jNodesTree.Nodes.Clear();

                    TreeNode node = new TreeNode("JSON");
                    node.ImageIndex = 0;
                    jNodesTree.Nodes.Add(node);

                    LoadJsonIntoTree(o, ref node);

                    jNodesTree.EndUpdate();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadJsonIntoTree(JObject jsonObject, ref TreeNode parentNode)
        {
            if (null != parentNode)
            {
                foreach(JProperty property in jsonObject.Properties())
                {
                    string nodeText;

                    TreeNode node = new TreeNode();
                    JToken jToken = (JToken)property.Value;
                    JTokenType propertyType = jToken.Type;

                    if (JTokenType.Object != propertyType && JTokenType.Array != propertyType)
                    {
                        if (JTokenType.String != propertyType)
                            nodeText = property.Name + ": " + property.Value.ToString();
                        else
                            nodeText = property.Name + ": \"" + property.Value.ToString() + "\"";
                    }
                    else
                        nodeText = property.Name;

                    node.Text = nodeText;
                    parentNode.Nodes.Add(node);

                    //JToken jToken = (JToken)property.Value;
                    //JTokenType propertyType = jToken.Type;

                    if (JTokenType.Object == propertyType) // add logic for arrays
                    {
                        // if this is an Object call this function again
                        LoadJsonIntoTree((JObject)jToken, ref node);
                    }
                }
            }
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
