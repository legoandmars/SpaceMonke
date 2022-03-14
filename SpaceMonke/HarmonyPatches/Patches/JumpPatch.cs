using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;

namespace SpaceMonke.HarmonyPatches
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    internal class JumpPatch
    {
        public static bool ResetSpeed = false;
        private static void Prefix()
        {
            if (SpaceMonke.allowSpaceMonke)
            {
                ResetSpeed = true;
                GorillaLocomotion.Player.Instance.jumpMultiplier = (20 * (SpaceMonke.multiplier.Value / 10));
                GorillaLocomotion.Player.Instance.maxJumpSpeed = (20 * (SpaceMonke.multiplier.Value / 10));
                GorillaLocomotion.Player.Instance.velocityLimit = 0.01f / (SpaceMonke.multiplier.Value / 10);
                if(SpaceMonke.multiplier.Value == 1)
                {
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 1.1f;
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
                    GorillaLocomotion.Player.Instance.velocityLimit = 0.3f;
                }
            }
            else
            {
                if(ResetSpeed == true || GorillaLocomotion.Player.Instance.maxJumpSpeed == (40f * (SpaceMonke.multiplier.Value/10)))
                {
                    GorillaLocomotion.Player.Instance.jumpMultiplier = 1.1f;
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
                    GorillaLocomotion.Player.Instance.velocityLimit = 0.3f;
                    ResetSpeed = false;
                }
            }
        }
    }
}
