using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SORAKAKE.Ver1
{
    public partial class MenuForm : Form
    {
        private Menu menu;

        public MenuForm(Menu game)
        {
            this.menu = game;
            InitializeComponent();
        }
        //キーボード
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            menu.Operation = 0;
        }
        //Wii周辺機器
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            menu.Operation = 1;
        }
        //OK
        private void button1_Click(object sender, EventArgs e)
        {
            menu.menuflag = 0;
            Dispose();
        }
    }
}
