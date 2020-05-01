using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab12_2
{
    class MyTree
    {
        private MyTree Parent;
        private MyTree Left;
        private MyTree Right;
        private bool empty;
        private int Data;
        public int data => Data;
        public int Count { get { return Countt(); } }
        private int tmp;

        public MyTree()
        {
            Data = 0;
            empty = true;
            Parent = null;
            Left = null;
            Right = null;
        }

        public MyTree(int n)
        {
            Data = n;
            empty = false;
            Parent = null;
            Left = null;
            Right = null;

        }
        public string GetRightLine(string prev)
        {
            string str = "";
            str = prev + "--" + this.Data.ToString();

            if (this.Right != null)
                str += Right.GetRightLine(str);

            return str;
        }
        public void PrintTree(TreeView trw)
        {

            if (this.empty) return;

            trw.Nodes.Add(new TreeNode(this.data.ToString()));

            PrintNode(trw.Nodes[0]);

            trw.ExpandAll();
        }
        public void Clear() 
        {
            Data = 0;
            empty = true;
            Right = null;
            Left = null;
            Parent = null;
        }

        private void PrintNode(TreeNode tnd)
        {
            tnd.Text = this.Data.ToString();
            int ncount = 0;

            if (this.Right != null)
            {
                //this.Right.PrintTree(trw, ind + 1);
                tnd.Nodes.Add(new TreeNode(Right.data.ToString()));
                this.Right.PrintNode(tnd.Nodes[ncount]);
                ncount++;
            }
            if (this.Left != null)
            {
                //this.Left.PrintTree(trw, ind + 1);
                tnd.Nodes.Add(new TreeNode( Left.data.ToString()));
               this.Left.PrintNode(tnd.Nodes[ncount]);
            }
        }
        public void AddBalanced(int n)
        {
            if (this.empty)
            {
                this.Data = n;
                this.empty = false;
            }
            else
            {
                MyTree add = new MyTree(n);
                MyTree place = GetShortest(this, 0);

                if (place.Left == null)
                {
                    place.Left = add;
                    add.Parent = place;
                }
                else
                {
                    place.Right = add;
                    add.Parent = place;
                }
            }
        }
        public double CalcAver()
        {
            return Sum() / (double)Countt();
        }

        private int Sum()
        {
            int a = 0, b = 0;
            if (this.Left != null)
               a= this.Left.Sum();
            if (this.Right != null)
                b = this.Right.Sum();
            return a + b + this.Data;
        }
        private int Countt()
        {
            int a = 0, b = 0;
            if (this.Left != null)
                a = this.Left.Countt();
            if (this.Right != null)
                b = this.Right.Countt();
            return a + b + 1;
        }

            public void ToBalanced()
        {
            List<int> list = new List<int>();
            this.ToList(list);

            this.Clear();

            foreach (var i in list)
                this.AddBalanced(i);
        }

        public void ToSearch()
        {
            List<int> list = new List<int>();
            this.ToList(list);

            this.Clear();

            foreach (var i in list)
                this.AddSearch(i);
        }

        private void ToList( List<int> list)
        {
            list.Add(this.Data);
            if (this.Left != null)
                this.Left.ToList(list);
            if (this.Right != null)
                this.Right.ToList(list);
        }

        public MyTree GetShortest(MyTree current, int depth)
        {
            if (current.Left == null || current.Right == null)
                return current;
            else
            {
                current.Left.tmp = depth;
                current.Right.tmp = depth;

                MyTree t1 = GetShortest(current.Left, depth + 1);
                MyTree t2 = GetShortest(current.Right, depth + 1);

                if (t1.tmp < t2.tmp)
                    return t1;
                else
                    return t2;
            }
        }

        public void AddSearch(int n)
        {
            if (this.empty)
            {
                this.Data = n;
                this.empty = false;
            }
            else
            {

                if (n < this.Data)
                {
                    if (this.Left == null)
                    {
                        MyTree add = new MyTree(n);
                        this.Left = add;
                        add.Parent = this;
                    }
                    else
                    {
                        this.Left.AddSearch(n);
                    }
                }
                else
                {
                    if (this.Right == null)
                    {
                        MyTree add = new MyTree(n);
                        this.Right = add;
                        add.Parent = this;
                    }
                    else
                    {
                        this.Right.AddSearch(n);
                    }
                }
            }
        }

    }
}
