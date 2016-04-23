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

namespace DS_project
{
    public partial class FloatBST : Form
    {
        BST<float> floatBST; float lastf;
        List<float> floatList;

        bool LOIsD = false; int lastdelIndex;
        bool opendFromFile = false; string OpendFilePath;

        public FloatBST()
        {
            InitializeComponent();
            floatBST = new BST<float>(this);
            floatList = new List<float>();
        }

        public void ReDraw()
        {
            this.Invalidate();
            this.Refresh();
            floatBST = new BST<float>(this);
            for (int i = 0; i < floatList.Count; i++)
                floatBST.append(floatList[i], false);
        }


        private void Undo_Click(object sender, EventArgs e)
        {
            //LOIsD , lastdelIndex ,( lastf , lastf , lasts)
            if (LOIsD == true)
            {
                floatList.Insert(lastdelIndex, lastf);
                ReDraw();
            }
            else
            {
                floatBST.Delete(lastf);
                floatList.Remove(lastf);
                ReDraw();
            }
        }

        private void Append_Click(object sender, EventArgs e)
        {
            if (AppBox.Text != "")
            {
                LOIsD = false;
                floatBST.append(float.Parse(AppBox.Text), true);
                if (!floatList.Contains(float.Parse(AppBox.Text)))
                {
                    floatList.Add(float.Parse(AppBox.Text));
                    lastf = float.Parse(AppBox.Text);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //delete            
            if (DelBox.Text != "")
            {
                LOIsD = true;
                floatBST.Delete(float.Parse(DelBox.Text));
                for (int i = 0; i < floatList.Count; i++)
                    if (floatList[i] == float.Parse(DelBox.Text))
                        lastdelIndex = i;

                floatList.Remove(float.Parse(DelBox.Text));
                lastf = float.Parse(DelBox.Text);
                ReDraw();
            }
        }

        private void AppBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Append_Click(this, new EventArgs());
        }

        private void AppBox_MouseClick(object sender, MouseEventArgs e)
        {
            AppBox.Text = "";
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            floatBST = new BST<float>(this);
            floatList.Clear();

            this.Invalidate();
            this.Refresh();
        }

        private void DelBox_MouseClick(object sender, MouseEventArgs e)
        {
              DelBox.Text = "";
        }

        private void DelBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Delete_Click(this, new EventArgs());
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            save.RestoreDirectory = true;

            save.ShowDialog();

            if (save.FileName != "")
            {
                if (!File.Exists(save.FileName))
                {//new                
                    File.Create(save.FileName).Dispose();
                    using (TextWriter writer = new StreamWriter(save.FileName))
                    {
                        for (int i = 0; i < floatList.Count; i++)
                        {
                            writer.WriteLine(floatList[i].ToString());
                        }
                        writer.Close();
                    }
                }
            }

        }

        private void Open_Click(object sender, EventArgs e)
        {
            StreamReader reader = null;
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open Text File";
            open.Filter = "TXT files|*.txt";
            open.InitialDirectory = @"C:\";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (reader = new StreamReader(open.FileName))
                {
                    opendFromFile = true;
                    OpendFilePath = open.FileName;

                    this.Invalidate();
                    this.Refresh();
                    floatBST = new BST<float>(this);
                    floatList = new List<float>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        floatBST.append(float.Parse(line), false);
                        floatList.Add(float.Parse(line));
                    }
                    reader.Close();
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (opendFromFile)
            {//save the curent BST to the opened file                

                if (File.Exists(OpendFilePath))
                {//new                
                    File.Delete(OpendFilePath);
                    File.Create(OpendFilePath).Dispose();
                    using (TextWriter writer = new StreamWriter(OpendFilePath))
                    {
                        for (int i = 0; i < floatList.Count; i++)
                        {
                            writer.WriteLine(floatList[i].ToString());
                        }
                        writer.Close();
                    }
                }
            }
            else
            {
                SaveAs_Click(this, new EventArgs());
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            floatBST.contain(float.Parse(searchBox.Text), true);
        }

        private void searchBox_MouseClick(object sender, MouseEventArgs e)
        {
            searchBox.Text = "";
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search_Click(this, new EventArgs());
        }

        private void Merge_Click(object sender, EventArgs e)
        {
            List<float> lst1 = new List<float>();  //the program list          
            List<float> lst2 = new List<float>(); //to be filled from the file 
            lst1 = floatList.ToList();
            

            StreamReader reader = null;
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open Text File";
            open.Filter = "TXT files|*.txt";
            open.InitialDirectory = @"C:\";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (reader = new StreamReader(open.FileName))
                {
                    opendFromFile = true;
                    OpendFilePath = open.FileName;

                    this.Invalidate();
                    this.Refresh();
                    floatBST = new BST<float>(this);
                    floatList = new List<float>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lst2.Add(float.Parse(line));
                    }
                    reader.Close();
                }
            }

            while (true)
            {
                if (lst1.Count == 0 && lst2.Count == 0)
                    break;

                if (lst1.Count != 0)
                {
                    if (!floatBST.contain(lst1[0], false))
                    {
                        floatBST.append(lst1[0], true);
                        floatList.Add(lst1[0]);
                        lst1.Remove(lst1[0]);
                    }
                    else
                        lst1.Remove(lst1[0]);
                }
                if (lst2.Count != 0)
                {
                    if (!floatBST.contain(lst2[0], false))
                    {
                        floatBST.append(lst2[0], true);
                        floatList.Add(lst2[0]);
                        lst2.Remove(lst2[0]);
                    }
                    else
                        lst2.Remove(lst2[0]);
                }
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            ReDraw();
        }




      


    }
}
