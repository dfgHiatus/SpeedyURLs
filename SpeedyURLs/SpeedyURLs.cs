using HarmonyLib;
using NeosModLoader;
using FrooxEngine;
using System;
using BaseX;
using FrooxEngine.UIX;

namespace SpeedyURLNamespace
{
    public class SpeedyURLs : NeosMod
    {
        public override string Name => "SpeedyURLs";
        public override string Author => "dfgHiatus";
        public override string Version => "1.1.0";
        public override string Link => "https://github.com/dfgHiatus/SpeedyURLs/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.dfgHiatus.SpeedyURLs");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(UIExtensions), "EnableTimeout", new Type[] {typeof(Component), typeof(IField<bool>), typeof(IField<string>), typeof(int)})]
        public class HyperlinkOpenDialogPatch
        {
            public static void Prefix(ref int timeout)
            {
                timeout = 0;
            }
        }
    }
}