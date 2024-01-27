using System;
using System.Collections.Generic;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
	internal class TangleSlime
	{
		public static void Build()
		{
			Color color = EntryPoint.FromHex("3eb489");
			ScienceUtils.CreateTeleporter(Enums.Gadgets.TELEPORTER_TEAL, "Teal", color, ScienceUtils.CreateTeleporterCraftCosts(Identifiable.Id.TANGLE_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));
			ScienceUtils.CreateLamp(Enums.Gadgets.LAMP_TEAL, "Teal", Identifiable.Id.TANGLE_SLIME, ScienceUtils.CreateLampCraftCosts(Identifiable.Id.TANGLE_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));
			ScienceUtils.CreateWarpDepot(Enums.Gadgets.WARP_DEPOT_TEAL, "Teal", color, ScienceUtils.CreateWarpDepotCraftCosts(Identifiable.Id.TANGLE_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));
			SRCallbacks.PreSaveGameLoad += delegate(SceneContext _)
			{
				List<Gadget.Id> list = new List<Gadget.Id>
				{
					Enums.Gadgets.TELEPORTER_TEAL,
					Enums.Gadgets.LAMP_TEAL,
					Enums.Gadgets.WARP_DEPOT_TEAL
				};
				GameObject gameObject = ScienceUtils.CreateTreasurePod(list, GameObject.Find("zoneDESERT/cellDesert_WaystationTempleEndOutside/Sector/Loot").transform, "TealGadget");
				gameObject.transform.localPosition = new Vector3(143.9354f, 1074.97f, 837.6512f);
				gameObject.transform.position = new Vector3(143.9354f, 1074.97f, 837.6512f);
			};
		}
	}
}
