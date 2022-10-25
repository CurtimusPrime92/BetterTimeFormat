// BetterTimeFormat - ModSettings.cs
// Created on 2022.10.25
// Last modified at 2022.10.25 18:56

#region
using UnityEngine;

using Verse;
#endregion

namespace BetterTimeFormat
{
    public class BetterTimeFormatSettings : ModSettings
    {
        public string amString = "AM";
        public string pmString = "PM";
        public string timeFormat = "HH:MM";
        public bool twelveHourFormat;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref timeFormat, "BetterTimeFormatLabel");
            Scribe_Values.Look(ref amString, "BetterTimeFormatAMLabel");
            Scribe_Values.Look(ref pmString, "BetterTimeFormatPMLabel");
            Scribe_Values.Look(ref twelveHourFormat, "BetterTimeFormat12hLabel");
        }
    }

    internal class BetterTimeFormatMod : Mod
    {
        public static BetterTimeFormatSettings settings;
        public static bool UpdateSeconds;
        public static bool UpdateMinutes;
        public static bool UpdateHours;
        public static bool UpdateTime;

        public BetterTimeFormatMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<BetterTimeFormatSettings>();
        }

        public override string SettingsCategory()
        {
            return "BetterTimeFormatCategoryLabel".Translate();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            var lS = new Listing_Standard();
            lS.Begin(inRect);
            lS.verticalSpacing = 12f;

            lS.Label("BetterTimeFormatDesc".Translate());
            settings.timeFormat = lS.TextEntryLabeled("BetterTimeFormatLabel".Translate(), settings.timeFormat);

            lS.Label("BetterTimeFormat12hDesc".Translate());
            lS.CheckboxLabeled("BetterTimeFormat12hLabel".Translate(), ref settings.twelveHourFormat);

            if (settings.twelveHourFormat)
            {
                lS.Label("BetterTimeFormatAMDesc".Translate());
                settings.amString = lS.TextEntryLabeled("BetterTimeFormatAMLabel".Translate(), settings.amString);

                lS.Label("BetterTimeFormatPMDesc".Translate());
                settings.pmString = lS.TextEntryLabeled("BetterTimeFormatPMLabel".Translate(), settings.pmString);
            }

            lS.End();

            UpdateSeconds = settings.timeFormat.Contains("S");
            UpdateMinutes = settings.timeFormat.Contains("M");
            UpdateHours = settings.timeFormat.Contains("H");

            UpdateTime = UpdateHours || UpdateMinutes || UpdateSeconds;

            settings.Write();
        }
    }
}
