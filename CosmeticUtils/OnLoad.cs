using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;
using MIU;


namespace CosmeticUtils
{
    [HarmonyPatch(typeof(PlatformSetup), "GetDevIDs")] // Here before ConsoleUnlocker gets ported
    internal class DevIdPatches
    {
        public static void Postfix()
        {
            FieldInfo DevsField = typeof(PlatformSetup).GetField("Devs", BindingFlags.NonPublic | BindingFlags.Static);
            if (DevsField == null) return;
            List<DevUser> Devs = DevsField.GetValue(null) as List<DevUser>;
            DevUser me = new DevUser($"{{\"UserID\": \"{Player.Current.Network.GetNetworkId()}\", \"Flags\": 31}}");
            MonoBehaviour.print($"Me (DevUser) | IsDev: {me.HasFeature(1)} | UnlockAll:  {me.HasFeature(2)} | MultiplayerFlag: {me.HasFeature(4)} | CommandLineAccess: {me.HasFeature(8)} | FPSDisplay: {me.HasFeature(16)}");
            Devs.Add(me);
            DevsField.SetValue(null, Devs);
            GlobalContext.Invoke<DevModeActivated>(Array.Empty<object>());
            MIU.Console.Instance.gameObject.SetActive(true);
        }
    }

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
