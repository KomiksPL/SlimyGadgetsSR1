using System;
using System.Collections.Generic;
using SRML;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
	internal class QuicksilverSlime
	{
		public static void Build()
		{
			Identifiable.Id id = Identifiable.Id.FIRE_PLORT;
			bool flag = SRModLoader.IsModPresent("frostys_quicksilver_rancher");
			if (flag)
			{
				id = Identifiable.Id.QUICKSILVER_PLORT;
			}
			Color color = new Color(0.541f, 0.667f, 0.663f, 1f);
			ScienceUtils.CreateTeleporter(Enums.Gadgets.TELEPORTER_SILVER, "Silver", color, ScienceUtils.CreateTeleporterCraftCosts(id, Identifiable.Id.DEEP_BRINE_CRAFT));
			ScienceUtils.CreateLamp(Enums.Gadgets.LAMP_SILVER, "Silver", Identifiable.Id.QUICKSILVER_SLIME, ScienceUtils.CreateLampCraftCosts(id, Identifiable.Id.DEEP_BRINE_CRAFT));
			ScienceUtils.CreateWarpDepot(Enums.Gadgets.WARP_DEPOT_SILVER, "Silver", color, ScienceUtils.CreateWarpDepotCraftCosts(id, Identifiable.Id.DEEP_BRINE_CRAFT));
			SRCallbacks.PreSaveGameLoad += delegate(SceneContext context)
			{
				List<Gadget.Id> list = new List<Gadget.Id>
				{
					Enums.Gadgets.TELEPORTER_SILVER,
					Enums.Gadgets.LAMP_SILVER,
					Enums.Gadgets.WARP_DEPOT_SILVER
				};
				GameObject gameObject = ScienceUtils.CreateTreasurePod(list, GameObject.Find("zoneMOCHI/cellVALLEY_MochiEstate/Sector/Loot").transform, "SilverGadget");
				gameObject.transform.localPosition = new Vector3(205.4857f, 8.2935f, -961.6078f);
				gameObject.transform.position = new Vector3(205.4857f, 8.2935f, -961.6078f);
			};
		}
	}
}
