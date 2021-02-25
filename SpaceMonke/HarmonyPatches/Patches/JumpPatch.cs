using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;

namespace SpaceMonke.HarmonyPatches
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("Update", MethodType.Normal)]
    internal class JumpPatch
    {
        public static bool ResetSpeed = false;
        private static void Prefix(GorillaLocomotion.Player __instance)
        {
            if (SpaceMonke.allowSpaceMonke)
            {
                ResetSpeed = true;
                __instance.jumpMultiplier = (40f * (SpaceMonke.multiplier.Value / 10));
                __instance.maxJumpSpeed = (40f * (SpaceMonke.multiplier.Value / 10));
                __instance.velocityLimit = 0.01f / (SpaceMonke.multiplier.Value / 10);
                if(SpaceMonke.multiplier.Value == 1)
                {
                    __instance.jumpMultiplier = 1.1f;
                    __instance.maxJumpSpeed = 6.5f;
                    __instance.velocityLimit = 0.3f;
                }
            }
            else
            {
                if(ResetSpeed == true || __instance.maxJumpSpeed == (40f * (SpaceMonke.multiplier.Value/10)))
                {
                    __instance.jumpMultiplier = 1.1f;
                    __instance.maxJumpSpeed = 6.5f;
                    __instance.velocityLimit = 0.3f;
                    ResetSpeed = false;
                }
            }
        }
    }
}
