using MIU;
using UnityEngine;
using CosmeticUtils.Libs;

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

        [ConsoleCommand(null, null, null, false, false, description = "Get all cosmetics of a given type")]
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

        [ConsoleCommand(null, null, null, false, false, description = "Change your cosmetics to a given ID")]
        public static string forceCosmetic(params string[] args)
        {
            CosmeticReturnType c = CosmeticLib.GetCosmeticById(args[0]);
            if (c == null) return "Cosmetic not found!";
            CosmeticLib.ApplyCosmetic(c.type, c.cosmetic);
            switch (c.type)
            {
                case CosmeticType.Skin:
                    return "Applied cosmetic " + c.cosmetic.name + " (skin)";

                case CosmeticType.Trail:
                    return "Applied cosmetic " + c.cosmetic.name + " (trail)";

                case CosmeticType.Hat:
                    return "Applied cosmetic " + c.cosmetic.name + " (hat)";

                case CosmeticType.Blast:
                    return "Applied cosmetic " + c.cosmetic.name + " (blast)";

                case CosmeticType.Respawn:
                    return "Applied cosmetic " + c.cosmetic.name + " (respawn)";

                default:
                    return "Unknown cosmetic type!";
            }
        }

        [ConsoleCommand(null, null, null, false, false)]
        public static string hiddencosmetics()
        {
            var cosmetics = CosmeticManager.instance.cosmetics.AllCosmetics;

            foreach (var cosmetic in cosmetics)
            {
                if (cosmetic.hidden)
                    MonoBehaviour.print($"{cosmetic.name} ({cosmetic.Id}) | {(cosmetic.hidden ? "hidden" : "shown")} | {(cosmetic.clientUnlockable ? "client unlockable" : "client not unlockable")}");
            }
            return "";
        }
    }


}
