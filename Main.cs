using Api_Buddy.Class;
using Api_Buddy.CustomControl;
using Api_Buddy.Info;
using Api_Buddy.Model;
using Api_Buddy.WebCall;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Policy;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static Api_Buddy.Model.DoubleLayerNode;
using static Api_Buddy.Model.SingleLayerNode;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//

namespace Api_Buddy
{
    public partial class Main : Form
    {

        int totalNodes = 0;
        int treeViewLevel = 0;
        string itemsLevel2Json = "";
        string highlightedNode = "";
        List<SingleLayerNodeMain> singleLayerCollections = new List<SingleLayerNodeMain>();
        SingleLayerNodeMain singleLayerNodeMain = new SingleLayerNodeMain();

        List<DoubaleLayerNodeMain> doubleLayerCollections = new List<DoubaleLayerNodeMain>();
        DoubaleLayerNodeMain doubleLayerNodeMain = new DoubaleLayerNodeMain();

        //string selectedItemBody = "";
        List<SelectectedItem.Header> selectectedItemHeader = new List<SelectectedItem.Header>();

        TreeNode rootNode = new TreeNode();
        TreeNode secondNode = new TreeNode();
        TreeNode thirdNode = new TreeNode();
        //Process gitBashProcess = new Process();
        //bool isLoadingOpen = false;
        private TreeNode lastHoveredNode;
        public Main()
        {
            InitializeComponent();


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
                //txtBody.Text = string.Empty;
                txtCurl.Text = string.Empty;

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

                    txtUrl.Text = "http://" + getSelectedHost() + "" + u.Replace(b, "").Replace(" ", "%20").Replace("'", "%27").Replace("#", "%23");
                    if (selectectedItem.request.body != null)
                    {
                        txtBody.Text = selectectedItem.request.body.raw;
                    }


                    PopulateHeaderAndBody();
                }

            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
                //Debug.WriteLine(ex.Message);
            }

        }


        private void PopulateCollectionsDoubleLayer(DoubaleLayerNodeMain doubleLayerNode)
        {
            string collectionName = doubleLayerNode.info.name;
            List<DoubleLayerNode.Item> itemsCollection = doubleLayerNode.item;
            // Root Level
            rootNode = new TreeNode(collectionName);
            rootNode.ImageIndex = 3;
            rootNode.SelectedImageIndex = 3;
            treeView.Nodes.Add(rootNode);


            foreach (var items in itemsCollection)
            {
                // Parent Level
                secondNode = new TreeNode(items.name);

                if (items.request != null)
                {


                    if (items.request.method == "POST")
                    {
                        secondNode.ImageIndex = 1;
                        secondNode.SelectedImageIndex = 1;
                    }
                    else
                    {
                        secondNode.ImageIndex = 0;
                        secondNode.SelectedImageIndex = 0;
                    }
                }
                else
                {
                    secondNode.ImageIndex = 4;
                    secondNode.SelectedImageIndex = 4;
                }


                rootNode.Nodes.Add(secondNode);

                if (items.item != null)
                {
                    foreach (var item in items.item)
                    {

                        // Child Level
                        TreeNode childNode1 = new TreeNode(item.name);

                        if (item.request.method == "GET")
                        {
                            childNode1.ImageIndex = 0;
                            childNode1.SelectedImageIndex = 0;
                        }
                        else
                        {
                            childNode1.ImageIndex = 1;
                            childNode1.SelectedImageIndex = 1;
                        }


                        secondNode.Nodes.Add(childNode1);


                    }
                }
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
            totalNodes = CountNodes(treeView.Nodes);
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
                Console.WriteLine($"Folder not found: {folderPath}");
            }




        }

        private void rb_CheckedChanged(object? sender, EventArgs e)
        {
            // Check if the sender is a RadioButton
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                // Get the text of the selected radio button
                string selectedHost = "http://" + radioButton.Text;
                changeURlBaseUrl(selectedHost);
                BuildCurlCommand(txtUrl.Text, cboMethod.Text);
            }
        }

        private void changeURlBaseUrl(string selectedHost)
        {
            string b = getBaseUrl(txtUrl.Text);

            txtUrl.Text = txtUrl.Text.Replace(b, selectedHost);
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

            string jsonContent = File.ReadAllText(AppSettings.filenameJson);
            doubleLayerNodeMain = JsonConvert.DeserializeObject<DoubaleLayerNodeMain>(jsonContent);

            Type doubleLayerClassType = typeof(DoubleLayerNode.Item);
            PropertyInfo doubleLayerItemProperty = doubleLayerClassType.GetProperty("item");

            if (doubleLayerItemProperty != null)
            {
                doubleLayerCollections.Add(doubleLayerNodeMain);
                PopulateCollectionsDoubleLayer(doubleLayerNodeMain);
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

        private void displayResponse(string response)
        {
            txtResponse.Text = formattedJson(response);

        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            //if (isLoadingOpen == false)
            //{
                //processRequest();
                ExecuteCurlCommand();
            //}
            //else
            //{

            //}

        }

        private void rbHeader_CheckedChanged(object sender, EventArgs e)
        {
            PopulateHeaderAndBody();
        }

        private void rbBody_CheckedChanged(object sender, EventArgs e)
        {
            PopulateHeaderAndBody();
        }

        private void rbCurl_CheckedChanged(object sender, EventArgs e)
        {
            PopulateHeaderAndBody();
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
            // Search for a node with the specified text
            TreeNode foundNode = FindNodeByText(treeView.Nodes, txtSearchNode.Text);

            // Check if the node is found
            if (foundNode != null)
            {
                // Expand the root node
                treeView.Nodes[0].Expand();
                //Debug.WriteLine("Node found: " + foundNode.Text);
                foreach (TreeNode node in treeView.Nodes)
                {

                    if (foundNode.Text.Equals(foundNode.Text))
                    {
                        foundNode.ForeColor = Color.Blue;

                    }
                }

            }
            else
            {
                SetDefaultNodeColor(treeView.Nodes);
            }
        }

        private void treeView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (lastHoveredNode != null)
            {
                lastHoveredNode.BackColor = Color.Empty;
            }



            // Change the background color of the current hovered node
            //e.Node.BackColor = Color.LightBlue;


            // Change the cursor to Hand when hovering over a node
            ((System.Windows.Forms.TreeView)sender).Cursor = Cursors.Hand;

            // Update the last hovered node
            lastHoveredNode = e.Node;
        }

        private void treeView_MouseLeave(object sender, EventArgs e)
        {

        }

        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //SelectNode(highlightedNode);
            }
            else if (e.KeyCode == Keys.F5)
            {
                reloadData();

            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;

            if (selectedNode != null)
            {
                treeViewLevel = GetSelectedNodeLevel(selectedNode);
                Debug.WriteLine("Selected node level: " + treeViewLevel.ToString());
            }

            if (treeViewLevel == 2)
            {
                string itemJson = extractLevel2NodesFromJson(selectedNode.Text);
                PopulateCollectionsSingleLayer(itemJson);
            }
            else if (treeViewLevel == 3)
            {

                string itemJson = extractLevel3NodesFromJson(selectedNode.Text);
                PopulateCollectionsSingleLayer(itemJson);

            }


        }

        private string extractLevel3NodesFromJson(string nodeName)
        {
            try
            {


                //PopulateCollectionsDoubleLayer(null);

                string jsonData = itemsLevel2Json;

                // Parse JSON
                JObject jsonObject = JObject.Parse(jsonData);

                // Find the node for "1 getVitalityID"
                JToken getVitalityIDNode = jsonObject["item"].FirstOrDefault(item => item["name"]?.ToString() == nodeName);

                // Check if the node exists
                if (getVitalityIDNode != null)
                {
                    // Print the result
                    //Debug.WriteLine(getVitalityIDNode.ToString());
                    return getVitalityIDNode.ToString();
                }
                //else
                //{
                //    Debug.WriteLine("Node not found");
                //}
            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Node not found";
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

        private async void button1_Click_1Async(object sender, EventArgs e)
        {
            await PostRequestAsync();

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
                    FileName = "C:\\Program Files\\Git\\bin\\bash.exe", // Adjust the path based on your Git Bash installation location
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


        private string extractLevel2NodesFromJson(string nodeName)
        {
            //PopulateCollectionsDoubleLayer(null);
            string jsonData = File.ReadAllText(AppSettings.filenameJson);
            // Parse JSON
            JObject jsonObject = JObject.Parse(jsonData);
            // Find the node for "1 getVitalityID"
            JToken getVitalityIDNode = jsonObject["item"].FirstOrDefault(item => item["name"]?.ToString() == nodeName);
            // Check if the node exists
            if (getVitalityIDNode != null)
            {
                // Print the result
                //Debug.WriteLine(getVitalityIDNode.ToString());
                itemsLevel2Json = getVitalityIDNode.ToString();
            }
            else
            {
                Debug.WriteLine("Node not found");
            }
            return itemsLevel2Json;
        }
        //

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
    }


}