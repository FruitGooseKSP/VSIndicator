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
        private Vector2 menuPR = new Vector2((Screen.width / 2) - 130, (Screen.height / 2) - 220);

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
              guiPos = GUILayout.Window(123457, guiPos, MenuWindow,
                      "Select Colour Preferences", new GUIStyle(HighLogic.Skin.window));

       //     MenuWindow(1234567);
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


            GUILayout.BeginArea(new Rect(Screen.width / 2 - 130, Screen.height / 2 - 220, 260, 440), GUIContent.none, new GUIStyle(HighLogic.Skin.box));
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("Colour", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Label("Ascending", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Label("Descending", new GUIStyle(HighLogic.Skin.label));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("Green (Stock)", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Toggle(true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUILayout.Toggle(false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("Red", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Toggle(true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUILayout.Toggle(false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("Orange", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Toggle(true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUILayout.Toggle(false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("Yellow", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Toggle(true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUILayout.Toggle(false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("Cyan", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Toggle(true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUILayout.Toggle(false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("Blue", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Toggle(true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUILayout.Toggle(false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("Magenta", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Toggle(true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUILayout.Toggle(false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("Pink", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Toggle(true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUILayout.Toggle(false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("White", new GUIStyle(HighLogic.Skin.label));
            GUILayout.Toggle(true, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
            GUILayout.Toggle(false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Button("Close", new GUIStyle(HighLogic.Skin.button), GUILayout.Width(130));

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUI.DragWindow();

            GUILayout.EndArea();

            /*   GUI.BeginGroup(new Rect(Screen.width / 2 - 130, Screen.height / 2 - 270, 260, 440));

               GUI.Box(new Rect(0, 0, 260, 440), "Select Your Colour Preferences");

               GUI.Label(new Rect(20, 40, 80, 20), "Colour");
               GUI.Label(new Rect(100, 40, 80, 20), "Ascending");
               GUI.Label(new Rect(180, 40, 80, 20), "Descending");

               GUI.Label(new Rect(20, 80, 80, 20), "Green (Stock)");
               GUI.Toggle(new Rect(110, 80, 80, 20), 1, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
               GUI.Toggle(new Rect(190, 80, 80, 20), 2, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

               GUI.Label(new Rect(20, 120, 80, 20), "Red");
               GUI.Toggle(new Rect(110, 120, 80, 20), 3, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
               GUI.Toggle(new Rect(190, 120, 80, 20), 4, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

               GUI.Label(new Rect(20, 160, 80, 20), "Orange");
               GUI.Toggle(new Rect(110, 160, 80, 20), 5, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
               GUI.Toggle(new Rect(190, 160, 80, 20), 6, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

               GUI.Label(new Rect(20, 200, 80, 20), "Yellow");
               GUI.Toggle(new Rect(110, 200, 80, 20), 7, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
               GUI.Toggle(new Rect(190, 200, 80, 20), 8, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

               GUI.Label(new Rect(20, 240, 80, 20), "Cyan");
               GUI.Toggle(new Rect(110, 240, 80, 20), 9, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
               GUI.Toggle(new Rect(190, 240, 80, 20), 10, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

               GUI.Label(new Rect(20, 280, 80, 20), "Blue");
               GUI.Toggle(new Rect(110, 280, 80, 20), 11, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
               GUI.Toggle(new Rect(190, 280, 80, 20), 12, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

               GUI.Label(new Rect(20, 320, 80, 20), "Magenta");
               GUI.Toggle(new Rect(110, 320, 80, 20), 13, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
               GUI.Toggle(new Rect(190, 320, 80, 20), 14, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

               GUI.Label(new Rect(20, 360, 80, 20), "Pink");
               GUI.Toggle(new Rect(110, 360, 80, 20), 15, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
               GUI.Toggle(new Rect(190, 360, 80, 20), 16, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));

               GUI.Label(new Rect(20, 400, 80, 20), "White");
               GUI.Toggle(new Rect(110, 400, 80, 20), 17, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));
               GUI.Toggle(new Rect(190, 400, 80, 20), 18, false, GUIContent.none, new GUIStyle(HighLogic.Skin.toggle));







               GUI.EndGroup();
           */


            /* GUILayout.BeginVertical();
             GUILayout.Space(20);

             GUILayout.BeginArea(new Rect(20, 40, 360, 400));

             GUILayout.BeginHorizontal();
             GUILayout.Space(20);
             GUILayout.Label("Select Ascending Colour", new GUIStyle(HighLogic.Skin.label));
             GUILayout.Space(20);
             GUILayout.EndHorizontal();

             GUILayout.BeginHorizontal();
             GUILayout.Space(20);
             selection = GUI.SelectionGrid(new Rect(20, 100, 360, 300), selection, selString1, 2, new GUIStyle(HighLogic.Skin.toggle));
             GUILayout.Space(20);
             GUILayout.EndHorizontal();

             GUILayout.EndArea();

             GUILayout.BeginArea(new Rect(20, 440, 360, 400));

             GUILayout.BeginHorizontal();
             GUILayout.Space(20);
             GUILayout.Label("Select Descending Colour", new GUIStyle(HighLogic.Skin.label));
             GUILayout.Space(20);
             GUILayout.EndHorizontal();

             GUILayout.BeginHorizontal();
             GUILayout.Space(20);
             selection2 = GUI.SelectionGrid(new Rect(20, 500, 360, 800), selection, selString2, 2, new GUIStyle(HighLogic.Skin.toggle));
             GUILayout.Space(20);
             GUILayout.EndHorizontal();


             GUILayout.EndArea();


             GUILayout.EndVertical();
            */


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
