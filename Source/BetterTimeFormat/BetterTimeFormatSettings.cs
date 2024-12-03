// BetterTimeFormat - ModSettings.cs
// Created on 2022.11.09
// Last modified at 2022.11.14 16:50

#region

using Verse;

#endregion

namespace BetterTimeFormat;

public class BetterTimeFormatSettings : ModSettings
{
    public string AmString = "AM";
    public string PmString = "PM";
    public string TimeFormat = "HH:MM";
    public bool TwelveHourFormat;
    public bool UpdateHours;
    public bool UpdateMinutes;
    public bool UpdateSeconds;
    public bool UpdateTime;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref TimeFormat, "BetterTimeFormatLabel", "HH:MM");
        Scribe_Values.Look(ref AmString, "BetterTimeFormatAMLabel", "AM");
        Scribe_Values.Look(ref PmString, "BetterTimeFormatPMLabel", "PM");
        Scribe_Values.Look(ref TwelveHourFormat, "BetterTimeFormat12hLabel");
        Scribe_Values.Look(ref UpdateHours, "BetterTimeUpdateHours", true);
        Scribe_Values.Look(ref UpdateMinutes, "BetterTimeUpdateMinutes", true);
        Scribe_Values.Look(ref UpdateSeconds, "BetterTimeUpdateSeconds");
        Scribe_Values.Look(ref UpdateTime, "BetterTimeUpdateTime", true);
        base.ExposeData();
    }
}