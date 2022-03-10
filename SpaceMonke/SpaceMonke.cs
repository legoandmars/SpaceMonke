using System;
using System.IO;
using BepInEx;
using BepInEx.Configuration;
using SpaceMonke.HarmonyPatches;
using UnityEngine;
using Utilla;
using System.ComponentModel;

namespace SpaceMonke
{
    [Description("HauntedModMenu")]
    [BepInPlugin("org.legoandmars.gorillatag.spacemonke", "Space Monke", "1.2.3")]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [ModdedGamemode]
    public class SpaceMonke : BaseUnityPlugin
    {
        public static bool allowSpaceMonke = false;
        public static ConfigEntry<float> multiplier;

        void OnEnable()
        {
            SpaceMonkePatches.ApplyHarmonyPatches();

            var customFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "SpaceMonke.cfg"), true);
            multiplier = customFile.Bind("Configuration", "JumpMultiplier", 10f, "How much to multiply the jump height/distance by. 10 = 10x higher jumps");
        }

        void OnDisable()
        {
            SpaceMonkePatches.RemoveHarmonyPatches();
        }

        [ModdedGamemodeJoin]
        private void RoomJoined()
		{
            allowSpaceMonke = true;
		}

        [ModdedGamemodeLeave]
        private void RoomLeft()
		{
            allowSpaceMonke = false;
		}
    }
}
