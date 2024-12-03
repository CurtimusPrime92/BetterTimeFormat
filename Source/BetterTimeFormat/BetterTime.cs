// BetterTimeFormat - BetterTime.cs
// Created on 2022.11.09
// Last modified at 2022.11.14 16:50

using System.Reflection;
using HarmonyLib;
using Verse;

namespace BetterTimeFormat;

[StaticConstructorOnStartup]
public static class BetterTimeFormat
{
    static BetterTimeFormat()
    {
        Log.Message("[BetterTimeFormat] Applying Harmony patch.");
        new Harmony("netrve.bettertime").PatchAll(Assembly.GetExecutingAssembly());
    }
}