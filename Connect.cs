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
    public partial class Connect : Form
    {
        public Connect()
        {
            InitializeComponent();

        }

        // Pro připojení k ATEM Mini
        private void b_connect_Click(object sender, EventArgs e)
        {
            try
            {
                // Pokud se provede připojení, zobrazí se ovládání
                AtemSwitcher atemSwitcher = new AtemSwitcher(ipAdresa.Text);
                Application.EnableVisualStyles();
                new Layout(atemSwitcher).Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Zobrazení chybové hlášky při nezdařilém připojení
                MessageBox.Show("Chyba připojení", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void oAplikaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplikace je diplomovou práci vytvořenou v roce 2023.\n" +
                "Slouží k připojení ATEM Mini a jeho ovládání.\n" +
                "Nejedná se o plnohodnotné ovládání.", "O aplikaci", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nápovědaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do prázdného okénka zadejte IP adresu ATEM Mini, například 192.168.0.10. Poté klikněte na tlačítko 'Připojit'."
                + "\nV případě úspěšného připojení se objeví ovládací panel.\nV případě neúspěčného připojení se zobrazí chybová hláška."
                , "O aplikaci", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
