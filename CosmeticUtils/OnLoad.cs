﻿using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;
using MIU;


namespace CosmeticUtils
{
    public class CrystalMarble
    {
        public static bool Patched = false;

        public static void OnLoad()
        {
            SceneManager.sceneLoaded += new UnityAction<Scene, LoadSceneMode>(CrystalMarble.Patch);
        }
        public static void Patch(Scene scene, LoadSceneMode lsm)
        {
            if (!CrystalMarble.Patched)
            {
                new Harmony("com.starnumber.cosmeticutils").PatchAll();
                CrystalMarble.Patched = false;
                SceneManager.sceneLoaded -= new UnityAction<Scene, LoadSceneMode>(CrystalMarble.Patch);
            }
        }
    }
}
