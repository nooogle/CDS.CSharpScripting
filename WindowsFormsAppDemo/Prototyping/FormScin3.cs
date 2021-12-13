using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo.Prototyping
{
    public partial class FormScin3 : Form
    {
        public FormScin3()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            codeEditor1.CDSInitialize(
                namespaceTypes: new[] { typeof(Color), typeof(System.IO.File), },
                referenceTypes: new[] { typeof(Color) },
                globalsType: default);
        }
    }
}
