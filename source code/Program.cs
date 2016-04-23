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

    public class Node<T>
    {
        public T Nodeval;
        public Node<T> right;
        public Node<T> left;
        public Node<T> parent;
        public Form NodeForm;
        public int x, y;
        public System.Drawing.Graphics graphNode;
        public System.Drawing.Rectangle rectangle;

        StringFormat strformat;  //of the text      
        Font font; //font of the text
        SolidBrush brush;//the color of the text
        Pen pen;
        public void unfill()
        {
            pen = new Pen(brush, 5);
            graphNode.DrawEllipse(pen, rectangle);
        }
        public void fill()
        {
            pen = new Pen(System.Drawing.Brushes.Black, 5);
            graphNode.DrawEllipse(pen, rectangle);
        }
        public void DrawNode(string n, int x_pos, int y_pos)
        {
            pen = new Pen(brush, 5);
            graphNode = NodeForm.CreateGraphics();
            rectangle = new System.Drawing.Rectangle(x_pos, y_pos, 50, 50);

            graphNode.DrawString(n, font, brush, rectangle, strformat);
            graphNode.DrawEllipse(pen, rectangle);
        }

        public void removeNode()
        {
            //graphNode.Clear(Color.Black);
            NodeForm.Invalidate(rectangle);
        }
        public Node(T v, Form form)
        {
            NodeForm = form;
            x = form.Width / 2 - 33;
            y = 50;
            Nodeval = v;
            right = null;
            left = null;

            font = new Font("Arial", 8); //the font of the text
            brush = new SolidBrush(Color.White); //the color of the text

            strformat = new StringFormat();
            strformat.Alignment = StringAlignment.Center;
            strformat.LineAlignment = StringAlignment.Center;

            DrawNode(Nodeval.ToString(), x, y);
            //DrawArrow();
        }

        public Node(T v, int x_pos, int y_pos, Node<T> parentNode, Form form)
        {
            NodeForm = form;
            parent = parentNode;
            Nodeval = v;
            right = null;
            left = null;
            x = x_pos;
            y = y_pos;

            font = new Font("Arial", 8); //the text font
            brush = new SolidBrush(Color.White); //the color of the text            

            strformat = new StringFormat();
            strformat.Alignment = StringAlignment.Center;
            strformat.LineAlignment = StringAlignment.Center;

            DrawNode(Nodeval.ToString(), x, y);

            DrawArrow();
        }


        public void DrawArrow()
        {
            //arrow
            Pen p = new Pen(Brushes.Black, 4);
            p.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            if (Comparer<T>.Default.Compare(Nodeval, parent.Nodeval) > 0) //right
            {
                graphNode.DrawLine(p, x + 25, y, parent.x + 38, parent.y + 45);
            }
            else if (Comparer<T>.Default.Compare(Nodeval, parent.Nodeval) < 0) //left
            {
                graphNode.DrawLine(p, x + 25, y, parent.x + 12, parent.y + 45);
            }
        }
    }

    public class BST<T>
    {
        public Node<T> root;
        public int size;
        public Form bstForm;

        public BST(Form f)
        {
            bstForm = f;
            size = 0;
            root = null;
        }

        public Node<T> findParent(T val)
        {//tested
            Node<T> temp1 = root;
            Node<T> temp2 = null;
            while (temp1 != null)
            {

                if (temp1.Nodeval.Equals(val))
                    break;

                temp2 = temp1;
                if (Comparer<T>.Default.Compare(temp1.Nodeval, val) > 0)
                {
                    temp1 = temp1.left;
                }
                else
                {
                    temp1 = temp1.right;
                }
            }
            return temp2;
        }
        public double ParentLevel(T val)
        {
            Node<T> temp1 = root;
            Node<T> temp2 = null;
            double level = -1;
            while (temp1 != null)
            {

                if (temp1.Nodeval.Equals(val))
                    break;

                temp2 = temp1;
                if (Comparer<T>.Default.Compare(temp1.Nodeval, val) > 0)
                {
                    temp1 = temp1.left;
                    level++;
                }
                else
                {
                    temp1 = temp1.right;
                    level++;
                }
            }
            return level;
        }
        public void append(T val, bool animate)
        {//tested
            if (size == 0)
            {
                root = new Node<T>(val, bstForm);
            }
            else
            {
                Node<T> par = findParent(val);
                if (contain(val, animate) == true)
                {
                    //MessageBox.Show("the element is alrady exist ! append()");
                    return;
                }
                else if (Comparer<T>.Default.Compare(findParent(val).Nodeval, val) > 0) //findParent(val).Nodeval > val
                {
                    //the new value < parent val               
                    double xpos = par.x - (bstForm.Width / 4) / Math.Pow(2.0, ParentLevel(val));

                    par.left = new Node<T>(val, (int)xpos, par.y + 90, par, bstForm);
                }
                else if (Comparer<T>.Default.Compare(findParent(val).Nodeval, val) < 0)
                {
                    //the new val > parent val
                    double xpos = par.x + (bstForm.Width / 4) / Math.Pow(2.0, ParentLevel(val));
                    par.right = new Node<T>(val, (int)xpos, par.y + 90, par, bstForm);
                }
            }

            size++;
        }
        public bool contain(T val, bool animate)
        {//tested
            //returns true if the value is already exist in the BST
            Node<T> temp = root;
            while (temp != null)
            {
                if (temp.Nodeval.Equals(val))
                {
                    if (animate)
                    {
                        temp.fill();
                        System.Threading.Thread.Sleep(500);
                        temp.unfill();
                        System.Threading.Thread.Sleep(500);
                        temp.fill();
                        System.Threading.Thread.Sleep(500);
                        temp.unfill();
                        System.Threading.Thread.Sleep(500);
                        temp.fill();
                        System.Threading.Thread.Sleep(500);
                        temp.unfill();
                    }
                    return true;
                }
                else if (Comparer<T>.Default.Compare(temp.Nodeval, val) < 0)
                {
                    if (animate)
                    {
                        temp.fill();
                        System.Threading.Thread.Sleep(500);
                        temp.unfill();
                    }
                    temp = temp.right;

                }
                else
                {
                    if (animate)
                    {
                        temp.fill();
                        System.Threading.Thread.Sleep(500);
                        temp.unfill();
                    }
                    temp = temp.left;
                }

            }
            return false;
        }

        public void traverce(int c)
        {
            if (c == 1)
                inOrder(root);
            else if (c == 2)
                preOrder(root);
            else
                postOrder(root);
        }
        public void inOrder(Node<T> start)
        {//tested
            if (start != null)
            {
                inOrder(start.left);
                MessageBox.Show(start.Nodeval.ToString());
                inOrder(start.right);
            }
        }
        public void preOrder(Node<T> start)
        {//tested
            if (start != null)
            {
                MessageBox.Show(start.Nodeval.ToString());
                preOrder(start.left);
                preOrder(start.right);
            }
        }
        public void postOrder(Node<T> start)
        {//tested
            if (start != null)
            {
                postOrder(start.left);
                postOrder(start.right);
                MessageBox.Show(start.Nodeval.ToString());
            }
        }

        public Node<T> findNode(T val)
        {//returns null if the value is not there
            //tested
            Node<T> temp = root;
            while (temp != null)
            {
                if (temp.Nodeval.Equals(val))
                    break;

                if (Comparer<T>.Default.Compare(temp.Nodeval, val) > 0)
                {
                    temp = temp.left;
                }
                else
                {
                    temp = temp.right;
                }
            }
            return temp;
        }
        public void Delete(T val)
        {//tested
            Node<T> temp = findNode(val);
            if (temp == null)
            {
                MessageBox.Show("the value you want to delete is not exist ! Delete()");
                return;
            }
            else
            {
                if (temp.left == null && temp.right == null)
                {
                    if (temp == root)
                        root = null;
                    else
                    {
                        Node<T> parent = findParent(val);
                        if (Comparer<T>.Default.Compare(parent.Nodeval, val) > 0)
                        {
                            parent.left = null;
                        }
                        else
                        {
                            parent.right = null;
                        }
                    }
                }
                else if (temp.left == null && temp.right != null)
                {
                    Node<T> parent = findParent(val);
                    if (temp == root)
                        root = temp.right;
                    else
                    {
                        if (Comparer<T>.Default.Compare(parent.Nodeval, val) > 0)
                            parent.left = temp.right;
                        else
                            parent.right = temp.right;
                    }
                }
                else if (temp.left != null && temp.right == null)
                {
                    Node<T> parent = findParent(val);
                    if (temp == root)
                        root = temp.left;
                    else
                    {
                        if (Comparer<T>.Default.Compare(parent.Nodeval, val) > 0)
                            parent.left = temp.left;
                        else
                            parent.right = temp.left;
                    }
                }
                else
                {
                    Node<T> minNode = findMin(temp.right);
                    Node<T> parent = findParent(minNode.Nodeval);
                    temp.Nodeval = minNode.Nodeval;
                    if (parent == temp)
                    {
                        parent.right = minNode.right;
                    }
                    else
                    {
                        parent.left = minNode.right;
                    }
                }
            }
            size--;
        }

        public Node<T> findMin(Node<T> start)
        {
            Node<T> temp = start;
            while (temp.left != null)
                temp = temp.left;
            return temp;
        }
    }
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                Choose f1 = new Choose() ;
                Application.Run(f1);

            string c = f1.cho;
            

            if (c == "int")
            {
                Application.Run(new IntBST());
                f1.Close();
            }
            else if (c == "float")
            {
                Application.Run(new FloatBST());
                f1.Close();
            }
            else
            {
                Application.Run(new StringBST());
                f1.Close();
            }
                
        }
    }
}
