using System;
using System.IO;
using BepInEx;
using BepInEx.Configuration;
using SpaceMonke.HarmonyPatches;
using UnityEngine;
using Utilla;

namespace SpaceMonke
{
    [BepInPlugin("org.legoandmars.gorillatag.spacemonke", "Space Monke", "1.1.0")]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.0.0")]
    public class SpaceMonke : BaseUnityPlugin
    {
        public static bool allowSpaceMonke = false;
        public static ConfigEntry<float> multiplier;
        void Awake()
        {
            Utilla.Events.RoomJoined += RoomJoined;
            SpaceMonkePatches.ApplyHarmonyPatches();

            var customFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "SpaceMonke.cfg"), true);
            multiplier = customFile.Bind("Configuration", "JumpMultiplier", 10f, "How much to multiply the jump height/distance by. 10 = 10x higher jumps");
        }

        private void RoomJoined(bool isPrivate)
        {
            allowSpaceMonke = isPrivate;
        }
    }
}