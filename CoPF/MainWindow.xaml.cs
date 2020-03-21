using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace CoPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Audio 
        DataIO io = new DataIO();
        Regex regex;
        //static public string Path { get; set; }
        //static public string ProjectName { get; set; }
        static public List<string> namePrefixes;
        static public List<string> userFolders = new List<string>();
        static public List<string> customFolders = new List<string>();
        string folderNamePattern = @"^[A-Za-z0-9-_\[\]{}!@#$%^&\(\) +=.,;`~№]+$";
        List<System.Windows.Controls.CheckBox> foldersList;


        public MainWindow()
        {
            InitializeComponent();
            cb_prefix.IsChecked = true;
            cb_namePrefix.IsChecked = true;
            cb_renders.IsChecked = true;
            LoadPrefixes();
            foldersList = new List<System.Windows.Controls.CheckBox>() {cb_drawings, cb_models, cb_ideas, cb_photo, cb_proxy, cb_references, cb_renders};
        }



        // METHODS
        void LoadPrefixes()
        {
            namePrefixes = io.ReadData();
            comboPrefixList.ItemsSource = namePrefixes;
        }

        // EVENTS
        private void Cb_prefix_Checked(object sender, RoutedEventArgs e)
        {
            tb_prefix.IsEnabled = true;
        }

        private void Cb_prefix_Unchecked(object sender, RoutedEventArgs e)
        {
            tb_prefix.IsEnabled = false;
        }

        private void Bt_browse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                tb_path.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Cb_namePrefix_Checked(object sender, RoutedEventArgs e)
        {
            comboPrefixList.IsEnabled = true;
            bt_addNewPrefix.IsEnabled = true;
            tb_newPrefix.IsEnabled = true;
            bt_removePrefix.IsEnabled = true;
        }

        private void Cb_namePrefix_Unchecked(object sender, RoutedEventArgs e)
        {
            comboPrefixList.IsEnabled = false;
            bt_addNewPrefix.IsEnabled = false;
            tb_newPrefix.IsEnabled = false;
            bt_removePrefix.IsEnabled = false;
        }

        private void Bt_addNewPrefix_Click(object sender, RoutedEventArgs e)
        {
            regex = new Regex(folderNamePattern);

            if (regex.IsMatch(tb_newPrefix.Text))
            {
                if (tb_newPrefix.Text != "" && namePrefixes.Contains(tb_newPrefix.Text) == false)
                {
                    namePrefixes.Add(tb_newPrefix.Text);
                    comboPrefixList.ItemsSource = namePrefixes;
                    comboPrefixList.Items.Refresh();
                    io.WriteData(namePrefixes);
                    tb_newPrefix.Text = string.Empty;
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Prefix contains invalid characters:\nА-Я / \\ | : * ? “ < >","Error");
            }
        }

        private void Bt_removePrefix_Click(object sender, RoutedEventArgs e)
        {
            if (comboPrefixList.SelectedItem != null)
            {
                namePrefixes.Remove(comboPrefixList.SelectedValue.ToString());
                comboPrefixList.ItemsSource = namePrefixes;
                comboPrefixList.Items.Refresh();
                io.WriteData(namePrefixes);
            }
        }

        private void Tb_prefix_TextChanged(object sender, TextChangedEventArgs e)
        {
            regex = new Regex(folderNamePattern);
            if (tb_prefix.Text != "")
            {
                if (!regex.IsMatch(tb_prefix.Text))
                {
                    System.Windows.MessageBox.Show("Prefix contains invalid characters:\nА-Я / \\ | : * ? “ < >", "Error");
                    tb_prefix.Text = "_";
                }
            }

        }


        //CREATE
        private void Bt_create_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tb_projectName.Text))
            {
                System.Windows.MessageBox.Show("Enter the Project Name!");
                return;
            }
            regex = new Regex(folderNamePattern);
            if (!regex.IsMatch(tb_projectName.Text))
            {
                System.Windows.MessageBox.Show("Project name contains invalid characters:\nА-Я / \\ | : * ? “ < >", "Error");
                return;
            }
            string projectPath;
            if ((bool)cb_namePrefix.IsChecked && comboPrefixList.SelectedValue != null)
            {
                projectPath = tb_path.Text + "\\" + comboPrefixList.SelectedValue.ToString() + "-" + tb_projectName.Text;
            }
            else
            {
                projectPath = tb_path.Text + "\\" + tb_projectName.Text;
            }

            DirectoryInfo projectDir = new DirectoryInfo(projectPath);
            try
            {
                if (!projectDir.Exists)
                {
                    projectDir.Create();

                    foreach (System.Windows.Controls.CheckBox checkBox in foldersList)
                    {
                        if ((bool)cb_prefix.IsChecked)
                        {
                            if ((bool)checkBox.IsChecked)
                            {
                                if (checkBox.Name != "cb_renders")
                                {
                                    projectDir.CreateSubdirectory(tb_prefix.Text + checkBox.Content.ToString());
                                }
                                else if ((bool)cb_test.IsChecked)
                                {
                                    projectDir.CreateSubdirectory(tb_prefix.Text + checkBox.Content.ToString() + "\\" + tb_prefix.Text + cb_test.Content.ToString());
                                }
                                else
                                {
                                    projectDir.CreateSubdirectory(tb_prefix.Text + checkBox.Content.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (checkBox.Name != "cb_renders")
                            {
                                projectDir.CreateSubdirectory(checkBox.Content.ToString());
                            }
                            else if ((bool)cb_test.IsChecked)
                            {
                                projectDir.CreateSubdirectory(checkBox.Content.ToString() + "\\" + cb_test.Content.ToString());
                            }
                            else
                            {
                                projectDir.CreateSubdirectory(checkBox.Content.ToString());
                            }
                        }
                    }
                    foreach (string name in customFolders)
                    {
                        projectDir.CreateSubdirectory(name);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show(projectPath + " already exists", "Error");
                }
            }
            catch (Exception)
            {

                System.Windows.MessageBox.Show("We have some problems with сreating folders");
            }
            
        }

        private void Bt_AddNewCustFolder_Click(object sender, RoutedEventArgs e)
        {
            regex = new Regex(folderNamePattern);
            if (regex.IsMatch(tb_NewCustomFolder.Text))
            {
                if (tb_NewCustomFolder.Text != "" && customFolders.Contains(tb_NewCustomFolder.Text) == false)
                {
                    customFolders.Add(tb_NewCustomFolder.Text);
                    lb_CustFold.ItemsSource = customFolders;
                    lb_CustFold.Items.Refresh();

                    tb_NewCustomFolder.Text = string.Empty;
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Folder name is empty or contains invalid characters:\nА-Я / \\ | : * ? “ < >", "Error");
            }
        }

        private void Bt_RemoveCustFolder_Click(object sender, RoutedEventArgs e)
        {
            customFolders.Remove(lb_CustFold.SelectedItem as string);
            lb_CustFold.Items.Refresh();
        }

        private void Cb_renders_Checked(object sender, RoutedEventArgs e)
        {
            cb_test.IsEnabled = true;
        }

        private void Cb_renders_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_test.IsEnabled = false;
        }

    }
}
