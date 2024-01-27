using System;
using System.Collections.Generic;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
	internal class DervishSlime
	{
		public static void Build()
		{
			Color color = EntryPoint.FromHex("9f89d9");
			ScienceUtils.CreateTeleporter(Enums.Gadgets.TELEPORTER_LAVENDER, "Lavender", color, ScienceUtils.CreateTeleporterCraftCosts(Identifiable.Id.DERVISH_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));
			ScienceUtils.CreateLamp(Enums.Gadgets.LAMP_LAVENDER, "Lavender", Identifiable.Id.DERVISH_SLIME, ScienceUtils.CreateLampCraftCosts(Identifiable.Id.DERVISH_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));
			ScienceUtils.CreateWarpDepot(Enums.Gadgets.WARP_DEPOT_LAVENDER, "Lavender", color, ScienceUtils.CreateWarpDepotCraftCosts(Identifiable.Id.DERVISH_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));
			SRCallbacks.PreSaveGameLoad += delegate(SceneContext context)
			{
				List<Gadget.Id> list = new List<Gadget.Id>
				{
					Enums.Gadgets.TELEPORTER_LAVENDER,
					Enums.Gadgets.LAMP_LAVENDER,
					Enums.Gadgets.WARP_DEPOT_LAVENDER
				};
				GameObject gameObject = ScienceUtils.CreateTreasurePod(list, GameObject.Find("zoneDESERT/cellDesert_ScorchedPlainsNorthEast/Sector/Loot").transform, "LavenderGadget");
				gameObject.transform.localPosition = new Vector3(29.66675f, 1050.924f, 601.9589f);
				gameObject.transform.position = new Vector3(29.66675f, 1050.924f, 601.9589f);
			};
		}
	}
}
