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
        // toolbar button textures
        public Texture vSITextureOff;
        public Texture vSITextureOn;

        //toolbar button
        public static ApplicationLauncherButton vSIBtn;

        // has the button been pressed?
        public static bool btnIsPressed = false;

        // does the button exist?
        public static bool btnIsPresent = false;

        // this
        public static VSIGUI instance;

        // menu close button
        public static bool closeBtn;

        // menu position reference ie in the middle of the screen & shifted up a little
        public static Vector2 menuPR = new Vector2((Screen.width / 2) - 155, (Screen.height / 2) - 230);

        // menu size reference
        public static Vector2 menuSR = new Vector2(500, 340);

        // the menu position holder
        public static Rect guiPos;

        // colour option references
        public static int selA;
        public static int selD;
        public static int selS;

        public static float selV;

        // local stored colour option
        public int storedA = 1;
        public int storedD = 2;
        public int storedS = 3;

        // toggle button labels
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


        public static GUIStyle toggleStyle;
        public static GUIStyle labelStyle;
        public static GUIStyle labelStyle2;
        public static GUIStyle labelStyleD;
        public static GUIStyle labelStyleS;



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
                selS = VSI.GetColourCodeReveredS();

                selV = 5.0f;

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

                toggleStyle = new GUIStyle(HighLogic.Skin.toggle)
                {
                    alignment = TextAnchor.MiddleCenter,
                    stretchHeight = true,
                };

                labelStyle  = new GUIStyle(HighLogic.Skin.label);
                labelStyleD = new GUIStyle(HighLogic.Skin.label);
                labelStyleS = new GUIStyle(HighLogic.Skin.label);

                labelStyle2 = new GUIStyle(HighLogic.Skin.label);
                labelStyle2.normal.textColor = Color.white;

                

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
                        ColourDecoder cD = new ColourDecoder();

                        if (selA != storedA)
                        {
                            SwitchChoice(0);
                            
                            switch (selA)
                            {
                                case 0:
                                    labelStyle.normal.textColor = cD.GetColour("Green");
                                    break;
                                case 1:
                                    labelStyle.normal.textColor = cD.GetColour("Red");
                                    break;
                                case 2:
                                    labelStyle.normal.textColor = cD.GetColour("Orange");
                                    break;
                                case 3:
                                    labelStyle.normal.textColor = cD.GetColour("Yellow");
                                    break;
                                case 4:
                                    labelStyle.normal.textColor = cD.GetColour("Cyan");
                                    break;
                                case 5:
                                    labelStyle.normal.textColor = cD.GetColour("Blue");
                                    break;
                                case 6:
                                    labelStyle.normal.textColor = cD.GetColour("Magenta");
                                    break;
                                case 7:
                                    labelStyle.normal.textColor = cD.GetColour("Pink");
                                    break;
                                case 8:
                                    labelStyle.normal.textColor = cD.GetColour("White");
                                    break;
                            }
                        }

                        if (selD != storedD)
                        {
                            SwitchChoice(1);

                            switch (selD)
                            {
                                case 0:
                                    labelStyleD.normal.textColor = cD.GetColour("Green");
                                    break;
                                case 1:
                                    labelStyleD.normal.textColor = cD.GetColour("Red");
                                    break;
                                case 2:
                                    labelStyleD.normal.textColor = cD.GetColour("Orange");
                                    break;
                                case 3:
                                    labelStyleD.normal.textColor = cD.GetColour("Yellow");
                                    break;
                                case 4:
                                    labelStyleD.normal.textColor = cD.GetColour("Cyan");
                                    break;
                                case 5:
                                    labelStyleD.normal.textColor = cD.GetColour("Blue");
                                    break;
                                case 6:
                                    labelStyleD.normal.textColor = cD.GetColour("Magenta");
                                    break;
                                case 7:
                                    labelStyleD.normal.textColor = cD.GetColour("Pink");
                                    break;
                                case 8:
                                    labelStyleD.normal.textColor = cD.GetColour("White");
                                    break;
                            }
                        }

                        if (selS != storedS)
                        {
                            SwitchChoice(2);

                            switch (selS)
                            {
                                case 0:
                                    labelStyleS.normal.textColor = cD.GetColour("Green");
                                    break;
                                case 1:
                                    labelStyleS.normal.textColor = cD.GetColour("Red");
                                    break;
                                case 2:
                                    labelStyleS.normal.textColor = cD.GetColour("Orange");
                                    break;
                                case 3:
                                    labelStyleS.normal.textColor = cD.GetColour("Yellow");
                                    break;
                                case 4:
                                    labelStyleS.normal.textColor = cD.GetColour("Cyan");
                                    break;
                                case 5:
                                    labelStyleS.normal.textColor = cD.GetColour("Blue");
                                    break;
                                case 6:
                                    labelStyleS.normal.textColor = cD.GetColour("Magenta");
                                    break;
                                case 7:
                                    labelStyleS.normal.textColor = cD.GetColour("Pink");
                                    break;
                                case 8:
                                    labelStyleS.normal.textColor = cD.GetColour("White");
                                    break;
                            }
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

        // launch the menu

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

            GUI.BeginGroup(new Rect(0, 0, menuSR.x, menuSR.y));
            GUI.Box(new Rect(0, 0, menuSR.x, menuSR.y), GUIContent.none);

            closeBtn = GUI.Button(new Rect(menuSR.x - 30, 0, 30, 30), "X", new GUIStyle(HighLogic.Skin.button));

            GUI.Label(new Rect(40, 40, menuSR.x / 3, 25), "Ascending Colour = ", labelStyle2);
            GUI.Label(new Rect(menuSR.x / 3 + 20, 40, menuSR.x / 3, 25), cols[selA], labelStyle);
            selA = (int)GUI.HorizontalSlider(new Rect(40, 80, menuSR.x - 80, 25), selA, 0, 8, new GUIStyle(HighLogic.Skin.horizontalSlider),
                new GUIStyle(HighLogic.Skin.horizontalSliderThumb));

            GUI.Label(new Rect(40, 105, menuSR.x / 3, 25), "Descending Colour = ", labelStyle2);
            GUI.Label(new Rect(menuSR.x / 3 + 20, 105, menuSR.x / 3, 25), cols[selD], labelStyleD);
            selD = (int)GUI.HorizontalSlider(new Rect(40, 145, menuSR.x - 80, 25), selD, 0, 8, new GUIStyle(HighLogic.Skin.horizontalSlider),
                new GUIStyle(HighLogic.Skin.horizontalSliderThumb));

            GUI.Label(new Rect(40, 180, menuSR.x / 3, 25), "Safe Velocity Colour = ", labelStyle2);
            GUI.Label(new Rect(menuSR.x / 3 + 20, 180, menuSR.x / 3, 25), cols[selS], labelStyleS);
            selS = (int)GUI.HorizontalSlider(new Rect(40, 220, menuSR.x - 80, 25), selS, 0, 8, new GUIStyle(HighLogic.Skin.horizontalSlider),
                new GUIStyle(HighLogic.Skin.horizontalSliderThumb));

            GUI.Label(new Rect(40, 245, menuSR.x - 80, 25), "Safe Velocity, m/s2 = " + Math.Round(selV, 1), labelStyle2);
            selV = GUI.HorizontalSlider(new Rect(40, 285, menuSR.x - 80, 25), selV, 0, 20, new GUIStyle(HighLogic.Skin.horizontalSlider),
                new GUIStyle(HighLogic.Skin.horizontalSliderThumb));

            GUI.DragWindow();

            GUI.EndGroup();


        }

        // misleading name, actual sends the chosen colour to the main class which then stores it
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
                case 2:
                    testColour = storedS;
                    break;
                default:
                    testColour = -1;
                    break;
            }

            VSI.TestSwatch(testColour, type);


        }

        // tests if toolbar button should be displayed (ie according to option selection)
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

        // colour switch handler
        public void SwitchChoice(int type)
        {
            if (type == 0)
            {
                storedA = selA;
                PerformColourTest(0);
            }

            else if (type == 1)
            {
                storedD = selD;
                PerformColourTest(1);
            }

            else
            {
                storedS = selS;
                PerformColourTest(2);
            }

        }


    }
}
