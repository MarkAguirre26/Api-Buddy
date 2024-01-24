using Api_Buddy.Class;

using Api_Buddy.Info;
using Api_Buddy.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Diagnostics;
using System.DirectoryServices;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Api_Buddy.Model.DoubleLayerNode;
using static Api_Buddy.Model.SingleLayerNode;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//

namespace Api_Buddy
{
    public partial class Main : Form
    {

        string currentTxtUrlValue = "";
        string jsonCollectionContent = "";
        string originalValue = "";

        int treeViewLevel = 0;
        string itemsLevel2Json = "";
        string selectedNodeRightAfterSelect = "";
        List<(string, string, int)> nodeInfoList = new List<(string, string, int)>();

        DoubaleLayerNodeMain doubleLayerNodeMain = new DoubaleLayerNodeMain();

        List<SelectectedItem.Header> selectectedItemHeader = new List<SelectectedItem.Header>();

        TreeNode rootNode = new TreeNode();
        TreeNode secondNode = new TreeNode();
        TreeNode thirdNode = new TreeNode();

        private TreeNode lastHoveredNode;
        public Main()
        {
            InitializeComponent();
            splitContainer2.SplitterDistance = 100;
            splitContainer2.SplitterDistance = splitContainer2.Width / 2;

        }



        private void SetDefaultNodeColor(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Reset the ForeColor to the default system color
                node.ForeColor = SystemColors.ControlText;

                // Recursively set default color for child nodes
                SetDefaultNodeColor(node.Nodes);
            }
        }

        // Recursive method to search for a node with the specified text
        TreeNode FindNodeByText(TreeNodeCollection nodes, string searchText)
        {
            foreach (TreeNode node in nodes)
            {
                // Check if the current node's text matches the search text
                if (node.Text.ToLower().Equals(searchText.ToLower()))
                {
                    return node; // Node found
                }

                // Recursively search in the child nodes
                TreeNode foundInChildren = FindNodeByText(node.Nodes, searchText);
                if (foundInChildren != null)
                {
                    return foundInChildren; // Node found in child nodes
                }
            }

            return null; // Node not found
        }


        private void PopulateCollectionsSingleLayer(string itemJson)
        {
            try
            {
                txtHeader.Text = string.Empty;
                txtCurl.Text = string.Empty;
                txtBody.Text = string.Empty;
                SelectectedItem.Root selectectedItem = JsonConvert.DeserializeObject<SelectectedItem.Root>(itemJson);
                selectectedItemHeader.Clear();

                if (selectectedItem.request != null)
                {
                    foreach (var i in selectectedItem.request.header)
                    {
                        selectectedItemHeader.Add(i);
                    }

                    cboMethod.Text = selectectedItem.request.method;

                    string u = selectectedItem.request.url.raw ?? "";
                    string b = getBaseUrl(u);

                    txtUrl.Text = getSelectedHost() + "" + u.Replace(b, "").Replace(" ", "%20").Replace("'", "%27").Replace("#", "%23");
                    if (selectectedItem.request.body != null)
                    {
                        txtBody.Text = selectectedItem.request.body.raw;
                    }
                    MoveToEndTextBox();

                    PopulateHeaderAndBody();
                }

            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
                //Debug.WriteLine(ex.Message);
            }

        }



        private int CountNodes(TreeNodeCollection nodes)
        {
            int count = nodes.Count;
            foreach (TreeNode node in nodes)
            {
                count += CountNodes(node.Nodes);
            }
            return count;
        }

        //
        private void Main_Load(object sender, EventArgs e)
        {
            reloadData();

            // Assuming you want to hide the second tab (index 1)
            int tabIndexToHide = 1;

            if (tabIndexToHide >= 0 && tabIndexToHide < tabControl1.TabPages.Count)
            {
                // Hide the specified tab
                tabControl1.TabPages[tabIndexToHide].Hide();
            }

        }

        private void reloadData()
        {
            getAppSetting();
            getHostList();
            getCollections();

            lblErrors.Text = "";
        }

