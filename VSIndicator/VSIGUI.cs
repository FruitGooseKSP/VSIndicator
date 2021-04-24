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
        private Vector2 menuPR = new Vector2((Screen.width / 2) - 130, (Screen.height / 2) - 260);

        // menu size reference
        private Vector2 menuSR = new Vector2(260, 440);

        // the menu position holder
        private static Rect guiPos;

        public static int selection = 1;
        public static int selection2 = 1;

        public static string currentDCol = "Red";
        public static string currentACol = "Green (Stock)";

        public static Color32 dCol = new Color32(255, 0, 0, 255);
        public static Color32 aCol = Color.green;

        public static int selA;
        public static int selD;

        public static string[] bS =
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
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





            

           
            GUI.BeginGroup(new Rect(0,0, 260, 440));

            
            GUI.Box(new Rect(0, 0, 260, 440), GUIContent.none);

            closeBtn = GUI.Button(new Rect(240, 0, 20, 20), "X", new GUIStyle(HighLogic.Skin.button));

            GUI.Label(new Rect(20, 40, 80, 20), "Colour", new GUIStyle(HighLogic.Skin.label));
            GUI.Label(new Rect(100, 40, 80, 20), "Ascending", new GUIStyle(HighLogic.Skin.label));
            GUI.Label(new Rect(180, 40, 80, 20), "Descending", new GUIStyle(HighLogic.Skin.label));

            GUI.Label(new Rect(20, 80, 80, 20), "Green (Stock)");
           

            GUI.Label(new Rect(20, 120, 80, 20), "Red");
         

            GUI.Label(new Rect(20, 160, 80, 20), "Orange");
          

            GUI.Label(new Rect(20, 200, 80, 20), "Yellow");
          

            GUI.Label(new Rect(20, 240, 80, 20), "Cyan");
           

            GUI.Label(new Rect(20, 280, 80, 20), "Blue");
           

            GUI.Label(new Rect(20, 320, 80, 20), "Magenta");
            

            GUI.Label(new Rect(20, 360, 80, 20), "Pink");
            

            GUI.Label(new Rect(20, 400, 80, 20), "White");


            selA = GUI.SelectionGrid(new Rect(110, 78, 80, 20), selA, bS, 1, new GUIStyle(HighLogic.Skin.toggle));
            selD = GUI.SelectionGrid(new Rect(192, 78, 80, 20), selD, bS, 1, new GUIStyle(HighLogic.Skin.toggle));

            GUI.DragWindow();



            GUI.EndGroup();

            




        }


        public void PerformColourTest(int type)
        {
     //       int testColour;

      /*      switch (type)
            {
                case 0:
                    testColour = storedBoolA;
                    break;
                case 1:
                    testColour = storedBoolD;
                    break;
                default:
                    testColour = -1;
                    break;
            }
      */
      //      VSI.TestSwatch(testColour);


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
                }
            }

            else
            {
                if (vSIBtn == null)
                {

                    GameEvents.OnGameSettingsApplied.Add(TrialButton);

                    vSIBtn = ApplicationLauncher.Instance.AddModApplication(onTrue, onFalse, onHover, onHoverOut, null, null,
                        ApplicationLauncher.AppScenes.FLIGHT, vSITextureOff);

                    btnIsPresent = true;
                }
            }


        }

        public void QryMultiPress()
        {
            

            


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


                vSITextureOff = GameDatabase.Instance.GetTexture("FruitKocktail/GRAPES/Icons/grapesoff", false);
                vSITextureOn = GameDatabase.Instance.GetTexture("FruitKocktail/GRAPES/Icons/grapeson", false);
                guiPos = new Rect(menuPR, menuSR);


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
                       // QryMultiPress();

                       



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
            btnIsPressed = true;
            vSIBtn.SetTexture(vSITextureOn);

            
        }

        public void onFalse()
        {
            // ie when clicked off
            if (btnIsPressed)
            {
                VSI.SetBaseColours(aCol, dCol);
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
