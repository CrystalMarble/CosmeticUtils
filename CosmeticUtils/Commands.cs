using MIU;
using UnityEngine;

namespace CosmeticUtils
{
    internal class Commands
    {
        [ConsoleCommand(null, null, null, false, false, description = "Search for a cosmetic and return its info")]
        public static string searchCosmetic(params string[] name)
        {
            if (name.Length == 0) return "Please specify a falue for parameter 'name'";
            foreach (var k in CosmeticManager.instance.cosmetics.Skins)
            {
                if (k.name.ToLower().Contains(name[0].ToLower())) MonoBehaviour.print($"{k.name} ({k.Id}) - skin");
            }
            foreach (var k in CosmeticManager.instance.cosmetics.Trails)
            {
                if (k.name.ToLower().Contains(name[0].ToLower())) MonoBehaviour.print($"{k.name} ({k.Id}) - trail");
            }
            foreach (var k in CosmeticManager.instance.cosmetics.Hats)
            {
                if (k.name.ToLower().Contains(name[0].ToLower())) MonoBehaviour.print($"{k.name} ({k.Id}) - hat");
            }
            foreach (var k in CosmeticManager.instance.cosmetics.Respawns)
            {
                if (k.name.ToLower().Contains(name[0].ToLower())) MonoBehaviour.print($"{k.name} ({k.Id}) - respawn effect");
            }
            foreach (var k in CosmeticManager.instance.cosmetics.Blasts)
            {
                if (k.name.ToLower().Contains(name[0].ToLower())) MonoBehaviour.print($"{k.name} ({k.Id}) - blast");
            }
            return "";
        }

        [ConsoleCommand(null, null, null, false, false, description = "Search for a cosmetic and return its info")]
        public static string getCosmetics(params string[] type)
        {
            if (type.Length == 0) return "Please specify a falue for parameter 'type'";
            Cosmetic[] cosmetics = null;
            switch (type[0])
            {
                case "marbles":
                    {
                        cosmetics = CosmeticManager.instance.cosmetics.Skins; break;
                    }
                case "trails":
                    {
                        cosmetics = CosmeticManager.instance.cosmetics.Trails; break;
                    }
                case "hats":
                    {
                        cosmetics = CosmeticManager.instance.cosmetics.Hats; break;
                    }
                case "respawns":
                    {
                        cosmetics = CosmeticManager.instance.cosmetics.Respawns; break;
                    }
                case "blasts":
                    {
                        cosmetics = CosmeticManager.instance.cosmetics.Blasts; break;
                    }
                default: return "Value for parameter 'type' is incorrect. Choices: [marbles/trails/hats/respawns/blasts]";
            }
            foreach (var k in cosmetics)
            {
                MonoBehaviour.print($"{k.name} ({k.Id})");
            }
            return "";
        }
    }
}
