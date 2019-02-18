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
    enum objectTypePicture { Object=0, Array, Others, Text, Boolean, Number }; // enum for image indexes fro different types of json elements

    public delegate int FindByTextFunction(string searchString, SearchOptions options); // Delegate definition for searching node having specified text
    public delegate void ClearSearchResults();  // Delegate for clearing prevoius search results

    public partial class jViewForm : Form
    {
        private string jsonFileName; // name of currently loaded file
        private static List<TreeNode> searchResultNodes = new List<TreeNode>();
        private static int selectedNode = -1; // index of tree node which were selected during searching. -1 means no search was done before
        private static int nodesFound = -1; // Number of nodes were found during search. -1 means no search was done before

        private bool fileWasChanged = false;

        private void GetFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                // Load json file into Tree and text window
                LoadFileByName(dlg.FileName);
            }
        }

        private void UpdateWindowCaption()
        {
            //
            this.Text = jsonFileName;
            if (fileWasChanged == true)
                this.Text += " (*)";
        }
        
        // Load json file by it's name
        private void LoadFileByName(string FileName)
        {
            if ( LoadNodesFromFile(FileName) == true )
            {
                // file was loaded successfully
                jsonFileName = FileName;
                fileWasChanged = false;

                UpdateWindowCaption();
            }
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

                    jNodesTree.BeginUpdate();

                    TreeNode node = CreateRootNode();

                    // Load under root node in the tree all other json properties
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

        /// <summary>
        /// Load json object into tree from text window
        /// </summary>
        private void LoadNodesFromTextWindow()
        {
            if (originalFileText.Text.Length > 0 && fileWasChanged == true)
            {
                // text window contains text that can be loaded into tree and original file body was changed
                try
                {
                    JObject jParsedObject = JObject.Parse(originalFileText.Text);

                    TreeNode node = CreateRootNode();

                    jNodesTree.BeginUpdate();

                    // Load under root node in the tree all other json properties
                    LoadObjectIntoTree(jParsedObject, ref node);

                    jNodesTree.EndUpdate();
                }
                catch(Exception e)
                {
                    MessageBox.Show(String.Format("Incorrect JSON.\n{0}", e.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return;
        }

        /// <summary>
        /// Create a root node in the tree, removing all existing nodes before this operations
        /// </summary>
        /// <returns>Created root tree node</returns>
        private TreeNode CreateRootNode()
        {
            // Remove all exsting nodes before creation root one
            jNodesTree.Nodes.Clear();

            // Create new node which will be root.
            TreeNode node = new TreeNode("JSON");

            // set a picture for root node. It will be an object
            node.ImageIndex = (int)objectTypePicture.Object;

            // Add a root node to cleared collection
            jNodesTree.Nodes.Add(node);

            return node;
        }

        /// <summary>
        /// Return node image index by json token type
        /// </summary>
        /// <param name="tokenType">Token type</param>
        /// <returns>Image index</returns>
        private int GetImageIndex(JTokenType tokenType)
        {
            int ResultValue = (int)objectTypePicture.Others;

            switch (tokenType)
            {
                case JTokenType.Array:
                    ResultValue = (int)objectTypePicture.Array;
                    break;
                case JTokenType.Object:
                    ResultValue = (int)objectTypePicture.Object;
                    break;
                case JTokenType.String:
                    ResultValue = (int)objectTypePicture.Text;
                    break;
                case JTokenType.Boolean:
                    ResultValue = (int)objectTypePicture.Boolean;
                    break;
                case JTokenType.Integer:
                case JTokenType.Float:
                    ResultValue = (int)objectTypePicture.Number;
                    break;
            }

            return ResultValue;
        }

        /// <summary>
        /// Load JSON object into tree
        /// </summary>
        /// <param name="jsonObject">Object for loading into tree</param>
        /// <param name="parentNode">Parent tree node</param>
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

                        if (JTokenType.String != propertyType)
                            nodeText = property.Name + " : " + property.Value.ToString(); // this is not a string
                        else
                            nodeText = property.Name + " : \"" + property.Value + "\""; // this is a string, add extra \"

                        // add data containig json tag value
                        node.Tag = jToken;
                    }
                    else
                    {
                        nodeText = property.Name;
                    }

                    // Set proper node image
                    node.ImageIndex = node.SelectedImageIndex = GetImageIndex(propertyType);

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
                        node.ImageIndex = node.SelectedImageIndex = GetImageIndex(itemType);

                        if (JTokenType.String != itemType)
                        {
                            nodeText = String.Format("[{0}] : {1}", itemIndex.ToString(), jToken.Value<string>());
                        }
                        else
                        {
                            nodeText = String.Format("[{0}] : \"{1}\"", itemIndex.ToString(), jToken.Value<string>());
                        }

                        // Add a new node
                        node.Text = nodeText;

                        // Add tag dada
                        node.Tag = jToken;

                        parentNode.Nodes.Add(node);
                    }
                    else
                    {
                        // This is an object or array
                        nodeText = itemIndex.ToString();

                        // Set proper image index
                        node.ImageIndex = node.SelectedImageIndex = GetImageIndex(itemType);

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
        /// Show search node dialog window. Menu item handler
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
        /// <param name="options">search options defines where need to search text - in tag names or tag values</param>
        /// <returns>Number of nodes containig specified text were found.</returns>
        private int FindNodeByText(string searchText, SearchOptions options)
        {
            if (searchText.Length > 0)
            {
                // Check whether we did search before AND tree contains any node
                if (selectedNode == -1 && jNodesTree.Nodes.Count > 0)
                {
                    // searching node having received text startin with root node
                    FindNode(jNodesTree.Nodes[0].Nodes, searchText, options);
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
                        // We didn't reach the last node, so we increment found nodes counter
                        ++selectedNode;
                    }
                    // set focus on current or last found node
                    jNodesTree.SelectedNode = searchResultNodes[selectedNode];
                    jNodesTree.Focus();
                }
            }

            return nodesFound;
        }

        private void ClearSearchResult()
        {
            selectedNode = -1;
            nodesFound = -1;
            searchResultNodes.Clear();

            return;
        }

        private void FindNode(TreeNodeCollection nodes, string searchText, SearchOptions options)
        {
            // Find required node in collection
            foreach(TreeNode node in nodes)
            {
                // check if node match a condition
                CheckNode(node, searchText, options);
            }
        }

        /// <summary>
        /// Checks tree node on matching required text according to specific search conditions
        /// </summary>
        /// <param name="node">Node that should be checked</param>
        /// <param name="searchText">Search text</param>
        /// <param name="options">Search options defining where we should seacrh the text and case sensivity parameter</param>
        private void CheckNode(TreeNode node, string searchText, SearchOptions options)
        {
            string searchTextConverted;    // search text converted to case sensitive/insensitive value
            string nodeNameConverted;      // node name converted to case sensitive/insensitive value
            string convertedValue = "";     // a value linked to a node and converted to case sensitive/insensitive value
            bool hitNode = false;           // indicator showing that we found required node
            JToken jToken = (JToken)node.Tag;
            

            if (options.CaseSensitive == false)
            {
                // not sensitive comparison was chosen
                searchTextConverted = searchText.ToLower();
                nodeNameConverted = node.Name.ToLower();
                if (jToken != null)
                    if (jToken.Type != JTokenType.Null)
                        convertedValue = jToken.Value<string>().ToLower();
            }
            else
            {
                // case sensitive search options was chosen
                searchTextConverted = searchText;
                nodeNameConverted = node.Name;
                if (jToken != null)
                    convertedValue = jToken.Value<string>();
            }

            if (options.FindName == true)
            {
                // Find text in name
                if (nodeNameConverted.Contains(searchTextConverted))
                    hitNode = true;
            }

            if (options.FindValue == true)
            {
                // Find text in value
                if (convertedValue != null)
                    if (convertedValue.Length > 0)
                        if (convertedValue.Contains(searchTextConverted))
                            hitNode = true;
            }

            if (hitNode == true)
                searchResultNodes.Add(node);

            // check all child nodes
            foreach (TreeNode childNode in node.Nodes)
            {
                CheckNode(childNode, searchText, options);
            }
        }

        private void originalFileText_TextChanged(object sender, EventArgs e)
        {
            // Check whether file text was changed
            if (fileWasChanged == false)
            {
                // it was changed. Set flag to avoid caption blinking
                fileWasChanged = true;
                UpdateWindowCaption();
            }
        }

        private void loadFromTextButton_Click(object sender, EventArgs e)
        {
            LoadNodesFromTextWindow();
        }

        private void reloadTreeFromTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNodesFromTextWindow();
        }
    }
}
