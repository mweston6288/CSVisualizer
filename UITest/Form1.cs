using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UITest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Button[] sortingMenuBTNS;
        private Button[] greedyMenuBTNS;
        private Button[] graphMenuBTNS;
        private Button[] treeMenuBTNS;
        private Button[] dynamicMenuBTNS;
        private Button[] searchingMenuBTNS;
        private Button[] backtrackMenuBTNS;
        

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void groupBTNS() // groups the sidebar menus buttons by submenu
        {
            sortingMenuBTNS = new Button[] { };
            greedyMenuBTNS = new Button[] { };
            graphMenuBTNS = new Button[] { };
            treeMenuBTNS = new Button[] { };
            dynamicMenuBTNS = new Button[] { };
            searchingMenuBTNS = new Button[] { };
            backtrackMenuBTNS = new Button[] { };


            // sorting algorithms
            sortingMenuBTNS.Append(selectionSBTN);
            sortingMenuBTNS.Append(bubbleSBTN);
            sortingMenuBTNS.Append(insertionSBTN);
            sortingMenuBTNS.Append(mergeSBTN);

            // greedy algorithms
            greedyMenuBTNS.Append(greedyBTN1);
            greedyMenuBTNS.Append(greedyBTN2);
            greedyMenuBTNS.Append(greedyBTN3);

            // graphs
            graphMenuBTNS.Append(graphBTN1);
            graphMenuBTNS.Append(graphBTN2);
            graphMenuBTNS.Append(graphBTN3);

            // trees
            treeMenuBTNS.Append(treeBTN1);
            treeMenuBTNS.Append(treeBTN2);
            treeMenuBTNS.Append(treeBTN3);

            // dynamic programming
            dynamicMenuBTNS.Append(dynamicBTN1);
            dynamicMenuBTNS.Append(dynamicBTN2);
            dynamicMenuBTNS.Append(dynamicBTN3);

            // searching
            searchingMenuBTNS.Append(searchingBTN1);
            searchingMenuBTNS.Append(searchingBTN2);
            searchingMenuBTNS.Append(searchingBTN3);

            //backtracking
            backtrackMenuBTNS.Append(backtrackBTN1);
            backtrackMenuBTNS.Append(backtrackBTN2);
            backtrackMenuBTNS.Append(backtrackBTN3);
        }

        private void toggleButtonTabIndex(Button[] btns)
        {
            foreach(Button b in btns)
            {
                b.TabStop = b.TabStop ? false : true;
            }
        }

        private void disableButtonTabIndex(Button[] btns)
        {
            foreach (Button b in btns)
            {
                b.TabStop = false;
                Console.WriteLine("{0}", b.Text);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Hellow World!");
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            Left = Top = 0;

            // collapses menues
            sortingGroupPNL.Height = 30;
            graphsGroupPNL.Height = 30;
            greedyGroupPNL.Height = 30;
            treeGroupPNL.Height = 30;
            dynamicGroupPNL.Height = 30;
            searchingGroupPNL.Height = 30;
            backtrackGroupPNL.Height = 30;

            // takes the collapsed menu buttons out of the tab index
            groupBTNS();
            disableButtonTabIndex(sortingMenuBTNS);
            disableButtonTabIndex(greedyMenuBTNS);
            disableButtonTabIndex(treeMenuBTNS);
            disableButtonTabIndex(graphMenuBTNS);
            disableButtonTabIndex(dynamicMenuBTNS);
            disableButtonTabIndex(searchingMenuBTNS);
            disableButtonTabIndex(backtrackMenuBTNS);


        }

        private void sortingMenuBTN_Click(object sender, EventArgs e)
        {
            int children = 4;//sortingMenuBTNS.Length;

            if (sortingGroupPNL.Height == 30) // if menu is already collapsed, expend it
            {
                sortingGroupPNL.Height = (30 * (children+1)) + 2;
            }
            else // else collapse it
            {
                sortingGroupPNL.Height = 30;
            }

            //toggleButtonTabIndex(sortingMenuBTNS);
        }

        private void greedyMenuBTN_Click(object sender, EventArgs e)
        {
            int children = 3;// greedyMenuBTNS.Length;

            if (greedyGroupPNL.Height == 30) // if menu is already collapsed, expend it
            {
                greedyGroupPNL.Height = (30 * (children + 1)) + 2;
            }
            else // else collapse it
            {
                greedyGroupPNL.Height = 30;
            }
            
            //toggleButtonTabIndex(greedyMenuBTNS);
        }

        private void graphsMenuBTN_Click(object sender, EventArgs e)
        {
            int children = 3;//graphMenuBTNS.Length;

            if (graphsGroupPNL.Height == 30) // if menu is already collapsed, expend it
            {
                graphsGroupPNL.Height = (30 * (children + 1)) + 2;
            }
            else // else collapse it
            {
                graphsGroupPNL.Height = 30;
            }

            //toggleButtonTabIndex(graphMenuBTNS);
        }

        private void treeMenuBTN_Click(object sender, EventArgs e)
        {
            int children = 3;//treeMenuBTNS.Length;

            if (treeGroupPNL.Height == 30) // if menu is already collapsed, expend it
            {
                treeGroupPNL.Height = (30 * (children + 1)) + 2;
            }
            else // else collapse it
            {
                treeGroupPNL.Height = 30;
            }

            //toggleButtonTabIndex(treeMenuBTNS);
        }

        private void dynamicMenuBTN_Click(object sender, EventArgs e)
        {
            int children = 3;//dynamicMenuBTNS.Length;

            if (dynamicGroupPNL.Height == 30) // if menu is already collapsed, expend it
            {
                dynamicGroupPNL.Height = (30 * (children + 1)) + 2;
            }
            else // else collapse it
            {
                dynamicGroupPNL.Height = 30;
            }

            //toggleButtonTabIndex(dynamicMenuBTNS);
        }

        private void searchingMenuBTN_Click(object sender, EventArgs e)
        {
            int children = 3;//searchingMenuBTNS.Length;

            if (searchingGroupPNL.Height == 30) // if menu is already collapsed, expend it
            {
                searchingGroupPNL.Height = (30 * (children + 1)) + 2;
            }
            else // else collapse it
            {
                searchingGroupPNL.Height = 30;
            }

            //toggleButtonTabIndex(searchingMenuBTNS);
        }

        private void backtrackMenuBTN_Click(object sender, EventArgs e)
        {
            int children = 3;//backtrackMenuBTNS.Length;

            if (backtrackGroupPNL.Height == 30) // if menu is already collapsed, expend it
            {
                backtrackGroupPNL.Height = (30 * (children + 1)) + 2;
            }
            else // else collapse it
            {
                backtrackGroupPNL.Height = 30;
            }

            //toggleButtonTabIndex(backtrackMenuBTNS);
        }
    }
}



