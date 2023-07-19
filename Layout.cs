using BMDSwitcherAPI;
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
    public partial class Layout : Form
    {
        private AtemSwitcher switcher;

        private MixEffectBlockMonitor m_mixEffectBlockMonitor;

        private List<Button> cameraButtons;
        private List<Button> previewButtons;
        private List<Button> transitionButtons;
        private List<Button> transitionsTimeButtons;

        private int previewButtonSelected;

        private ButtonColors buttonColors;

        public Layout(AtemSwitcher switcher)
        {
            InitializeComponent();
            // Model - AtemSwitcher
            this.switcher = switcher;

            // Callbacks
            m_mixEffectBlockMonitor = new MixEffectBlockMonitor();
            m_mixEffectBlockMonitor.ProgramInputChanged += new SwitcherEventHandler((s, a) => this.Invoke((Action)(() => updateProgramButtonSelection())));
            m_mixEffectBlockMonitor.PreviewInputChanged += new SwitcherEventHandler((s, a) => this.Invoke((Action)(() => updatePreviewButtonSelection())));
            m_mixEffectBlockMonitor.FadeToBlackTransitionChanged += new SwitcherEventHandler((s, a) => this.Invoke((Action)(() => updateFadeToBlackButtonSelection())));
            switcher.addNewCallBack(m_mixEffectBlockMonitor);

            // Listy pro barvy
            cameraButtons = new List<Button>() { b_cam1, b_cam2, b_cam3, b_cam4 };
            previewButtons = new List<Button>() { b_prew1, b_prew2, b_prew3, b_prew4 };
            transitionButtons = new List<Button>() { b_wipe, b_dip, b_mix, b_dve };
            transitionsTimeButtons = new List<Button>() { b_05, b_10, b_15, b_20 };
            buttonColors = new ButtonColors();
        }

        // Callback pro KAMERY
        private void updateProgramButtonSelection()
        {
            long programId;
            switcher.getMixEffectBlock().GetProgramInput(out programId);
            int intValue = ((int)(programId % Int32.MaxValue)) - 1;
            buttonColors.changeButtonsColorToRed(cameraButtons, intValue);

        }

        // Callback pro PREVIEW
        private void updatePreviewButtonSelection()
        {
            long programId;
            switcher.getMixEffectBlock().GetPreviewInput(out programId);
            int intValue = ((int)(programId % Int32.MaxValue)) - 1;
            buttonColors.changeButtonsColorToGreen(previewButtons, intValue);

        }

        // Callback pro FTB 
        private void updateFadeToBlackButtonSelection()
        {
            int transitionId;
            switcher.getMixEffectBlock().GetFadeToBlackInTransition(out transitionId);
            if (transitionId == 0)
            {
                buttonColors.changeColorToWhite(b_ftb);
            }
            else
            {
                buttonColors.changeColorToBlack(b_ftb);
            }
        }

        // Kamery
        private void b_cam1_Click(object sender, EventArgs e)
        {
            switcher.changeInput(0);
        }

        private void b_cam2_Click(object sender, EventArgs e)
        {
            switcher.changeInput(1);
        }

        private void b_cam3_Click(object sender, EventArgs e)
        {
            switcher.changeInput(2);
        }

        private void b_cam4_Click(object sender, EventArgs e)
        {
            switcher.changeInput(3);
        }

        // Preview
        private void b_prew1_Click(object sender, EventArgs e)
        {
            switcher.changePreview(0);
        }

        private void b_prew2_Click(object sender, EventArgs e)
        {
            switcher.changePreview(1);
        }

        private void b_prew3_Click(object sender, EventArgs e)
        {
            switcher.changePreview(2);
        }

        private void b_prew4_Click(object sender, EventArgs e)
        {
            switcher.changePreview(3);
        }

        // Přechody
        private void b_wipe_Click(object sender, EventArgs e)
        {
            switcher.changeTransition(0);
            buttonColors.changeButtonsColorToYellow(transitionButtons, 0);
        }

        private void b_dip_Click(object sender, EventArgs e)
        {
            switcher.changeTransition(1);
            buttonColors.changeButtonsColorToYellow(transitionButtons, 1);
        }

        private void b_mix_Click(object sender, EventArgs e)
        {
            switcher.changeTransition(2);
            buttonColors.changeButtonsColorToYellow(transitionButtons, 2);
        }

        private void b_dve_Click(object sender, EventArgs e)
        {
            switcher.changeTransition(3);
            buttonColors.changeButtonsColorToYellow(transitionButtons, 3);
        }

        // Čas přechodů
        private void b_10_Click(object sender, EventArgs e)
        {
            switcher.changeTransitionTime(30);
            buttonColors.changeButtonsColorToRed(transitionsTimeButtons, 1);
        }

        private void b_05_Click(object sender, EventArgs e)
        {
            switcher.changeTransitionTime(15);
            buttonColors.changeButtonsColorToRed(transitionsTimeButtons, 0);
        }

        private void b_15_Click(object sender, EventArgs e)
        {
            switcher.changeTransitionTime(45);
            buttonColors.changeButtonsColorToRed(transitionsTimeButtons, 2);
        }

        private void b_20_Click(object sender, EventArgs e)
        {
            switcher.changeTransitionTime(60);
            buttonColors.changeButtonsColorToRed(transitionsTimeButtons, 3);
        }

        // Proveď přechod nebo FTB
        private void b_auto_Click(object sender, EventArgs e)
        {
            switcher.performTransition();
            buttonColors.changeButtonsColorToRed(cameraButtons, previewButtonSelected);
            buttonColors.changeColorToWhite(previewButtons[previewButtonSelected]);
        }

        private void b_cut_Click(object sender, EventArgs e)
        {
            switcher.performCut();
            buttonColors.changeButtonsColorToRed(cameraButtons, previewButtonSelected);
            buttonColors.changeColorToWhite(previewButtons[previewButtonSelected]);
        }

        private void b_ftb_Click(object sender, EventArgs e)
        {
            switcher.performFTB();
            // kód kvůli okamžité změně barvy
            if (b_ftb.BackColor == Color.Black)
            {
                buttonColors.changeColorToWhite(b_ftb);
            }
            else
            {
                buttonColors.changeColorToBlack(b_ftb);
            }
        }

        // Zobrazení nového okna s makry
        private void b_macro_Click(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            new Macro(switcher).Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switcher.setAudioGain(trackBar1.Value);
        }
    }
}
