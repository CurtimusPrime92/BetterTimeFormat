// This project is subject to the terms of the Mozilla Public License v2.0
// If a copy of the MPL was not distributed with this file,
// You can obtain one at https://mozilla.org/MPL/2.0/

using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace BetterTimeFormat
{
    [StaticConstructorOnStartup]
    public static class BetterTimeFormat
    {
        // Placeholder
    }

    [StaticConstructorOnStartup]
    internal static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("net.netrve.bettertime");

            Log.Message("[BetterTimeFormat] Applying Harmony patch.");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(DateReadout), "DateOnGUI")]
    internal static class Patch_BetterTimeFormat
    {
        public static bool Prefix(
            Rect dateRect,
            ref List<string> ___seasonsCached,
            ref int ___dateStringDay,
            ref Season ___dateStringSeason,
            ref Quadrum ___dateStringQuadrum,
            ref int ___dateStringYear,
            ref string ___dateString
        )
        {
            Vector2 vector2;
            if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.selectedTile >= 0)
            {
                vector2 = Find.WorldGrid.LongLatOf(Find.WorldSelector.selectedTile);
            }
            else if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.NumSelectedObjects > 0)
            {
                vector2 = Find.WorldGrid.LongLatOf(Find.WorldSelector.FirstSelectedObject.Tile);
            }
            else
            {
                if (Find.CurrentMap == null)
                    return false;
                vector2 = Find.WorldGrid.LongLatOf(Find.CurrentMap.Tile);
            }

            var num1 = GenDate.DayOfTwelfth(Find.TickManager.TicksAbs, vector2.x);
            var season = GenDate.Season(Find.TickManager.TicksAbs, vector2);
            var quadrum1 = GenDate.Quadrum(Find.TickManager.TicksAbs, vector2.x);
            var num2 = GenDate.Year(Find.TickManager.TicksAbs, vector2.x);
            var str = true ? ___seasonsCached[(int) season] : "";
            if (num1 != ___dateStringDay || season != ___dateStringSeason || quadrum1 != ___dateStringQuadrum || num2 != ___dateStringYear)
            {
                ___dateString = GenDate.DateReadoutStringAt(Find.TickManager.TicksAbs, vector2);
                ___dateStringDay = num1;
                ___dateStringSeason = season;
                ___dateStringQuadrum = quadrum1;
                ___dateStringYear = num2;
            }

            var dayPercent = GenLocalDate.DayPercent(Find.CurrentMap);
            var hours = Math.Floor(dayPercent * 24);
            var minutes = Math.Floor(dayPercent * 24 % 1 * 60);
            var time = $"{hours,0:00}:{minutes,0:00}";

            Text.Font = GameFont.Small;
            var num3 =
                Mathf.Max(Mathf.Max(Text.CalcSize(time).x, Text.CalcSize(___dateString).x), Text.CalcSize(str).x) + 7f;
            dateRect.xMin = dateRect.xMax - num3;
            if (Mouse.IsOver(dateRect))
                Widgets.DrawHighlight(dateRect);
            GUI.BeginGroup(dateRect);
            Text.Font = GameFont.Small;
            Text.Anchor = TextAnchor.UpperRight;
            var rect = dateRect.AtZero();
            rect.xMax -= 7f;
            Widgets.Label(rect, time);
            rect.yMin += 26f;
            Widgets.Label(rect, ___dateString);
            rect.yMin += 26f;
            if (!str.NullOrEmpty())
                Widgets.Label(rect, str);
            Text.Anchor = TextAnchor.UpperLeft;
            GUI.EndGroup();
            if (!Mouse.IsOver(dateRect))
                return false;
            var stringBuilder = new StringBuilder();
            for (var index2 = 0; index2 < 4; ++index2)
            {
                var quadrum2 = (Quadrum) index2;
                stringBuilder.AppendLine(quadrum2.Label() + " - " + quadrum2.GetSeason(vector2.y).LabelCap());
            }

            var taggedString = "DateReadoutTip".Translate(GenDate.DaysPassed, 15, (NamedArgument) season.LabelCap(), 15,
                (NamedArgument) GenDate.Quadrum(GenTicks.TicksAbs, vector2.x).Label(), (NamedArgument) stringBuilder.ToString());
            TooltipHandler.TipRegion(dateRect, new TipSignal(taggedString, 86423));

            return false;
        }
    }
}