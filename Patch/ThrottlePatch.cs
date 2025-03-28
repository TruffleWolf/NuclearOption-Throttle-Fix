using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using Rewired;

namespace NuclearOption_Throttle_Fix.Patch
{
    [HarmonyPatch(typeof(PilotPlayerState))]
    internal class ThrottlePatch
    {

        [HarmonyPatch("PlayerAxisControls")]
        [HarmonyPrefix]
        static void InfoPatch(ref float ___simulatedThrottle,out float __state)
        {

            __state = ___simulatedThrottle;

        }

        [HarmonyPatch("PlayerAxisControls")]
        [HarmonyPostfix]
        static void InfoPatch2(ref ControlInputs ___controlInputs, ref Rewired.Player ___player,ref float ___simulatedThrottle,float __state)
        {
            float simThrottle = __state;
            float num2 = Mathf.Clamp(___player.GetAxisRaw("Throttle"), -1f, 1f);

            simThrottle += Mathf.Clamp(num2, 0f - (Time.deltaTime*Mathf.Abs(num2)), (Time.deltaTime * Mathf.Abs(num2)));

            ___simulatedThrottle = Mathf.Clamp01(simThrottle);
            ___controlInputs.throttle = ___simulatedThrottle;
            
        }



    }
}
