using KSP.UI.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace VSIndicator
{
    [KSPAddon(KSPAddon.Startup.EveryScene, false)]
    public class VSIGUI : MonoBehaviour
    {

        public Texture vSITextureOff;
        public Texture vSITextureOn;

        public static ApplicationLauncherButton vSIBtn;

        public static bool btnIsPressed = false;

        // does the button exist?
        public static bool btnIsPresent = false;

        // this
        public static VSIGUI instance;

        // menu close button
        public static bool closeBtn;

        // menu position reference ie in the middle of the screen
        private Vector2 menuPR = new Vector2((Screen.width / 2) - 155, (Screen.height / 2) - 230);

        // menu size reference
        private Vector2 menuSR = new Vector2(310, 420);

        // the menu position holder
        private static Rect guiPos;

        public static string currentDCol = "Red";
        public static string currentACol = "Green (Stock)";

        public static Color32 dCol = new Color32(255, 0, 0, 255);
        public static Color32 aCol = Color.green;

        public static int selA;
        public static int selD;
        public int storedA = 1;
        public int storedD = 2;

        public static string[] cols =
        {
            "Green",
            "Red",
            "Orange",
            "Yellow",
            "Cyan",
            "Blue",
            "Magenta",
            "Pink",
            "White",
        };

        
        


        private static void ItsVSITime()
        {

            guiPos = GUI.Window(123457, guiPos, MenuWindow,
                "Select Colour Preferences", new GUIStyle(HighLogic.Skin.window));

           

            vSIBtn.SetTrue();

            btnIsPresent = true;

            if (btnIsPressed)
            {
                vSIBtn.SetTrue();
            }
            else vSIBtn.SetFalse();


        }

        private static void MenuWindow(int windowID)
        {
            // the menu


                  GUI.BeginGroup(new Rect(0,0, 310, 420));


                  GUI.Box(new Rect(0, 0, 310, 420), GUIContent.none);


                  GUI.Label(new Rect(40, 40, 140, 20), "Ascending", new GUIStyle(HighLogic.Skin.label));
                  GUI.Label(new Rect(200, 40, 140, 20), "Descending", new GUIStyle(HighLogic.Skin.label));


                  selA = GUI.SelectionGrid(new Rect(20, 78, 150, 420), selA, cols, 1, new GUIStyle(HighLogic.Skin.toggle));
                  selD = GUI.SelectionGrid(new Rect(180, 78, 110, 420), selD, cols, 1, new GUIStyle(HighLogic.Skin.toggle));


                  closeBtn = GUI.Button(new Rect(110, 375, 100, 25), "Close", new GUIStyle(HighLogic.Skin.button));





                  GUI.DragWindow();



                  GUI.EndGroup();

                  




        }


        public void PerformColourTest(int type)
        {
            int testColour;

            switch (type)
            {
                case 0:
                    testColour = storedA;
                    break;
                case 1:
                    testColour = storedD;
                    break;
                default:
                    testColour = -1;
                    break;
            }
      
            VSI.TestSwatch(testColour, type);


        }


        public void TrialButton()
        {
            VSIOptions vSIOptions = HighLogic.CurrentGame.Parameters.CustomParams<VSIOptions>();

            if (vSIOptions.disableButton)
            {
                if (vSIBtn != null)
                {
                    onDestroy();
                    vSIBtn = null;
                    btnIsPresent = false;
                    GameEvents.OnGameSettingsApplied.Add(TrialButton);
                }
            }

            else
            {
                if (vSIBtn == null)
                {

                    

                    vSIBtn = ApplicationLauncher.Instance.AddModApplication(onTrue, onFalse, onHover, onHoverOut, null, null,
                        ApplicationLauncher.AppScenes.FLIGHT, vSITextureOff);

                    btnIsPresent = true;
                }
            }


        }

        public void SwitchChoice(int type)
        {
            if (type == 0)
            {
                storedA = selA;
                PerformColourTest(0);
            }

            else
            {
                storedD = selD;
                PerformColourTest(1);
            }

            


        }


        public void Start()
        {


            if (HighLogic.LoadedSceneIsFlight)
            {
                instance = this;

                if (vSIBtn != null)
                {
                    onDestroy();
                    vSIBtn = null;
                }


                vSITextureOff = GameDatabase.Instance.GetTexture("FruitKocktail/VertikalSpeedIndicator/Icons/vsioff", false);
                vSITextureOn = GameDatabase.Instance.GetTexture("FruitKocktail/VertikalSpeedIndicator/Icons/vsion", false);
                guiPos = new Rect(menuPR, menuSR);

                selA = VSI.GetColourCodeReversedA();
                selD = VSI.GetColourCodeReversedD();

                GameEvents.OnGameSettingsApplied.Add(TrialButton);
                

                if (!VSI.shouldHideButton)
                {
                    vSIBtn = ApplicationLauncher.Instance.AddModApplication(onTrue, onFalse, onHover, onHoverOut, null, null,
                    ApplicationLauncher.AppScenes.FLIGHT, vSITextureOff);
                    btnIsPresent = true;
                }

                else
                {
                    onDestroy();
                    vSIBtn = null;
                }


                if (btnIsPressed)
                {
                    vSIBtn.SetTrue();
                }
                else vSIBtn.SetFalse();


            }

            else
            {
                if (vSIBtn != null)
                {
                    onDestroy();
                    vSIBtn = null;
                    btnIsPresent = false;
                }
            }

        }


        public void Update()
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                if (vSIBtn != null)
                {
                    // menu button handlers

                    if (closeBtn)
                    {
                        vSIBtn.SetFalse();
                        closeBtn = false;
                    }

                    else if (btnIsPresent)
                    {
                       if (selA != storedA)
                       {
                            SwitchChoice(0);
                       }

                       if (selD != storedD)
                        {
                            SwitchChoice(1);
                        }


                       



                    }






                }

            }
            else
            {
                if (vSIBtn != null)
                {
                    onDestroy();
                    vSIBtn = null;
                    btnIsPresent = false;
                }
            }
        }


        public void OnGUI()
        {
            // handles GUI event (ie button clicked)

            if (btnIsPressed)
            {
                ItsVSITime();
            }
        }

        // button callbacks

        public void onTrue()
        {
            // ie when clicked on
            bool isSurface = VSI.GetTM2Text();

            if (isSurface)
            {
                btnIsPressed = true;
                vSIBtn.SetTexture(vSITextureOn);
            }


           

            
        }

        public void onFalse()
        {
            // ie when clicked off
            if (btnIsPressed)
            {
                //VSI.SetBaseColours(aCol, dCol);
                vSIBtn.SetTexture(vSITextureOff);
                btnIsPressed = false;
            }
        }

        public void onHover()
        {
            // ie on hover
        }

        public void onHoverOut()
        {
            // ie when leave
        }

        private void onDestroy()
        {
            // when destroyed
            ApplicationLauncher.Instance.RemoveModApplication(vSIBtn);
            vSIBtn = null;
            GameEvents.OnGameSettingsApplied.Remove(TrialButton);
        }


    }
}
