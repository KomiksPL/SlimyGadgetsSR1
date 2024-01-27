using System;
using System.Collections.Generic;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
	internal class TarrSlime
	{
		public static void BuildAlternative()
		{
			Color black = Color.black;
			if (Enum.TryParse<Identifiable.Id>("TARR_PLORT", out var id))
			{
				ScienceUtils.CreateTeleporter(Enums.ModdedEnum.TELEPORTER_BLACK, "Black", black, ScienceUtils.CreateTeleporterCraftCosts(id, Identifiable.Id.SLIME_FOSSIL_CRAFT));
				ScienceUtils.CreateLamp(Enums.ModdedEnum.LAMP_BLACK, "Black", Identifiable.Id.TARR_SLIME, ScienceUtils.CreateLampCraftCosts(id, Identifiable.Id.SLIME_FOSSIL_CRAFT));
				GadgetDefinition.CraftCost[] array = new GadgetDefinition.CraftCost[]
				{
					new GadgetDefinition.CraftCost
					{
						id = id,
						amount = 1
					},
					new GadgetDefinition.CraftCost
					{
						id = Identifiable.Id.SLIME_FOSSIL_CRAFT,
						amount = 9
					},
					new GadgetDefinition.CraftCost
					{
						id = Identifiable.Id.LAVA_DUST_CRAFT,
						amount = 1
					}
				};
				ScienceUtils.CreateWarpDepot(Enums.ModdedEnum.WARP_DEPOT_BLACK, "Black", black, array);
				SRCallbacks.PreSaveGameLoad += delegate(SceneContext context)
				{
					List<Gadget.Id> list = new List<Gadget.Id>
					{
						Enums.ModdedEnum.TELEPORTER_BLACK,
						Enums.ModdedEnum.LAMP_BLACK,
						Enums.ModdedEnum.WARP_DEPOT_BLACK
					};
					GameObject gameObject = ScienceUtils.CreateTreasurePod(list, GameObject.Find("zoneRANCH/cellRanch_Lab/Sector/Loot").transform, "BlackGadget");
					gameObject.transform.localPosition = new Vector3(198.7028f, 14.48735f, -328.961f);
					gameObject.transform.position = new Vector3(198.7028f, 14.48735f, -328.961f);
				};
			}
		}
	}
}
