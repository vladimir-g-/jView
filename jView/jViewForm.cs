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
    enum objectTypePicture { Object=0, Array, Others };

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

                    LoadObjectIntoTree(o, ref node);

                    jNodesTree.EndUpdate();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadObjectIntoTree(JObject jsonObject, ref TreeNode parentNode)
        {
            if (null != parentNode)
            {
                foreach(JProperty property in jsonObject.Properties())
                {
                    string nodeText;

                    TreeNode node = new TreeNode();
                    JToken jToken = (JToken)property.Value;
                    JTokenType propertyType = jToken.Type;

                    // Create proper node text
                    if (JTokenType.Object != propertyType && JTokenType.Array != propertyType)
                    {
                        // This is not an object or an array
                        node.ImageIndex = node.SelectedImageIndex = (int)objectTypePicture.Others;

                        if (JTokenType.String != propertyType)
                            nodeText = property.Name + " : " + property.Value.ToString();
                        else
                            nodeText = property.Name + " : \"" + property.Value + "\"";
                    }
                    else
                    {
                        nodeText = property.Name;
                    }

                    // Set proper node image
                    if (JTokenType.Object == propertyType)
                    {
                        node.ImageIndex = node.SelectedImageIndex = (int)objectTypePicture.Object; // Set images for object node
                    }
                    else
                        if (JTokenType.Array == propertyType)
                            node.ImageIndex = node.SelectedImageIndex = (int)objectTypePicture.Array; // Set image for array  node

                    node.Text = nodeText;
                    parentNode.Nodes.Add(node);

                    if (JTokenType.Object == propertyType) 
                    {
                        // if this is an Object, call this function again
                        LoadObjectIntoTree((JObject)jToken, ref node);
                    }
                    else if (JTokenType.Array == propertyType)
                    {
                        // This is an array. Process it as array
                        LoadArrayIntoTree((JArray)jToken, ref node);
                    }
                }
            }
        }

        // Load array into tree view
        private void LoadArrayIntoTree(JArray jsonArray, ref TreeNode parentNode)
        {
            if (jsonArray.Count > 0)
            {
                //int itemIndex = 0;
                JTokenType itemType;
                JToken jToken;
                string nodeText;
                TreeNode node;

                // Array is not empty
                //foreach (JToken jToken in jsonArray)
                for (int itemIndex=0; itemIndex < jsonArray.Count; itemIndex++)
                {
                    // Process each token in the array
                    jToken = jsonArray[itemIndex];

                    // item type
                    itemType = jToken.Type;
                    
                    // Create tree node
                    node = new TreeNode();

                    // Create proper node text
                    if (JTokenType.Object != itemType && JTokenType.Array != itemType)
                    {
                        // This is not an object or an array
                        node.ImageIndex = node.SelectedImageIndex = (int)objectTypePicture.Others;

                        if (JTokenType.String != itemType)
                            nodeText = itemIndex.ToString() + " : " + ((JProperty)jToken).Value.ToString();
                        else
                        {
                            //JProperty prop = jToken.Value<JProperty>();
                            //string tokenValue = jToken.Value<string>();
                            nodeText = itemIndex.ToString() + " : \"" + jToken.Value<string>() + "\"";

                            //nodeText = itemIndex.ToString() + ": \"" + ((JProperty)jToken).Value + "\"";
                        }

                        // Add a new node
                        node.Text = nodeText;
                        parentNode.Nodes.Add(node);
                    }
                    else
                    {
                        // This is an object or array
                        nodeText = itemIndex.ToString();

                        // Set proper image index
                        if (JTokenType.Object == itemType)
                            node.ImageIndex = (int)objectTypePicture.Object;
                        else if (JTokenType.Array == itemType)
                                node.ImageIndex = (int)objectTypePicture.Array;

                        // Add a new node
                        node.Text = nodeText;
                        parentNode.Nodes.Add(node);

                        if (JTokenType.Object == itemType)
                        {
                            // Load a new object
                            LoadObjectIntoTree((JObject)jToken, ref node);
                        }
                        else if (JTokenType.Array == itemType)
                        {
                            // Load an array
                            LoadArrayIntoTree((JArray)jToken, ref node);
                        }
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
