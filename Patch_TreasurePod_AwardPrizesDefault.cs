using System;
using System.Collections.Generic;
using HarmonyLib;

namespace SlimyGadgets
{
	[HarmonyPatch(typeof(TreasurePod), "AwardPrizesDefault")]
	public class Patch_TreasurePod_AwardPrizesDefault
	{
		public static void Prefix(TreasurePod __instance)
		{
			bool flag = __instance.blueprint == Gadget.Id.NONE;
			if (flag)
			{
				List<Gadget.Id> list;
				bool flag2 = EntryPoint.gadgetIds.TryGetValue(__instance, out list);
				if (flag2)
				{
					foreach (Gadget.Id id in list)
					{
						__instance.gadgetDir.AddBlueprint(id);
						SRSingleton<SceneContext>.Instance.PopupDirector.QueueForPopup(new TreasurePod.BlueprintPopupCreator(id));
						SRSingleton<SceneContext>.Instance.PopupDirector.MaybePopupNext();
					}
				}
			}
		}
	}
}
