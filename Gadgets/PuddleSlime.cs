using System;
using System.Collections.Generic;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
	internal class PuddleSlime
	{
		public static void Build()
		{
			Color color = EntryPoint.FromHex("1475c3");
			ScienceUtils.CreateTeleporter(Enums.Gadgets.TELEPORTER_AQUA, "Aqua", color, ScienceUtils.CreateTeleporterCraftCosts(Identifiable.Id.PUDDLE_PLORT, Identifiable.Id.DEEP_BRINE_CRAFT));
			GameObject gameObject = ScienceUtils.CreateLamp(Enums.Gadgets.LAMP_AQUA, "Aqua", Identifiable.Id.PUDDLE_SLIME, ScienceUtils.CreateLampCraftCosts(Identifiable.Id.PUDDLE_PLORT, Identifiable.Id.DEEP_BRINE_CRAFT));
			ScienceUtils.CreateWarpDepot(Enums.Gadgets.WARP_DEPOT_AQUA, "Aqua", color, ScienceUtils.CreateWarpDepotCraftCosts(Identifiable.Id.PUDDLE_PLORT, Identifiable.Id.DEEP_BRINE_CRAFT));
			Material[] sharedMaterials = gameObject.transform.Find("slimeslime").GetComponent<SkinnedMeshRenderer>().sharedMaterials;
			SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME);
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				bool flag = sharedMaterials[i].name == "mouthElated";
				if (flag)
				{
					sharedMaterials[i] = slimeByIdentifiableId.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
				}
			}
			List<Material> list = new List<Material>();
			foreach (Material material in sharedMaterials)
			{
				list.Add(material);
			}
			gameObject.transform.Find("slimeslime").GetComponent<SkinnedMeshRenderer>().sharedMaterials = list.ToArray();
			SRCallbacks.PreSaveGameLoad += delegate(SceneContext context)
			{
				List<Gadget.Id> list2 = new List<Gadget.Id>
				{
					Enums.Gadgets.TELEPORTER_AQUA,
					Enums.Gadgets.LAMP_AQUA,
					Enums.Gadgets.WARP_DEPOT_AQUA
				};
				GameObject gameObject2 = ScienceUtils.CreateTreasurePod(list2, GameObject.Find("zoneQUARRY/cellQuarry_OverUnder/Sector/Loot").transform, "AquaGadget");
				gameObject2.transform.localPosition = new Vector3(214.6122f, -3.049502f, 324.9118f);
				gameObject2.transform.position = new Vector3(214.6122f, -3.049502f, 324.9118f);
			};
		}
	}
}
