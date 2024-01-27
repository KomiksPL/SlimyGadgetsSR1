using System;
using System.Collections.Generic;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
    internal class FireSlime
    {
        public static void Build()
        {
            Color color = EntryPoint.FromHex("ff771a");
            ScienceUtils.CreateTeleporter(Enums.Gadgets.TELEPORTER_ORANGE, "Orange", color, ScienceUtils.CreateTeleporterCraftCosts(Identifiable.Id.FIRE_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));

            GameObject lampGameObject = ScienceUtils.CreateLamp(Enums.Gadgets.LAMP_ORANGE, "Orange", Identifiable.Id.FIRE_SLIME, ScienceUtils.CreateLampCraftCosts(Identifiable.Id.FIRE_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));

            ScienceUtils.CreateWarpDepot(Enums.Gadgets.WARP_DEPOT_ORANGE, "Orange", color, ScienceUtils.CreateWarpDepotCraftCosts(Identifiable.Id.FIRE_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));

            Material[] lampMaterials = lampGameObject.transform.Find("slimeslime").GetComponent<SkinnedMeshRenderer>().sharedMaterials;
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.FIRE_SLIME);

            for (int i = 0; i < lampMaterials.Length; i++)
            {
                if (lampMaterials[i].name == "mouthElated")
                {
                    lampMaterials[i] = slimeByIdentifiableId.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
                }
            }

            List<Material> lampMaterialList = new List<Material>();
            foreach (var t in lampMaterials)
            {
                lampMaterialList.Add(t);
            }
            lampGameObject.transform.Find("slimeslime").GetComponent<SkinnedMeshRenderer>().sharedMaterials = lampMaterialList.ToArray();

            SRCallbacks.PreSaveGameLoad += delegate (SceneContext context)
            {
                List<Gadget.Id> gadgetIds = new List<Gadget.Id>
                {
                    Enums.Gadgets.TELEPORTER_ORANGE,
                    Enums.Gadgets.LAMP_ORANGE,
                    Enums.Gadgets.WARP_DEPOT_ORANGE
                };

                GameObject treasurePodGameObject = ScienceUtils.CreateTreasurePod(gadgetIds, GameObject.Find("zoneDESERT/cellDesert_HobsonEndTemple/Sector/Loot").transform, "OrangeGadget");
                treasurePodGameObject.transform.localPosition = new Vector3(47.7092f, 1020.16f, -187.7798f);
                treasurePodGameObject.transform.position = new Vector3(47.7092f, 1020.16f, -187.7798f);

                CapsuleCollider component = GameObject.Find("zoneDESERT/cellDesert_HobsonEndTemple/Sector/Constructs/fillerRuinTubeDry03/Tube").GetComponent<CapsuleCollider>();
                component.radius = 0.75f;
                component.height = 6.15566f;
            };
        }
    }
}
