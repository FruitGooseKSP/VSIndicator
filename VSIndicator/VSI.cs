using KSP.UI.Screens.Flight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

namespace VSIndicator
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class VSI : MonoBehaviour
    {
        // quick reference and stored colours

        [KSPField(isPersistant = true)]
        public Color32 savedA = new Color32(0, 225, 0, 255);

        [KSPField(isPersistant = true)]
        public Color32 savedD = new Color32(255, 0, 0, 255);

        public Color32 stockGreen = new Color32(0, 255, 0, 255);

        // The speed display component on the navball
        public SpeedDisplay sD;

        // the TM text for speed
        public TextMeshProUGUI tM;

        // the TM text for velocity mode
        public TextMeshProUGUI tM2;

        // bool to switch colour
        public bool colourSet = false;

        // pause menu options reference
        public VSIOptions vSIOptions;

        // indication of option selection
        public static bool shouldHideButton;

        // this
        public static VSI Instance;



        // allows subclasses to check navball setting
        public static bool GetTM2Text()
        {
            if (Instance.tM2.text == "Surface")
            {
                return true;
            }
            else return false;
        }


        // gets the code from the colour
        public static int GetColourCodeReversedA()
        {
            ColourDecoder cD = new ColourDecoder();
            return cD.GetReversedColour(Instance.vSIOptions.ascCol.ToString());
        }
        public static int GetColourCodeReversedD()
        {
            ColourDecoder cD = new ColourDecoder();
            return cD.GetReversedColour(Instance.vSIOptions.desCol.ToString());
        }

        // stores the selected colours
        public static void TestSwatch(int colourCode, int type)
        {
            Color32 swatch;
            string codeName;
            ColourDecoder cD = new ColourDecoder();
            codeName = cD.DecipherCode(colourCode);
            swatch = cD.GetColour(codeName);

            if (type == 0)
            {
                Instance.savedA = swatch;
            }
            else if (type == 1)
            {
                Instance.savedD = swatch;
            }

        }





        public void Start()
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                Instance = this;
                sD = KSP.UI.Screens.Flight.SpeedDisplay.Instance;
                tM = sD.textSpeed;
                tM2 = sD.textTitle;

                vSIOptions = HighLogic.CurrentGame.Parameters.CustomParams<VSIOptions>();
                shouldHideButton = vSIOptions.disableButton;
                savedA = vSIOptions.ascCol;
                savedD = vSIOptions.desCol;

            }

        }

        public void Update()
        {
            // if not surface mode then set to stock green

            if (tM2.text != "Surface")
            {
                if (tM.color != stockGreen)
                {
                    tM.color = stockGreen;
                    tM2.color = stockGreen;
                    tM.ForceMeshUpdate();
                    tM2.ForceMeshUpdate();
                }

            }
            else
            {
                // ascending colour handler

                if (!colourSet)
                {
                    if (tM.color != savedA)
                    {
                        tM.color = savedA;
                        tM2.color = savedA;
                        tM.ForceMeshUpdate();
                        tM2.ForceMeshUpdate();
                        vSIOptions.ascCol = savedA;

                    }

                }
                else if (colourSet)
                {
                    //descending colour handler

                    if (tM.color != savedD)
                    {
                        tM.color = savedD;
                        tM2.color = savedD;
                        tM.ForceMeshUpdate();
                        tM2.ForceMeshUpdate();
                        vSIOptions.desCol = savedD;
                    }
                    else return;

                }
            }
        }

        public void FixedUpdate()
        {
            // if we're not landed and navball is in surface mode

            if (HighLogic.LoadedSceneIsFlight && !FlightGlobals.ActiveVessel.Landed && tM2.text == "Surface")
            {
                double verticalSpeed = FlightGlobals.ActiveVessel.verticalSpeed;

                if (verticalSpeed < 0)              // if negative (ie falling)
                {
                    colourSet = true;
                }

                else
                {
                    colourSet = false;
                }

            }

            // if we land set back to green

            else if (HighLogic.LoadedSceneIsFlight && FlightGlobals.ActiveVessel.Landed && tM2.text == "Surface")
            {
                colourSet = false;
            }


        }

    }
}
