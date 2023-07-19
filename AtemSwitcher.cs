using BMDSwitcherAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAppAtemMini
{
    public class AtemSwitcher
    {
        // Switcher
        private IBMDSwitcher switcher;
        // Přechody
        private IBMDSwitcherMixEffectBlock me0;
        private IBMDSwitcherTransitionParameters me0TransitionParams;
        private IBMDSwitcherTransitionWipeParameters me0WipeTransitionParams;
        private IBMDSwitcherTransitionDipParameters me0DipTransitionParams;
        private IBMDSwitcherTransitionMixParameters me0MixTransitionParams;
        private IBMDSwitcherTransitionDVEParameters me0DVETransitionParams;
        private IBMDSwitcherFairlightAudioMixer m_fairlightAudioMixer;

        // Připojení k ATEM Mini - kon
        public AtemSwitcher(string ip)
        {
            // Vytvoření Discovery objektu (vyhledává ATEM)
            IBMDSwitcherDiscovery discovery = new CBMDSwitcherDiscovery();
            // Připojení k ATEM
            discovery.ConnectTo(ip, out IBMDSwitcher switcher, out _BMDSwitcherConnectToFailure failureReason);
            // Vytvoření objektu ATEM switcher a dalších potřebných částí
            this.switcher = switcher;
            this.me0 = this.MixEffectBlocks.First();

            this.me0TransitionParams = me0 as IBMDSwitcherTransitionParameters;
            this.me0WipeTransitionParams = me0 as IBMDSwitcherTransitionWipeParameters;
            this.me0DipTransitionParams = me0 as IBMDSwitcherTransitionDipParameters;
            this.me0MixTransitionParams = me0 as IBMDSwitcherTransitionMixParameters;
            this.me0DVETransitionParams = me0 as IBMDSwitcherTransitionDVEParameters;
            this.m_fairlightAudioMixer = (IBMDSwitcherFairlightAudioMixer)switcher;
        }

        // Získání efektů pro přechod
        public IEnumerable<IBMDSwitcherMixEffectBlock> MixEffectBlocks
        {
            get
            {
                // Vytvoření iterátoru
                switcher.CreateIterator(typeof(IBMDSwitcherMixEffectBlockIterator).GUID, out IntPtr meIteratorPtr);
                IBMDSwitcherMixEffectBlockIterator meIterator = Marshal.GetObjectForIUnknown(meIteratorPtr) as IBMDSwitcherMixEffectBlockIterator;
                if (meIterator == null)
                    yield break;

                // Průchod skrze všechny efekty 
                while (true)
                {
                    meIterator.Next(out IBMDSwitcherMixEffectBlock me);

                    if (me != null)
                        yield return me;
                    else
                        yield break;
                }
            }
        }

        // Získání inputů
        public IEnumerable<IBMDSwitcherInput> SwitcherInputs
        {
            get
            {
                // Vytvoření iterátoru
                switcher.CreateIterator(typeof(IBMDSwitcherInputIterator).GUID, out IntPtr inputIteratorPtr);
                IBMDSwitcherInputIterator inputIterator = Marshal.GetObjectForIUnknown(inputIteratorPtr) as IBMDSwitcherInputIterator;
                if (inputIterator == null)
                    yield break;

                // Průchod skrze všechny inputy
                while (true)
                {
                    inputIterator.Next(out IBMDSwitcherInput input);

                    if (input != null)
                        yield return input;
                    else
                        yield break;
                }
            }
        }

        // Vrací ID inputu
        static long GetInputId(IBMDSwitcherInput input)
        {
            input.GetInputId(out long id);
            return id;
        }

        // Vrací MixEffectBlock
        public IBMDSwitcherMixEffectBlock getMixEffectBlock()
        {
            return me0;
        }
        public void addNewCallBack(MixEffectBlockMonitor m_mixEffectBlockMonitor)
        {
            me0.AddCallback(m_mixEffectBlockMonitor);
        }

        // Získávání kamery, aby se mohla nastavit (přepnou nebo preview)
        private static IBMDSwitcherInput getSwitcherInput(AtemSwitcher sw, int cam)
        {
            return sw.SwitcherInputs
                                        .Where((i, ret) => {
                                            i.GetPortType(out _BMDSwitcherPortType type);
                                            return type == _BMDSwitcherPortType.bmdSwitcherPortTypeExternal;
                                        })
                                        .ElementAt(cam);
        }

        // Změna kamery
        public void changeInput(int cam)
        {
            me0.SetProgramInput(GetInputId(getSwitcherInput(this, cam)));
        }

        // Změna preview
        public void changePreview(int cam)
        {
            me0.SetPreviewInput(GetInputId(getSwitcherInput(this, cam)));
        }

        // Změna přechodu
        public void changeTransition(int style)
        {
            me0TransitionParams.SetNextTransitionSelection(_BMDSwitcherTransitionSelection.bmdSwitcherTransitionSelectionBackground);
            switch (style)
            {
                case 0:
                    me0TransitionParams.SetNextTransitionStyle(_BMDSwitcherTransitionStyle.bmdSwitcherTransitionStyleWipe);
                    me0WipeTransitionParams.SetPattern(_BMDSwitcherPatternStyle.bmdSwitcherPatternStyleRectangleIris);
                    break;
                case 1:
                    me0TransitionParams.SetNextTransitionStyle(_BMDSwitcherTransitionStyle.bmdSwitcherTransitionStyleDip);
                    break;
                case 2:
                    me0TransitionParams.SetNextTransitionStyle(_BMDSwitcherTransitionStyle.bmdSwitcherTransitionStyleMix);
                    break;
                case 3:
                    me0TransitionParams.SetNextTransitionStyle(_BMDSwitcherTransitionStyle.bmdSwitcherTransitionStyleDVE);
                    break; ;
            }
        }

        // Nastavení délky přechodu
        public void changeTransitionTime(uint time)
        {
            me0WipeTransitionParams.SetRate(time);
            me0DipTransitionParams.SetRate(time);
            me0MixTransitionParams.SetRate(time);
            me0DVETransitionParams.SetRate(time);
        }

        // Provedení AUTO přechodu
        public void performTransition()
        {
            me0.PerformAutoTransition();
        }

        // Provedení CUT přechodu
        public void performCut()
        {
            me0.PerformCut();
        }

        // Provedení FTB přechodu
        public void performFTB()
        {
            me0.PerformFadeToBlack();
        }

        // Provedení předem nastaveného makra
        public void performMacro(int preview, int transitionStyle, uint transitionTime)
        {
            changePreview(preview);
            changeTransition(transitionStyle);
            changeTransitionTime(transitionTime);
            performTransition();
        }

        public void setAudioGain(double gian)
        {
            m_fairlightAudioMixer.SetMasterOutFaderGain(gian);
        }

    }
}
