using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using NuclearOption_Throttle_Fix.Patch;

namespace NuclearOption_Throttle_Fix
{
    [BepInPlugin(modGUID,modName,modVersion)]
    public class ThrottleFixBase :BaseUnityPlugin
    {
        private const string modGUID = "Truffle.NOThrottleFix";
        private const string modName = "Trigger Throttle Fix";
        private const string modVersion = "0.30.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        internal static ThrottleFixBase Instance;
        internal static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            harmony.PatchAll(typeof(ThrottleFixBase));
            harmony.PatchAll(typeof(ThrottlePatch));
            mls.LogInfo("Trigger Throttle Fix Started");
        }
    }
}
