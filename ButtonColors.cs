using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAppAtemMini
{
    // Metody na obarvení tlačítek
    internal class ButtonColors
    {
        public void changeButtonsColorToRed(List<Button> buttonsList, int thisButton)
        {
            for (int i = 0; i < buttonsList.Count; i++)
            {
                if (i == thisButton)
                {
                    buttonsList[i].BackColor = Color.Red;
                }
                else
                {
                    buttonsList[i].BackColor = Color.White;
                }
            }
        }

        public void changeButtonsColorToGreen(List<Button> buttonsList, int thisButton)
        {
            for (int i = 0; i < buttonsList.Count; i++)
            {
                if (i == thisButton)
                {
                    buttonsList[i].BackColor = Color.Green;
                }
                else
                {
                    buttonsList[i].BackColor = Color.White;
                }
            }
        }

        public void changeButtonsColorToYellow(List<Button> buttonsList, int thisButton)
        {
            for (int i = 0; i < buttonsList.Count; i++)
            {
                if (i == thisButton)
                {
                    buttonsList[i].BackColor = Color.Yellow;
                }
                else
                {
                    buttonsList[i].BackColor = Color.White;
                }
            }
        }

        public void changeColorToWhite(Button b)
        {
            b.BackColor = Color.White;
            b.ForeColor = Color.Black;
        }
        public void changeColorToRed(Button b)
        {
            b.BackColor = Color.Red;
        }
        public void changeColorToBlack(Button b)
        {
            b.BackColor = Color.Black;
            b.ForeColor = Color.White;
        }

    }
}
