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
    public partial class IntBST : Form
    {
        BST<int> intBST; int lasti;
        List<int> intList;
        bool LOIsD = false; int lastdelIndex;
        bool opendFromFile = false; string OpendFilePath;

        public IntBST()
        {
            InitializeComponent();
            intBST = new BST<int>(this);
            intList = new List<int>();
        }
        public void ReDraw()
        {            
                this.Invalidate();
                this.Refresh();
                intBST = new BST<int>(this);
                for (int i = 0; i < intList.Count; i++)
                    intBST.append(intList[i], false);            
        }


        private void Undo_Click(object sender, EventArgs e)
        {
            //LOIsD , lastdelIndex ,( lasti , lastf , lasts)
            if (LOIsD == true)
            {                
                    intList.Insert(lastdelIndex, lasti);
                    ReDraw();                             
            }
            else
            {                
                    intBST.Delete(lasti);
                    intList.Remove(lasti);
                    ReDraw();
            }
        }

        private void Append_Click(object sender, EventArgs e)
        {            
            if (AppBox.Text != "")
            {
                    LOIsD = false;
                    intBST.append(int.Parse(AppBox.Text), true);
                    if (!intList.Contains(int.Parse(AppBox.Text)))
                    {
                        intList.Add(int.Parse(AppBox.Text));
                        lasti = int.Parse(AppBox.Text);
                    }
            }                        
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //delete            
            if (DelBox.Text != "")
            {
                LOIsD = true;
                intBST.Delete(int.Parse(DelBox.Text));
                for (int i = 0; i < intList.Count; i++)
                    if (intList[i] == int.Parse(DelBox.Text))
                        lastdelIndex = i;

                intList.Remove(int.Parse(DelBox.Text));
                lasti = int.Parse(DelBox.Text);
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
            intBST = new BST<int>(this);
            intList.Clear();

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
                        for (int i = 0; i < intList.Count; i++)
                        {
                            writer.WriteLine(intList[i].ToString());
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
                    intBST = new BST<int>(this);
                    intList = new List<int>();
                    string line;
                    while ((line = reader.ReadLine()) != null){
                        intBST.append(int.Parse(line), false);
                        intList.Add(int.Parse(line));
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
                        for (int i = 0; i < intList.Count; i++)
                        {
                            writer.WriteLine(intList[i].ToString());
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

        private void Merge_Click(object sender, EventArgs e)
        {

            List<int> lst1 = new List<int>();  //the program list          
            List<int> lst2 = new List<int>(); //to be filled from the file 
                lst1 = intList.ToList();
            

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
                    intBST = new BST<int>(this);
                    intList = new List<int>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {                       
                        lst2.Add(int.Parse(line));
                    }
                    reader.Close();
                }
            }
            
            while (true)
            {
                if (lst1.Count == 0 && lst2.Count == 0)
                    break;

                if (lst1.Count !=0)
                {
                    if (!intBST.contain(lst1[0], false))
                    {
                        intBST.append(lst1[0], true);
                        intList.Add(lst1[0]);
                        lst1.Remove(lst1[0]);
                    }
                    else
                        lst1.Remove(lst1[0]);
                }
                if (lst2.Count != 0)
                {
                    if (! intBST.contain(lst2[0], false))
                    {
                        intBST.append(lst2[0], true);
                        intList.Add(lst2[0]);
                        lst2.Remove(lst2[0]);
                    }
                    else
                        lst2.Remove(lst2[0]);
                }
            }
        }

         
        private void Seacrh_Click(object sender, EventArgs e)
        {
            intBST.contain(int.Parse(searchBox.Text),true);
        }

        private void searchBox_MouseClick(object sender, MouseEventArgs e)
        {
            searchBox.Text = "";
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Seacrh_Click(this, new EventArgs());
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            ReDraw();           
        }

        private void DelBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AppBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }

       
      




    }//end class
}
