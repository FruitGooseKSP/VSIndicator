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

        public static VSI Instance;

        public Color32 aColour = Color.green;
        public Color32 dColour = new Color32(255, 0, 0, 255);


        public static void SetBaseColours(Color32 _aColour, Color32 _dColour)
        {
            Instance.savedA = _aColour;
            Instance.savedD = _dColour;
        }


        public static void TestSwatch(int colourCode)
        {
            Color32 current1 = Instance.tM.color;
            Color32 current2 = Instance.tM2.color;
            Color32 swatch;
            string codeName;
            ColourDecoder cD = new ColourDecoder();
            codeName = cD.DecipherCode(colourCode);
            swatch = cD.GetColour(codeName);

            Instance.testDone = false;

            Instance.tM.color = swatch;
            Instance.tM2.color = swatch;
            Instance.tM.ForceMeshUpdate();
            Instance.tM2.ForceMeshUpdate();
           
            StaticCoroutine.Start(Wait(3));

          
                
            

        }

        public static IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Instance.tM.color = Instance.savedA;
            Instance.tM2.color = Instance.savedA;
            Instance.tM.ForceMeshUpdate();
            Instance.tM2.ForceMeshUpdate();
            Instance.testDone = true;
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

            }

        }

        public void Update()
        {
            if (!colourSet && testDone)
            {
                if (tM.color != savedA)
                {
                    tM.color = savedA;
                    tM2.color = savedA;
                    tM.ForceMeshUpdate();
                    tM2.ForceMeshUpdate();
                }

            }
            else
            {
                if (tM.color != savedD)
                {
                    tM.color = savedD;
                    tM2.color = savedD;
                    tM.ForceMeshUpdate();
                    tM2.ForceMeshUpdate();
                }
                else return;

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

            else if (HighLogic.LoadedSceneIsFlight && FlightGlobals.ActiveVessel.Landed)
            {
                colourSet = false;
            }
            

        }






    }
}
