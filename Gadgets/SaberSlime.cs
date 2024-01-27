using System;
using System.Collections.Generic;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
	internal class SaberSlime
	{
		public static void Build()
		{
			Color color = EntryPoint.FromHex("D2B48C");
			ScienceUtils.CreateTeleporter(Enums.Gadgets.TELEPORTER_TAN, "Tan", color, ScienceUtils.CreateTeleporterCraftCosts(Identifiable.Id.SABER_PLORT, Identifiable.Id.SLIME_FOSSIL_CRAFT));
			ScienceUtils.CreateLamp(Enums.Gadgets.LAMP_TAN, "Tan", Identifiable.Id.SABER_SLIME, ScienceUtils.CreateLampCraftCosts(Identifiable.Id.SABER_PLORT, Identifiable.Id.SLIME_FOSSIL_CRAFT));
			ScienceUtils.CreateWarpDepot(Enums.Gadgets.WARP_DEPOT_TAN, "Tan", color, ScienceUtils.CreateWarpDepotCraftCosts(Identifiable.Id.SABER_PLORT, Identifiable.Id.SLIME_FOSSIL_CRAFT));
			SRCallbacks.PreSaveGameLoad += delegate
			{
				List<Gadget.Id> list = new List<Gadget.Id>
				{
					Enums.Gadgets.TELEPORTER_TAN,
					Enums.Gadgets.LAMP_TAN,
					Enums.Gadgets.WARP_DEPOT_TAN
				};
				GameObject gameObject = ScienceUtils.CreateTreasurePod(list, GameObject.Find("zoneOGDEN/cellWilds_OgdensOutpost/Sector/Loot").transform, "TanGadget");
				gameObject.transform.localPosition = new Vector3(866.5602f, 3.6177f, 494.175f);
				gameObject.transform.position = new Vector3(866.5602f, 3.6177f, 494.175f);
				Quaternion localRotation = gameObject.transform.localRotation;
				localRotation.eulerAngles = new Vector3(0f, 0f, 348.6929f);
				gameObject.transform.localRotation = localRotation;
			};
		}
	}
}
