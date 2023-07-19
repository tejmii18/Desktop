using BMDSwitcherAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAppAtemMini
{
    public delegate void SwitcherEventHandler(object sender, object args);

    public class MixEffectBlockMonitor : IBMDSwitcherMixEffectBlockCallback
    {
        // Samotná deklarace eventů
        public event SwitcherEventHandler ProgramInputChanged;
        public event SwitcherEventHandler PreviewInputChanged;
        public event SwitcherEventHandler FadeToBlackTransitionChanged;

        // Konstruktor
        public MixEffectBlockMonitor()
        {
        }

        // Notifikace
        void IBMDSwitcherMixEffectBlockCallback.Notify(_BMDSwitcherMixEffectBlockEventType eventType)
        {
            switch (eventType)
            {
                // Změnil se vstup
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypeProgramInputChanged:
                    if (ProgramInputChanged != null)
                        ProgramInputChanged(this, null);
                    break;
                // Změnilo se preview
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypePreviewInputChanged:
                    if (PreviewInputChanged != null)
                        PreviewInputChanged(this, null);
                    break;
                // Změna FTB
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypeInFadeToBlackChanged:
                    if (FadeToBlackTransitionChanged != null)
                        FadeToBlackTransitionChanged(this, null);
                    break;
            }
        }
    }
}
