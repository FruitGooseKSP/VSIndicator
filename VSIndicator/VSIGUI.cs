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

        public static bool closeBtn;

        // menu position reference ie in the middle of the screen
        private Vector2 menuPR = new Vector2((Screen.width / 2) - 130, (Screen.height / 2) - 260);

        // menu size reference
        private Vector2 menuSR = new Vector2(260, 440);

        // the menu position holder
        private static Rect guiPos;

        public static int selection = 1;
        public static int selection2 = 1;

        public static int colorCode1;
        public static int colorCode2;

        public static string[] selString1 = new string[]
        {
            "Green (Stock)",
            "Red",
            "Orange",
            "Yellow",
            "Cyan",
            "Blue",
            "Magenta",
            "Pink",
            "White",
        };

        public static string[] selString2 = new string[]
        {
            "Green (Stock)",
            "Red",
            "Orange",
            "Yellow",
            "Cyan",
            "Blue",
            "Magenta",
            "Pink",
            "White",
        };

        public static string currentDCol = "Red";
        public static string currentACol = "Green (Stock)";

        public static Color32 dCol = new Color32(255, 0, 0, 255);
        public static Color32 aCol = Color.green;
        








        private static void ItsVSITime()
        {
            //   guiPos = GUILayout.Window(123457, guiPos, MenuWindow,
            //        "Select Colour Preferences", new GUIStyle(HighLogic.Skin.window));


            // MenuWindow(1234567);

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





            GUI.DragWindow();

           
            GUI.BeginGroup(new Rect(0,0, 260, 440));

            
            GUI.Box(new Rect(0, 0, 260, 440), GUIContent.none);

            GUI.Button(new Rect(240, 0, 20, 20), "X", new GUIStyle(HighLogic.Skin.button));

            GUI.Label(new Rect(20, 40, 80, 20), "Colour", new GUIStyle(HighLogic.Skin.label));
            GUI.Label(new Rect(100, 40, 80, 20), "Ascending", new GUIStyle(HighLogic.Skin.label));
            GUI.Label(new Rect(180, 40, 80, 20), "Descending", new GUIStyle(HighLogic.Skin.label));

            GUI.Label(new Rect(20, 80, 80, 20), "Green (Stock)");
            GUI.Toggle(new Rect(110, 78, 80, 20), 1, true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUI.Toggle(new Rect(192, 78, 80, 20), 2, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUI.Label(new Rect(20, 120, 80, 20), "Red");
            GUI.Toggle(new Rect(110, 118, 80, 20), 3, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUI.Toggle(new Rect(192, 118, 80, 20), 4, true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUI.Label(new Rect(20, 160, 80, 20), "Orange");
            GUI.Toggle(new Rect(110, 158, 80, 20), 5, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUI.Toggle(new Rect(192, 158, 80, 20), 6, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUI.Label(new Rect(20, 200, 80, 20), "Yellow");
            GUI.Toggle(new Rect(110, 198, 80, 20), 7, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUI.Toggle(new Rect(192, 198, 80, 20), 8, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUI.Label(new Rect(20, 240, 80, 20), "Cyan");
            GUI.Toggle(new Rect(110, 238, 80, 20), 9, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUI.Toggle(new Rect(192, 238, 80, 20), 10, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUI.Label(new Rect(20, 280, 80, 20), "Blue");
            GUI.Toggle(new Rect(110, 278, 80, 20), 11, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUI.Toggle(new Rect(192, 278, 80, 20), 12, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUI.Label(new Rect(20, 320, 80, 20), "Magenta");
            GUI.Toggle(new Rect(110, 318, 80, 20), 13, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUI.Toggle(new Rect(192, 318, 80, 20), 14, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUI.Label(new Rect(20, 360, 80, 20), "Pink");
            GUI.Toggle(new Rect(110, 358, 80, 20), 15, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUI.Toggle(new Rect(192, 358, 80, 20), 16, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUI.Label(new Rect(20, 400, 80, 20), "White");
            GUI.Toggle(new Rect(110, 398, 80, 20), 17, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUI.Toggle(new Rect(192, 398, 80, 20), 18, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));







            GUI.EndGroup();
           
           




        }


        public void PerformColourTest(int type)
        {
            Color32 testColour = Color.green;

            switch (type)
            {
                case 0:
                    testColour = aCol;
                    break;
                case 1:
                    testColour = dCol;
                    break;
            }

            VSI.TestSwatch(testColour);


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
                        if (colorCode1 != selection)
                        {
                            colorCode1 = selection;
                            ColourDecoder cD = new ColourDecoder();
                            currentACol = cD.DecipherCode(selection);
                            aCol = cD.GetColour(currentACol);
                            PerformColourTest(0);
                        }

                        if (colorCode2 != selection2)
                        {
                            colorCode2 = selection2;
                            ColourDecoder cD2 = new ColourDecoder();
                            currentDCol = cD2.DecipherCode(selection2);
                            dCol = cD2.GetColour(currentDCol);
                            PerformColourTest(1);
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
