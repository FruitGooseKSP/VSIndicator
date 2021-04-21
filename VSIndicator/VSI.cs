using KSP.UI.Screens.Flight;
using System;
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
        // The speed display component on the navball
        public SpeedDisplay sD;

        // the TM text for speed
        public TextMeshProUGUI tM;

        // the TM text for velocity mode
        public TextMeshProUGUI tM2;

        // bool to switch colour
        public bool colourSet = false;

        // the colour we switch to
        public Color32 redColour = new Color32();
        

        public void Start()
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                
                sD = KSP.UI.Screens.Flight.SpeedDisplay.Instance;
                tM = sD.textSpeed;
                tM2 = sD.textTitle;
                redColour = new Color32(255, 48, 48, 255);      // Color.red would probably work in hindsight

            }

        }

        public void Update()
        {
            if (!colourSet)
            {
                tM.color = Color.green;
                tM2.color = Color.green;
                tM.ForceMeshUpdate();
            }
            else
            {

                tM.color = redColour;
                tM2.color = redColour;
                tM.ForceMeshUpdate();
                
            }
        }

        public void FixedUpdate()
        {
            // if we're not landed and navball is in surface mode

            if (HighLogic.LoadedSceneIsFlight && !FlightGlobals.ActiveVessel.Landed && tM2.text == "Surface")
            {
                double verticalSpeed = FlightGlobals.ActiveVessel.verticalSpeed;    // get vessel vertical speed

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
