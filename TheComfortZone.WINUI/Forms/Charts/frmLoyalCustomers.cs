using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheComfortZone.WINUI.Forms.Charts
{
    public partial class frmLoyalCustomers : Form
    {
        public frmLoyalCustomers()
        {
            InitializeComponent();
            formsPlot.Plot.Style(Style.Blue1);
        }
    }
}
