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
    enum objectTypePicture { Object=0, Array, Others, Text }; // enum for image indexes fro different types of json elements

    public delegate int FindByTextFunction(string searchString); // Delegate definition for searching node having specified text
    public delegate void ClearSearchResults();  // Delegate for clearing prevoius search results

    public partial class jViewForm : Form
    {
        private string jsonFileName;
        //private static TreeNode[] searchResultNodes = new TreeNode[0]; // List of tree nodes were found
        private static List<TreeNode> searchResultNodes = new List<TreeNode>();
        private static int selectedNode = -1; // index of tree node which were selected durong searching. -1 means no search was done before
        private static int nodesFound = -1; // Number of nodes were found during search. -1 means no search was done before

        private void GetFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                jsonFileName = dlg.FileName;

                // Load json file into Tree and text window
                //LoadNodesFromFile(jsonFileName);
                LoadFileByName(jsonFileName);

                //this.Text = jsonFileName;
            }
        }
        private bool LoadFileByName(string FileName)
        {
            //
            bool RetValue = false;

            RetValue = LoadNodesFromFile(FileName);

            if (RetValue == true)
                this.Text = FileName;

            return RetValue;
        }

        private bool LoadNodesFromFile(string FileName)
        {
            bool retValue = false;

            // try to read the file and load it into json object
            try
            {
                using (StreamReader file = File.OpenText(FileName))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = JObject.Load(reader);

                    // Load file in text control
                    originalFileText.Text = o.ToString();

                    //Load nodes into tree
                    //TreeNode rootNode = null;

                    jNodesTree.BeginUpdate();
                    jNodesTree.Nodes.Clear();

                    TreeNode node = new TreeNode("JSON");
                    node.ImageIndex = 0;
                    jNodesTree.Nodes.Add(node);

                    LoadObjectIntoTree(o, ref node);

                    jNodesTree.EndUpdate();

                    retValue = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retValue;
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

                        if (propertyType == JTokenType.String)
                        {
                                node.ImageIndex = node.SelectedImageIndex = (int)objectTypePicture.Text;
                        }
                        else
                        {
                            // This is not an object or an array or string
                            node.ImageIndex = node.SelectedImageIndex = (int)objectTypePicture.Others;
                        }

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
                    node.Name = property.Name; // set node name as tag name for searching purpose

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
                            //nodeText = itemIndex.ToString() + " : " + ((JProperty)jToken).Value.ToString();
                            nodeText = itemIndex.ToString() + " : " + jToken.Value<string>();
                        else
                        {
                            //JProperty prop = jToken.Value<JProperty>();
                            //string tokenValue = jToken.Value<string>();
                            nodeText = itemIndex.ToString() + " : \"" + jToken.Value<string>() + "\"";

                            //nodeText = itemIndex.ToString() + ": \"" + ((JProperty)jToken).Value + "\"";
                        }

                        // Add a new node
                        node.Text = nodeText;
                        //node.Name = ; // set node name as tag name for searching purpose

                        parentNode.Nodes.Add(node);
                    }
                    else
                    {
                        // This is an object or array
                        nodeText = itemIndex.ToString();

                        // Set proper image index
                        if (JTokenType.Object == itemType)
                            node.ImageIndex = node.SelectedImageIndex = (int)objectTypePicture.Object;
                        else if (JTokenType.Array == itemType)
                                node.ImageIndex = node.SelectedImageIndex = (int)objectTypePicture.Array;

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
        private void LoadDroppedFile(DragEventArgs e)
        {
            //
            string fileName;

            Array data = ((IDataObject)e.Data).GetData("FileNameW") as Array;
            if (data != null)
            {
                if ((data.Length == 1) && (data.GetValue(0) is String))
                {
                    fileName = ((string[])data)[0];
                    LoadFileByName(fileName);
                }
            }
        }

        private bool CheckDragArguments(ref DragEventArgs e)
        {
            bool returnValue = true;

            e.Effect = DragDropEffects.None;

            // Get going to be dropped file name
            Array data = ((IDataObject)e.Data).GetData("FileNameW") as Array;
            if (data != null)
            {
                // try to read the file and load it into json object
                string fileName = ((string[])data)[0];

                try
                {
                    using (StreamReader file = File.OpenText(fileName))
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject o = JObject.Load(reader);
                    }
                    e.Effect = DragDropEffects.Copy;
                }
                catch (Exception ex)
                {
                    returnValue = false;
                }
            }

            return returnValue;
        }

        private void jNodesTree_DragDrop(object sender, DragEventArgs e)
        {
            //
            LoadDroppedFile(e);
        }

        private void jNodesTree_DragEnter(object sender, DragEventArgs e)
        {
            CheckDragArguments(ref e);
        }

        private void originalFileText_DragDrop(object sender, DragEventArgs e)
        {
            //
            LoadDroppedFile(e);
        }

        private void originalFileText_DragEnter(object sender, DragEventArgs e)
        {
            CheckDragArguments(ref e);
        }

        /// <summary>
        /// Search node functionality. Menu item handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchNodeMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm dlg = new SearchForm(FindNodeByText, ClearSearchResult);
            dlg.Show();
        }

        /// <summary>
        ///  Find node matching with specified text in the Name property
        /// </summary>
        /// <param name="searchText">text we are looking for</param>
        /// <returns>Number of nodes containig specified text were found.</returns>
        private int FindNodeByText(string searchText)
        {
            if (searchText.Length > 0)
            {
                // Check whether we did search before
                if (selectedNode == -1 && jNodesTree.Nodes.Count > 0)
                {
                    // searching node having received text
                    //searchResultNodes = jNodesTree.Nodes.Find(searchText, true);
                    FindNode(jNodesTree.Nodes[0].Nodes, searchText);
                    //nodesFound = searchResultNodes.Length;
                    nodesFound = searchResultNodes.Count;

                    if (nodesFound > 0)
                    {
                        // Take first found node and set focus on it
                        selectedNode = 0;
                        jNodesTree.SelectedNode = searchResultNodes[selectedNode];
                        jNodesTree.Focus();
                    }
                }
                else
                {
                    // we did search before. Set focus on the next found element
                    if (selectedNode < (nodesFound-1))
                    {
                        //
                        //++selectedNode;
                        jNodesTree.SelectedNode = searchResultNodes[++selectedNode];
                        jNodesTree.Focus();
                    }
                }
            }

            return nodesFound;
        }

        private void ClearSearchResult()
        {
            //if (searchResultNodes.Length > 0)
            //    Array.Clear(searchResultNodes, 0, nodesFound);

            selectedNode = -1;
            nodesFound = -1;
            searchResultNodes.Clear();

            return;
        }

        private void FindNode(TreeNodeCollection nodes, string searchText)
        {
            // Find required node in collection
            foreach(TreeNode node in nodes)
            {
                // check if node match a condition
                CheckNodeName(node, searchText);
            }
        }

        private void CheckNodeName(TreeNode node, string searchText)
        {
            //
            if (node.Name.Contains(searchText))
            {
                // we found a node having specified text string
                searchResultNodes.Add(node);
            }

            // check all child nodes
            foreach (TreeNode childNode in node.Nodes)
            {
                CheckNodeName(childNode, searchText);
            }
        }
    }
}