        private void getAppSetting()
        {
            try
            {
                Dictionary<string, string> properties = new Dictionary<string, string>();

                // Read lines from the file
                string[] lines = File.ReadAllLines("appSettings.properties");


                // Parse key-value pairs
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();
                            properties[key] = value;
                        }
                    }
                }

                // Access values by key
                if (properties.TryGetValue("createNoWindow", out string createNoWindow))
                {
                    if (createNoWindow.Equals("true"))
                    {
                        AppSettings.createNoWindow = true;
                    }
                    else
                    {
                        AppSettings.createNoWindow = false;
                    }
                }

                if (properties.TryGetValue("filenameJson", out string filenameJson))
                {
                    //Debug.WriteLine($"filenameJson: {filenameJson}");
                    AppSettings.filenameJson = filenameJson;
                }

                if (properties.TryGetValue("filenameBash", out string filenameBash))
                {
                    //Debug.WriteLine($"filenameJson: {filenameJson}");
                    AppSettings.filenameBash = filenameBash;
                }

                if (properties.TryGetValue("expandTreeviewFirstLevel", out string expandTreeviewFirstLevel))
                {
                    AppSettings.expandTreeviewFirstLevel = false;
                    if (expandTreeviewFirstLevel.Equals("true"))
                    {
                        AppSettings.expandTreeviewFirstLevel = true;
                    }
                }


                if (properties.TryGetValue("sqlFolderCollection", out string sqlFolderCollection))
                {
                    AppSettings.sqlFolderCollection = sqlFolderCollection;

                }






            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        private void getHostList()
        {


            string folderPath = "Web";
            // Check if the folder exists
            if (Directory.Exists(folderPath))
            {
                // Get all JSON files in the folder
                string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");
                treeView.Nodes.Clear();
                foreach (string txtFile in txtFiles)
                {
                    string[] txtContent = File.ReadAllLines(txtFile);
                    HostPanel.Controls.Clear();
                    foreach (string host in txtContent)
                    {
                        RadioButton rb = new RadioButton();
                        rb.AutoSize = true;
                        rb.Cursor = Cursors.Hand;
                        rb.Location = new Point(3, 3);
                        rb.Name = host.Replace(".", "").Replace("-", "");
                        rb.Size = new Size(160, 19);
                        rb.TabIndex = 2;
                        rb.TabStop = true;
                        rb.Text = host;
                        rb.UseVisualStyleBackColor = true;
                        rb.CheckedChanged += rb_CheckedChanged;
                        HostPanel.Controls.Add(rb);
                    }
                    CheckFirstRadioButton(HostPanel);
                }
            }
            else
            {
                Debug.WriteLine($"Folder not found: {folderPath}");
            }




        }

        private void rb_CheckedChanged(object? sender, EventArgs e)
        {
            // Check if the sender is a RadioButton
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                // Get the text of the selected radio button
                string selectedHost = radioButton.Text;
                changeURlBaseUrl(selectedHost);
                BuildCurlCommand(txtUrl.Text, cboMethod.Text);
            }
        }

        private void changeURlBaseUrl(string selectedHost)
        {
            string b = getBaseUrl(txtUrl.Text);

            txtUrl.Text = txtUrl.Text.Replace(b, selectedHost);
            MoveToEndTextBox();
        }

        private void CheckFirstRadioButton(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = true;
                    break; // Stop after checking the first RadioButton
                }
            }
        }


        private void getCollections()
        {


            // Get all JSON files in the folder           
            treeView.Nodes.Clear();

            jsonCollectionContent = File.ReadAllText(AppSettings.filenameJson);
            nodeInfoList = ExtractNodeInfo(jsonCollectionContent);

            Debug.WriteLine("Node Information:");
            populateTreeView(nodeInfoList);
        }
        private void populateTreeViewFromSearch(List<(string, string, int)> nodeInfoList)
        {
            treeView.Nodes.Clear();
            foreach ((string nodeName, string method, int nodeLevel) in nodeInfoList)
            {

                TreeNode rootNodeFromSearch = new TreeNode(nodeName);

                if (method == "POST")
                {
                    rootNodeFromSearch.ImageIndex = 1;
                    rootNodeFromSearch.SelectedImageIndex = 1;
                }
                else if (method == "GET")
                {
                    rootNodeFromSearch.ImageIndex = 0;
                    rootNodeFromSearch.SelectedImageIndex = 0;
                }
                else if (method == "PUT")
                {
                    rootNodeFromSearch.ImageIndex = 8;
                    rootNodeFromSearch.SelectedImageIndex = 8;
                }
                else
                {
                    rootNodeFromSearch.ImageIndex = 4;
                    rootNodeFromSearch.SelectedImageIndex = 4;
                }
                treeView.Nodes.Add(rootNodeFromSearch);


            }

        }


        private void populateTreeView(List<(string, string, int)> nodeInfoList)
        {
            treeView.Nodes.Clear();
            foreach ((string nodeName, string method, int nodeLevel) in nodeInfoList)
            {

                if (nodeLevel == 0)
                {
                    rootNode = new TreeNode(nodeName);
                    rootNode.ImageIndex = 3;
                    rootNode.SelectedImageIndex = 3;
                    treeView.Nodes.Add(rootNode);
                }
                else if (nodeLevel == 1)
                {
                    secondNode = new TreeNode(nodeName);

                    if (method == "POST")
                    {
                        secondNode.ImageIndex = 1;
                        secondNode.SelectedImageIndex = 1;
                    }
                    else if (method == "GET")
                    {
                        secondNode.ImageIndex = 0;
                        secondNode.SelectedImageIndex = 0;
                    }
                    else if (method == "PUT")
                    {
                        secondNode.ImageIndex = 8;
                        secondNode.SelectedImageIndex = 8;
                    }
                    else
                    {
                        secondNode.ImageIndex = 4;
                        secondNode.SelectedImageIndex = 4;
                    }

                    rootNode.Nodes.Add(secondNode);
                }
                else if (nodeLevel == 2)
                {
                    TreeNode childNode = new TreeNode(nodeName);

                    if (method == "POST")
                    {
                        childNode.ImageIndex = 1;
                        childNode.SelectedImageIndex = 1;
                    }
                    else if (method == "GET")
                    {
                        childNode.ImageIndex = 0;
                        childNode.SelectedImageIndex = 0;
                    }
                    secondNode.Nodes.Add(childNode);
                }

            }
            if (AppSettings.expandTreeviewFirstLevel.Equals(true))
            {
                ExpandFirstLayer();
            }




        }
        private void ExpandFirstLayer()
        {
            // Check if there are root nodes
            if (treeView.Nodes.Count > 0)
            {
                // Expand each root node
                foreach (TreeNode rootNode in treeView.Nodes)
                {
                    rootNode.Expand();
                }
            }
        }

        static List<(string, string, int)> ExtractNodeInfo(string jsonString)
        {
            List<(string, string, int)> nodeInfo = new List<(string, string, int)>();

            JObject jsonObject = JObject.Parse(jsonString);

            // Extract info from "info"
            string infoName = (string)jsonObject["info"]["name"];
            nodeInfo.Add((infoName, "", 0));

            // Extract names and methods recursively from "item"
            ExtractNodeInfoFromItem(jsonObject["item"], nodeInfo, 1);

            return nodeInfo;
        }

        static void ExtractNodeInfoFromItem(JToken itemToken, List<(string, string, int)> nodeInfo, int currentLevel)
        {
            if (itemToken != null)
            {
                foreach (JToken subItemToken in itemToken.Children())
                {
                    string itemName = (string)subItemToken["name"];
                    string method = (string)subItemToken["request"]?["method"];
                    nodeInfo.Add((itemName, method ?? "", currentLevel));

                    // Recursively extract names and methods from nested "item"
                    ExtractNodeInfoFromItem(subItemToken["item"], nodeInfo, currentLevel + 1);
                }
            }
        }

        private string getBaseUrl(string input)
        {
            // Define a regular expression pattern to match the base URL
            string pattern = @"^(https?://[^/]+)";

            // Use Regex.Match to find the match in the input URL
            Match match = Regex.Match(input, pattern);

            // Check if a match is found
            if (match.Success)
            {
                // The first capturing group (index 1) contains the base URL
                return match.Groups[1].Value;
            }
            else
            {
                // No match found, return an empty string or handle accordingly
                return "-";
            }
        }

        private string formattedJson(string jsonString)
        {

            string result = "";
            try
            {
                JToken parsedJson = JToken.Parse(jsonString);
                string formattedJson = parsedJson.ToString(Formatting.Indented);

                result = formattedJson;
            }
            catch (JsonReaderException ex)
            {
                Debug.WriteLine("Invalid JSON format: " + ex.Message);
                //MessageBox.Show($"Invalid JSON format: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtResponse.Text = jsonString;
            }
            return result;
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            JObject root = JsonConvert.DeserializeObject<JObject>(jsonCollectionContent);

            JToken resultNode = FindAndExtractNode(root["item"], e.Node.Text);

            if (!txtSearchNode.Text.ToLower().Contains("sql:"))
            {
                if (resultNode != null)
                {
                    string selectedNodeItem = resultNode.ToString();

                    PopulateCollectionsSingleLayer(selectedNodeItem);

                }
                else
                {
                    Debug.WriteLine("Node not found");
                }

            }
            else
            {
                if (e.Node.Tag != null)
                {
                    string filePath = e.Node.Tag.ToString();
                    // You can perform actions based on the selected file path (e.g., open the file)
                    Console.WriteLine($"Double-clicked on file: {filePath}");
                    string sqlContent = File.ReadAllText(AppSettings.sqlFolderCollection + "/" + filePath);
                    txtResponse.Text = sqlContent;

                }
            }
        }
        //
        static JToken FindAndExtractNode(JToken items, string nodeToSearch)
        {
            if (items != null && items.Type == JTokenType.Array)
            {
                Debug.WriteLine(nodeToSearch);
                foreach (var item in items)
                {
                    var itemName = item["name"]?.ToString();
                    if (itemName == nodeToSearch)
                    {
                        // Extract the entire node
                        return item;
                    }

                    var subItems = item["item"];
                    if (subItems != null && subItems.Type == JTokenType.Array)
                    {
                        // Recursively search for "instructionBasedEnrolment - cancel" in sub-items
                        var result = FindAndExtractNode(subItems, nodeToSearch);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                }
            }

            return null;

        }
        private void SelectNode(string selectedNode)
        {
            //string selectedNode = e.Node.Text;
            txtHeader.Text = string.Empty;
            txtBody.Text = string.Empty;
            txtCurl.Text = string.Empty;
            txtResponse.Text = string.Empty;

            string headersContent = string.Empty;



        }



        private string getSelectedHost()
        {
            string host = "";
            foreach (Control control in HostPanel.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    host = radioButton.Text;
                }
            }

            return host;
        }

        private void PopulateHeaderAndBody()
        {


            string headersContent = "";


            if (tabControl1.SelectedTab == BodyTab)
            {
                //txtBody.Text = selectedItemBody;
                tabControl1.SelectedTab = BodyTab;
            }
            else if (tabControl1.SelectedTab == CurlTab)
            {
                txtCurl.Text = BuildCurlCommand(txtUrl.Text, cboMethod.Text);
                tabControl1.SelectedTab = CurlTab;

                // Assuming textBox1 is the name of your TextBox
                MoveToEndTextBox();
            }
            else if (tabControl1.SelectedTab == HeaderTab)
            {

                foreach (var i in selectectedItemHeader)
                {
                    headersContent += "\n" + i.key + "/" + i.value;

                }
                int index = headersContent.IndexOf('\n');
                if (index != -1)
                {
                    // Remove the first line
                    string resultString = headersContent.Substring(index + 1);

                    // Now, resultString contains the string with the first line removed
                    txtHeader.Text = resultString;
                    tabControl1.SelectedTab = HeaderTab;
                }
                else
                {
                    // If there is no newline character, handle it accordingly
                    Console.WriteLine("No newline character found in the string.");
                }



            }
        }

        private void MoveToEndTextBox()
        {
            txtUrl.SelectionStart = txtUrl.Text.Length;
            txtUrl.SelectionLength = 0;
            txtUrl.ScrollToCaret();
        }


        private void cmdSend_Click(object sender, EventArgs e)
        {

            ExecuteCurlCommand();


            saveNewData();

        }

        private void saveNewData()
        {


            string[] jsonContent = File.ReadAllLines(AppSettings.filenameJson);
            string updatedJson = "";

            foreach (string s in jsonContent)
            {
                if (s.Contains(currentTxtUrlValue))
                {
                    string updatedLine = s.Replace(currentTxtUrlValue, txtUrl.Text);
                    updatedJson += updatedLine + Environment.NewLine;
                }
                else
                {
                    updatedJson += s + Environment.NewLine;
                }
            }

            // Save the updated JSON to the file
            File.WriteAllText(AppSettings.filenameJson, updatedJson);


        }



        string BuildCurlCommand(string url, string method)
        {
            // Start with the basic cURL command
            string curlCommand = $"curl --location --request {method} '{url}' \\{Environment.NewLine}";
            // Add seingleLayerHeaders to the cURL command
            foreach (var header in selectectedItemHeader)
            {

                if (txtBody.Text.Length > 0)
                {
                    curlCommand += $"--header \'{header.key}: {header.value}' \\{Environment.NewLine}";
                }
                else
                {
                    curlCommand += $"--header \'{header.key}: {header.value}'";
                }
            }
            if (txtBody.Text.Length > 0)
            {
                curlCommand += $@"--data '{txtBody.Text}'";
            }
            // Add the URL

            txtCurl.Text = curlCommand;
            //curlCommand = ReplaceSingleQuotes(curlCommand);
            // Return the final cURL command
            return curlCommand.Replace("''", "'");
        }


        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {


            foreach (TreeNode node in treeView.Nodes)
            {
                if (e.Node.Level == 1)
                {
                    e.Node.ImageIndex = 5;
                    e.Node.SelectedImageIndex = 5;
                }
                else if (e.Node.Level == 0)
                {
                    e.Node.ImageIndex = 2;
                    e.Node.SelectedImageIndex = 2;
                }

            }
        }

        private void treeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {

            foreach (TreeNode node in treeView.Nodes)
            {

                if (e.Node.Level == 1)
                {
                    e.Node.ImageIndex = 4;
                    e.Node.SelectedImageIndex = 4;
                }
                else if (e.Node.Level == 0)
                {
                    e.Node.ImageIndex = 3;
                    e.Node.SelectedImageIndex = 3;
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



            if (txtSearchNode.Text != "")
            {

                if (txtSearchNode.Text.Contains("sql:"))
                {
                    SearchSqlFiles(txtSearchNode.Text);
                }
                else
                {
                    string searchNodeName = txtSearchNode.Text;
                    var searchResults = SearchNodesByName(nodeInfoList, searchNodeName);

                    populateTreeViewFromSearch(searchResults);
                }
            }
            else
            {


                populateTreeView(nodeInfoList);
            }







        }

        private void SearchSqlFiles(string searchPattern)
        {

            string folderPath = AppSettings.sqlFolderCollection;
            try
            {



                string[] files = Directory.GetFiles(folderPath, "*.sql");

                List<string> sqlFiles = files.ToList();



                if (sqlFiles.Count > 0)
                {
                    treeView.Nodes.Clear();
                    foreach (string sql in sqlFiles)
                    {
                        TreeNode node = new TreeNode(Path.GetFileName(sql));
                        if (sql.ToLower().Contains(txtSearchNode.Text.Replace("sql:", "").ToLower()))
                        {

                            node.Tag = Path.GetFileName(sql); // Store the full file path in the Tag property for later use
                            treeView.Nodes.Add(node);

                        }
                        else
                        {
                            //node.Tag = Path.GetFileName(sql); // Store the full file path in the Tag property for later use
                            //treeView.Nodes.Add(node);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        static List<(string, string, int)> SearchNodesByName(List<(string, string, int)> nodeInfo, string nodeName)
        {
            return nodeInfo.FindAll(node => node.Item1.ToLower().Contains(nodeName.ToLower()));
        }



        private void treeView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (lastHoveredNode != null)
            {
                lastHoveredNode.BackColor = Color.Empty;
            }



            // Change the cursor to Hand when hovering over a node
            ((System.Windows.Forms.TreeView)sender).Cursor = Cursors.Hand;

            // Update the last hovered node
            lastHoveredNode = e.Node;
        }

        private void treeView_MouseLeave(object sender, EventArgs e)
        {

        }

        static void DeleteNode(JToken token, string nodeName)
        {
            if (token.Type == JTokenType.Object)
            {
                foreach (var child in token.Children<JProperty>().ToList())
                {
                    if (child.Name == nodeName)
                    {
                        child.Remove();
                    }
                    else
                    {
                        DeleteNode(child.Value, nodeName);
                    }
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (var item in token.Children())
                {
                    DeleteNode(item, nodeName);
                }
            }
        }


        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                reloadData();

            }


        }




        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;

            if (selectedNode != null)
            {
                selectedNodeRightAfterSelect = e.Node.Text;
                treeViewLevel = GetSelectedNodeLevel(selectedNode);
                Debug.WriteLine("Selected node: " + selectedNodeRightAfterSelect);

            }


        }

        private int GetSelectedNodeLevel(TreeNode selectedNode)
        {
            int level = 0;

            while (selectedNode != null)
            {
                selectedNode = selectedNode.Parent;
                level++;
            }

            return level;
        }



        private void txtSearchNode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Expand the root node
                //treeView.Nodes[0].Expand();
                treeView.SelectedNode = treeView.Nodes[0];
                treeView.SelectedNode.EnsureVisible();
                treeView.Nodes[0].BackColor = Color.LightBlue;

            }
            else if (e.KeyCode == Keys.Right)
            {

                // Expand the root node
                treeView.Nodes[0].Expand();
                //treeView.SelectedNode = treeView.Nodes[0];
                //treeView.SelectedNode.EnsureVisible();
                //treeView.Nodes[0].BackColor = Color.LightBlue;


            }
        }



        private async Task PostRequestAsync()
        {


            ExecuteCurlCommand();
        }


        private async Task ExecuteCurlCommand()
        {
            string curlCommand = BuildCurlCommand(txtUrl.Text, cboMethod.Text);

            //CustomLoadingForm wait = new CustomLoadingForm();
            try
            {
                //wait.Show(this, "Processing...");
                cmdSend.Enabled = false;
                txtResponse.Text = "Processing Request...";
                //isLoadingOpen = true;


                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = AppSettings.filenameBash, // Adjust the path based on your Git Bash installation location
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = AppSettings.createNoWindow
                };

                Process gitBashProcess = new Process
                {
                    StartInfo = startInfo
                };

                gitBashProcess.Start();



                // Send the curl command to Git Bash
                await Task.Run(() =>
                {
                    gitBashProcess.StandardInput.WriteLine(curlCommand);
                    gitBashProcess.StandardInput.WriteLine("exit"); // Close the bash session after executing the command
                });

                // Read the output asynchronously
                string output = await Task.Run(() => gitBashProcess.StandardOutput.ReadToEnd());
                string error = await Task.Run(() => gitBashProcess.StandardError.ReadToEnd());

                gitBashProcess.WaitForExit();

                // Output and error can be used as needed
                //Debug.WriteLine("Output: " + output);
                Debug.WriteLine("Error: " + error);
                //txtResponse.Text = error;
                if (IsValidJson(output))
                {
                    txtResponse.Text = formattedJson(output) ?? "No Response";
                }
                else
                {
                    txtResponse.Text = output;
                }
                cmdSend.Enabled = true;
                //wait.Close();
                //isLoadingOpen = false;

            }
            catch (Exception ex)
            {
                cmdSend.Enabled = true;
                //isLoadingOpen = false;
                //wait.Close();
                txtResponse.Text = ex.Message;
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), SystemApp.NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }

        bool IsValidJson(string jsonString)
        {
            try
            {
                JsonDocument.Parse(jsonString);
                return true;
            }
            catch (System.Text.Json.JsonException)
            {
                return false;
            }
        }




        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Debug.WriteLine("Save data here");
                e.SuppressKeyPress = true;

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateHeaderAndBody();
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }


        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

            if (e.Label != null)
            {


                // Parse JSON
                JObject jsonObject = JObject.Parse(jsonCollectionContent);

                // Traverse the JSON and replace the value
                ReplaceJsonValue(jsonObject, originalValue, e.Label);

                // Convert the modified JSON object back to string
                string modifiedJsonString = jsonObject.ToString();

                // Save the modified JSON to a file
                File.WriteAllText(AppSettings.filenameJson, modifiedJsonString);



            }
        }


        void ReplaceJsonValue(JToken token, string oldValue, string newValue)
        {
            if (token.Type == JTokenType.Object)
            {
                foreach (JProperty prop in token.Children<JProperty>().ToList())
                {
                    if (prop.Value.Type == JTokenType.String && prop.Value.ToString() == oldValue)
                    {
                        prop.Value = newValue;
                    }
                    else
                    {
                        ReplaceJsonValue(prop.Value, oldValue, newValue);
                    }
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (JToken arrayItem in token.Children())
                {
                    ReplaceJsonValue(arrayItem, oldValue, newValue);
                }
            }
        }


        private void treeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // Allow editing for all nodes.
            originalValue = e.Node.Text;
            Debug.WriteLine("Before Edit");
            e.CancelEdit = false;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchText = txtSearchFromResponse.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    // Start searching from the beginning of the text
                    int startIndex = 0;

                    // Search for the text and get the index of the found text
                    int foundIndex = txtResponse.Find(searchText, startIndex, RichTextBoxFinds.None);

                    // Check if the text is found
                    if (foundIndex != -1)
                    {
                        // Select the found text
                        txtResponse.Select(foundIndex, searchText.Length);

                        // Set the focus to the RichTextBox
                        txtResponse.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Not found.");
                    }
                }
            }
        }

        private void txtUrl_Enter(object sender, EventArgs e)
        {
            currentTxtUrlValue = txtUrl.Text;
        }

        private void viewSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", "Collections");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening folder: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            saveNewData();
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                ExecuteCurlCommand();


                saveNewData();
            }
        }
    }


}