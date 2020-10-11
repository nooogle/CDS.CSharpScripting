﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnBasicDemo_Click(object sender, EventArgs e)
        {
            using (var form = new FormBasicDemo())
            {
                form.ShowDialog(this);
            }
        }

        private void btnReturnListDemo_Click(object sender, EventArgs e)
        {
            using (var form = new FormReturnListDemo())
            {
                form.ShowDialog(this);
            }
        }
    }
}
