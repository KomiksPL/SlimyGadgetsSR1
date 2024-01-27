using System;
using System.Collections.Generic;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
	internal class MosaicSlime
	{
		public static void Build()
		{
			Color color = EntryPoint.FromHex("008080");
			ScienceUtils.CreateTeleporter(Enums.Gadgets.TELEPORTER_MINT, "Mint", color, ScienceUtils.CreateTeleporterCraftCosts(Identifiable.Id.MOSAIC_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));
			ScienceUtils.CreateLamp(Enums.Gadgets.LAMP_MINT, "Mint", Identifiable.Id.MOSAIC_SLIME, ScienceUtils.CreateLampCraftCosts(Identifiable.Id.MOSAIC_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));
			ScienceUtils.CreateWarpDepot(Enums.Gadgets.WARP_DEPOT_MINT, "Mint", color, ScienceUtils.CreateWarpDepotCraftCosts(Identifiable.Id.MOSAIC_PLORT, Identifiable.Id.GLASS_SHARD_CRAFT));
			SRCallbacks.PreSaveGameLoad += delegate(SceneContext _)
			{
				List<Gadget.Id> list = new List<Gadget.Id>
				{
					Enums.Gadgets.TELEPORTER_MINT,
					Enums.Gadgets.LAMP_MINT,
					Enums.Gadgets.WARP_DEPOT_MINT
				};
				GameObject gameObject = ScienceUtils.CreateTreasurePod(list, GameObject.Find("zoneDESERT/cellDesert_MountainPass/Sector/Loot").transform, "MintGadget");
				gameObject.transform.localPosition = new Vector3(-53.51623f, 1049.807f, 292.4369f);
				gameObject.transform.position = new Vector3(-53.51623f, 1049.807f, 292.4369f);
			};
		}
	}
}
