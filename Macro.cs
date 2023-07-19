using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopAppAtemMini
{
    public partial class Macro : Form
    {
        AtemSwitcher switcher;
        public Macro(AtemSwitcher switcher)
        {
            InitializeComponent();
            this.switcher = switcher;
        }

        // Makra - první kamera, na kterou chci přepnout, další je přechod a poslední čas přechodu
        private void b_m1_1_Click(object sender, EventArgs e)
        {
            switcher.performMacro(0, 2, 30);
        }

        private void b_m1_2_Click(object sender, EventArgs e)
        {
            switcher.performMacro(1, 2, 30);
        }

        private void b_m1_3_Click(object sender, EventArgs e)
        {
            switcher.performMacro(2, 2, 30);
        }

        private void b_m1_4_Click(object sender, EventArgs e)
        {
            switcher.performMacro(3, 2, 30);
        }

        private void b_m2_1_Click(object sender, EventArgs e)
        {
            switcher.performMacro(0, 2, 60);
        }

        private void b_m2_2_Click(object sender, EventArgs e)
        {
            switcher.performMacro(1, 2, 60);
        }

        private void b_m2_3_Click(object sender, EventArgs e)
        {
            switcher.performMacro(2, 2, 60);
        }

        private void b_m2_4_Click(object sender, EventArgs e)
        {
            switcher.performMacro(3, 2, 60);
        }

        private void b_w1_1_Click(object sender, EventArgs e)
        {
            switcher.performMacro(0, 0, 30);
        }

        private void b_w1_2_Click(object sender, EventArgs e)
        {
            switcher.performMacro(1, 0, 30);
        }

        private void b_w1_3_Click(object sender, EventArgs e)
        {
            switcher.performMacro(2, 0, 30);
        }

        private void b_w1_4_Click(object sender, EventArgs e)
        {
            switcher.performMacro(3, 0, 30);
        }

        private void b_w2_1_Click(object sender, EventArgs e)
        {
            switcher.performMacro(0, 0, 60);
        }

        private void b_w2_2_Click(object sender, EventArgs e)
        {
            switcher.performMacro(1, 0, 60);
        }

        private void b_w2_3_Click(object sender, EventArgs e)
        {
            switcher.performMacro(2, 0, 60);
        }

        private void b_w2_4_Click(object sender, EventArgs e)
        {
            switcher.performMacro(3, 0, 60);
        }
    }
}
