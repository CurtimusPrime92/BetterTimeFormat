using Mlie;
using UnityEngine;
using Verse;

namespace BetterTimeFormat;

public class BetterTimeFormatMod : Mod
{
    public static BetterTimeFormatSettings Settings;
    private static string currentVersion;

    public BetterTimeFormatMod(ModContentPack content) : base(content)
    {
        Settings = GetSettings<BetterTimeFormatSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
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
        Settings.TimeFormat = lS.TextEntryLabeled("BetterTimeFormatLabel".Translate(), Settings.TimeFormat);

        lS.Label("BetterTimeFormat12hDesc".Translate());
        var currentClockValue = Prefs.TwelveHourClockMode;
        lS.CheckboxLabeled("BetterTimeFormat12hLabel".Translate(), ref currentClockValue);
        Prefs.TwelveHourClockMode = currentClockValue;

        if (Prefs.TwelveHourClockMode)
        {
            lS.Label("BetterTimeFormatAMDesc".Translate());
            Settings.AmString = lS.TextEntryLabeled("BetterTimeFormatAMLabel".Translate(), Settings.AmString);

            lS.Label("BetterTimeFormatPMDesc".Translate());
            Settings.PmString = lS.TextEntryLabeled("BetterTimeFormatPMLabel".Translate(), Settings.PmString);
        }

        if (currentVersion != null)
        {
            lS.Gap();
            GUI.contentColor = Color.gray;
            lS.Label("BetterTimeFormatModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        lS.End();

        Settings.UpdateSeconds = Settings.TimeFormat.Contains("S");
        Settings.UpdateMinutes = Settings.TimeFormat.Contains("M");
        Settings.UpdateHours = Settings.TimeFormat.Contains("H");

        Settings.UpdateTime = Settings.UpdateHours || Settings.UpdateMinutes || Settings.UpdateSeconds;

        base.DoSettingsWindowContents(inRect);
    }
}