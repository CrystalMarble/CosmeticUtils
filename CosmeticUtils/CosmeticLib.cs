using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CosmeticUtils.Libs
{
    public class CosmeticReturnType
    {
        public CosmeticType type;
        public Cosmetic cosmetic;
    }

    public class CosmeticLib
    {
        public static void ApplyCosmetic(CosmeticType type, Cosmetic cosmetic)
        {
            ApplyMarbleCosmetics.Configuration config;
            switch (type)
            {
                case CosmeticType.Skin:
                    {
                        CosmeticPanel.SetCosmetic(cosmetic, type);
                        config = new ApplyMarbleCosmetics.Configuration()
                        {
                            Blast = CosmeticManager.MyBlast,
                            Hat = CosmeticManager.MyHat,
                            Respawn = CosmeticManager.MyRespawn,
                            Skin = cosmetic,
                            Trail = CosmeticManager.MyTrail,
                        };
                        GlobalContext.Invoke<ApplyMarbleCosmetics>(config);
                        break;
                    }
                case CosmeticType.Trail:
                    {
                        CosmeticPanel.SetCosmetic(cosmetic, type);
                        config = new ApplyMarbleCosmetics.Configuration()
                        {
                            Blast = CosmeticManager.MyBlast,
                            Hat = CosmeticManager.MyHat,
                            Respawn = CosmeticManager.MyRespawn,
                            Skin = CosmeticManager.MySkin,
                            Trail = cosmetic,
                        };
                        GlobalContext.Invoke<ApplyMarbleCosmetics>(config);
                        break;
                    }
                case CosmeticType.Hat:
                    {
                        CosmeticPanel.SetCosmetic(cosmetic, type);
                        config = new ApplyMarbleCosmetics.Configuration()
                        {
                            Blast = CosmeticManager.MyBlast,
                            Hat = cosmetic,
                            Respawn = CosmeticManager.MyRespawn,
                            Skin = CosmeticManager.MySkin,
                            Trail = CosmeticManager.MyTrail,
                        };
                        GlobalContext.Invoke<ApplyMarbleCosmetics>(config);
                        break;
                    }
                case CosmeticType.Blast:
                    {
                        CosmeticPanel.SetCosmetic(cosmetic, type);
                        config = new ApplyMarbleCosmetics.Configuration()
                        {
                            Blast = cosmetic,
                            Hat = CosmeticManager.MyHat,
                            Respawn = CosmeticManager.MyRespawn,
                            Skin = CosmeticManager.MySkin,
                            Trail = CosmeticManager.MyTrail,
                        };
                        GlobalContext.Invoke<ApplyMarbleCosmetics>(config);
                        break;
                    }
                case CosmeticType.Respawn:
                    {
                        CosmeticPanel.SetCosmetic(cosmetic, type);
                        config = new ApplyMarbleCosmetics.Configuration()
                        {
                            Blast = CosmeticManager.MyBlast,
                            Hat = CosmeticManager.MyHat,
                            Respawn = cosmetic,
                            Skin = CosmeticManager.MySkin,
                            Trail = CosmeticManager.MyTrail,
                        };
                        GlobalContext.Invoke<ApplyMarbleCosmetics>(config);
                        break;
                    }
            }
        }

        public static CosmeticReturnType GetCosmeticByName(string name)
        {
            // Search in Skins
            foreach (var k in CosmeticManager.instance.cosmetics.Skins)
            {
                if (name == k.name)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Skin };
                }
            }

            // Search in Trails
            foreach (var k in CosmeticManager.instance.cosmetics.Trails)
            {
                if (name == k.name)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Trail };
                }
            }

            // Search in Hats
            foreach (var k in CosmeticManager.instance.cosmetics.Hats)
            {
                if (name == k.name)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Hat };
                }
            }

            // Search in Blasts
            foreach (var k in CosmeticManager.instance.cosmetics.Blasts)
            {
                if (name == k.name)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Blast };
                }
            }

            // Search in Respawns
            foreach (var k in CosmeticManager.instance.cosmetics.Respawns)
            {
                if (name == k.name)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Respawn };
                }
            }

            // Return null if no match is found
            return null;
        }

        public static CosmeticReturnType GetCosmeticById(string id)
        {
            // Search in Skins
            foreach (var k in CosmeticManager.instance.cosmetics.Skins)
            {
                if (id == k.Id)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Skin };
                }
            }

            // Search in Trails
            foreach (var k in CosmeticManager.instance.cosmetics.Trails)
            {
                if (id == k.Id)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Trail };
                }
            }

            // Search in Hats
            foreach (var k in CosmeticManager.instance.cosmetics.Hats)
            {
                if (id == k.Id)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Hat };
                }
            }

            // Search in Blasts
            foreach (var k in CosmeticManager.instance.cosmetics.Blasts)
            {
                if (id == k.Id)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Blast };
                }
            }

            // Search in Respawns
            foreach (var k in CosmeticManager.instance.cosmetics.Respawns)
            {
                if (id == k.Id)
                {
                    return new CosmeticReturnType { cosmetic = k, type = CosmeticType.Respawn };
                }
            }

            // Return null if no match is found
            return null;
        }


    }
}
