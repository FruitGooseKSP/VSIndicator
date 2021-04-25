using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace VSIndicator
{
    public class VSIOptions : GameParameters.CustomParameterNode
    {
        public override string Title { get { return "Button Settings"; } }
        public override GameParameters.GameMode GameMode { get { return GameParameters.GameMode.ANY; } }
        public override string Section { get { return "Vertikal Speed Indicator"; } }
        public override string DisplaySection { get { return "Vertikal Speed Indicator"; } }
        public override int SectionOrder { get { return 1; } }
        public override bool HasPresets { get { return true; } }

        [GameParameters.CustomParameterUI("Disable Toolbar Button")]
        public bool disableButton = false;

        [GameParameters.CustomParameterUI("Saved Ascending Colour")]
        public Color32 ascCol = Color.green;

        [GameParameters.CustomParameterUI("Saved Descending Colour")]
        public Color32 desCol = Color.red;

        public override void SetDifficultyPreset(GameParameters.Preset preset)
        {
        }

        public override bool Enabled(MemberInfo member, GameParameters parameters)
        {
            if (member.Name == "EnabledForSave")
                return true;

            return true;
        }

    
    }
}
