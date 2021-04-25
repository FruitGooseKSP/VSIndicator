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
        [KSPField(isPersistant = true)]
        public Color32 savedA = Color.green;

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

        public VSIOptions vSIOptions;

        public static bool shouldHideButton;

        public bool testDone = true;
        public bool weSwitched = false;
        public static VSI Instance;

        public Color32 aColour = Color.green;
        public Color32 dColour = new Color32(255, 0, 0, 255);


        public static bool GetTM2Text()
        {
            if (Instance.tM2.text == "Surface")
            {
                return true;
            }
            else return false;
        }

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

        public static void TestSwatch(int colourCode, int type)
        {
            //Color32 current1 = Instance.tM.color;
            //Color32 current2 = Instance.tM2.color;
            Color32 swatch;
            string codeName;
            ColourDecoder cD = new ColourDecoder();
            codeName = cD.DecipherCode(colourCode);
            swatch = cD.GetColour(codeName);

            Instance.testDone = false;

            Instance.tM.color = swatch;
            Instance.tM2.color = swatch;
           // Instance.tM2.text = codeName;
            Instance.tM.ForceMeshUpdate();
            Instance.tM2.ForceMeshUpdate();
           
           // StaticCoroutine.Start(Wait(2));

            if (type == 0)
            {
                Instance.savedA = swatch;
            }
            else if (type == 1)
            {
                Instance.savedD = swatch;
            }
            Instance.testDone = true;


        }

  /*      public static IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Instance.tM.color = Instance.savedA;
            Instance.tM2.color = Instance.savedA;
           // Instance.tM2.text = "Surface";
            Instance.tM.ForceMeshUpdate();
            Instance.tM2.ForceMeshUpdate();
            
        }
  */



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
            if (tM2.text != "Surface" && testDone)
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
                if (!colourSet && testDone)
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
                else if (colourSet && testDone)
                {
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
