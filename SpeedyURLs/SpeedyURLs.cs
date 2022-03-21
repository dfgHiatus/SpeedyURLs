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
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/dfgHiatus/SpeedyURLs/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.dfgHiatus.SpeedyURLs");
            harmony.PatchAll();
        }
		
        [HarmonyPatch(typeof(HyperlinkOpenDialog), "Setup")]
        public class HyperlinkOpenDialogPatch
        {
            public static bool Prefix(Hyperlink __instance, Uri uri, string reason, 
                SyncRef<Text> ____hyperlinkText, SyncRef<Text> ____reasonText, SyncRef<Button> ____openButton)
            {
                __instance.URL.Value = uri;
                ____hyperlinkText.Target.Content.Value = uri?.ToString();
                if (reason == null)
                    ____reasonText.Target.Content.SetLocalized("Security.HostAccess.NoReason");
                else
                    ____reasonText.Target.Content.SetLocalized("Security.HostAccess.Reason", null, nameof(reason), reason);
                // Remove the 5-second delay on hyperlinks
                // ____openButton.Target.EnableTimeout(0);
                return false;
            }
        }
    }
}