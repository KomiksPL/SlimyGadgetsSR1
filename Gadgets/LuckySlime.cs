using System;
using System.Collections.Generic;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
	internal class LuckySlime
	{
		public static void BuildAlternative()
		{
			Color white = Color.white;
			Identifiable.Id id;
			if (Enum.TryParse("LUCKY_PLORT", out id))
			{
				ScienceUtils.CreateTeleporter(Enums.ModdedEnum.TELEPORTER_WHITE, "White", white, ScienceUtils.CreateTeleporterCraftCosts(id, Identifiable.Id.STRANGE_DIAMOND_CRAFT));
				ScienceUtils.CreateLamp(Enums.ModdedEnum.LAMP_WHITE, "White", Identifiable.Id.LUCKY_SLIME, ScienceUtils.CreateLampCraftCosts(id, Identifiable.Id.STRANGE_DIAMOND_CRAFT));
				ScienceUtils.CreateWarpDepot(Enums.ModdedEnum.WARP_DEPOT_WHITE, "White", white, ScienceUtils.CreateWarpDepotCraftCosts(id, Identifiable.Id.STRANGE_DIAMOND_CRAFT));
				SRCallbacks.PreSaveGameLoad += delegate(SceneContext context)
				{
					List<Gadget.Id> list = new List<Gadget.Id>
					{
						Enums.ModdedEnum.TELEPORTER_WHITE,
						Enums.ModdedEnum.LAMP_WHITE,
						Enums.ModdedEnum.WARP_DEPOT_WHITE
					};
					GameObject gameObject = ScienceUtils.CreateTreasurePod(list, GameObject.Find("zoneRANCH/cellRanch_Docks/Sector/Loot").transform, "WhiteGadget");
					gameObject.transform.localPosition = new Vector3(-144.4278f, 7.1223f, -273.8121f);
					gameObject.transform.position = new Vector3(-144.4278f, 7.1223f, -273.8121f);
				};
			}
		}
	}
}
