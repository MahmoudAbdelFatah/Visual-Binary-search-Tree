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
    public partial class StringBST : Form
    {
        BST<string> stringBST; string lasts;
        List<string> stringList;
        bool LOIsD = false; int lastdelIndex;
        bool opendFromFile = false; string OpendFilePath;

        public StringBST()
        {
            InitializeComponent();
            stringBST = new BST<string>(this);
            stringList = new List<string>();
        }
        public void ReDraw()
        {
            this.Invalidate();
            this.Refresh();
            stringBST = new BST<string>(this);
            for (int i = 0; i < stringList.Count; i++)
                stringBST.append(stringList[i], false);
        }


        private void Undo_Click(object sender, EventArgs e)
        {
            //LOIsD , lastdelIndex ,( lasts , lastf , lasts)
            if (LOIsD == true)
            {
                stringList.Insert(lastdelIndex, lasts);
                ReDraw();
            }
            else
            {
                stringBST.Delete(lasts);
                stringList.Remove(lasts);
                ReDraw();
            }
        }

        private void Append_Click(object sender, EventArgs e)
        {
            if (AppBox.Text != "")
            {
                LOIsD = false;
                stringBST.append(AppBox.Text, true);
                if (!stringList.Contains(AppBox.Text))
                {
                    stringList.Add(AppBox.Text);
                    lasts = AppBox.Text;
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //delete            
            if (DelBox.Text != "")
            {
                LOIsD = true;
                stringBST.Delete(DelBox.Text);
                for (int i = 0; i < stringList.Count; i++)
                    if (stringList[i] == DelBox.Text)
                        lastdelIndex = i;

                stringList.Remove(DelBox.Text);
                lasts = DelBox.Text;
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
            stringBST = new BST<string>(this);
            stringList.Clear();

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
                        for (int i = 0; i < stringList.Count; i++)
                        {
                            writer.WriteLine(stringList[i].ToString());
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
                    stringBST = new BST<string>(this);
                    stringList = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        stringBST.append(line, false);
                        stringList.Add(line);
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
                        for (int i = 0; i < stringList.Count; i++)
                        {
                            writer.WriteLine(stringList[i].ToString());
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


        private void searchBox_MouseClick(object sender, MouseEventArgs e)
        {
            searchBox.Text = "";
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search_Click(this, new EventArgs());
        }

        private void Search_Click(object sender, EventArgs e)
        {
            stringBST.contain(searchBox.Text, true);
        }

        private void Merge_Click(object sender, EventArgs e)
        {
            List<string> lst1 = new List<string>();  //the program list          
            List<string> lst2 = new List<string>(); //to be filled from the file 
            lst1 = stringList.ToList();


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
                    stringBST = new BST<string>(this);
                    stringList = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lst2.Add(line);
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
                    if (!stringBST.contain(lst1[0], false))
                    {
                        stringBST.append(lst1[0], true);
                        stringList.Add(lst1[0]);
                        lst1.Remove(lst1[0]);
                    }
                    else
                        lst1.Remove(lst1[0]);
                }
                if (lst2.Count != 0)
                {
                    if (!stringBST.contain(lst2[0], false))
                    {
                        stringBST.append(lst2[0], true);
                        stringList.Add(lst2[0]);
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

     

       







    }//end class
}
