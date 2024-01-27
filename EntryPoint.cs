using System;
using System.Collections.Generic;
using System.Reflection;
using SlimyGadgets.Gadgets;
using SRML;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets
{
	internal class EntryPoint : ModEntryPoint
	{
		public override void PreLoad()
		{
			base.HarmonyInstance.PatchAll(EntryPoint.execAssembly);
			Enums.ModdedEnum.LAMP_BLACK = GadgetRegistry.CreateGadgetId(EnumPatcher.GetFirstFreeValue(typeof(Gadget.Id)), "LAMP_BLACK");
			Enums.ModdedEnum.WARP_DEPOT_BLACK = GadgetRegistry.CreateGadgetId(EnumPatcher.GetFirstFreeValue(typeof(Gadget.Id)), "WARP_DEPOT_BLACK");
			Enums.ModdedEnum.TELEPORTER_BLACK = GadgetRegistry.CreateGadgetId(EnumPatcher.GetFirstFreeValue(typeof(Gadget.Id)), "TELEPORTER_BLACK");
			if (SRModLoader.IsModPresent("dogeiscutluckyplorts"))
			{
				Enums.ModdedEnum.LAMP_WHITE = GadgetRegistry.CreateGadgetId(EnumPatcher.GetFirstFreeValue(typeof(Gadget.Id)), "LAMP_WHITE");
				Enums.ModdedEnum.WARP_DEPOT_WHITE = GadgetRegistry.CreateGadgetId(EnumPatcher.GetFirstFreeValue(typeof(Gadget.Id)), "WARP_DEPOT_WHITE");
				Enums.ModdedEnum.TELEPORTER_WHITE = GadgetRegistry.CreateGadgetId(EnumPatcher.GetFirstFreeValue(typeof(Gadget.Id)), "TELEPORTER_WHITE");
			}
		}

		public override void Load()
		{
			Type[] types = EntryPoint.execAssembly.GetTypes();
			foreach (Type type in types)
			{
				bool flag = type.Namespace != null && type.Namespace.Contains("Gadgets");
				if (flag)
				{
					MethodInfo method = type.GetMethod("Build");
					if (method != null)
					{
						method.Invoke(null, Array.Empty<object>());
					}
				}
			}
			bool flag2 = SRModLoader.IsModPresent("tarrrancher");
			if (flag2)
			{
				TarrSlime.BuildAlternative();
			}
			bool flag3 = SRModLoader.IsModPresent("dogeiscutluckyplorts");
			if (flag3)
			{
				LuckySlime.BuildAlternative();
			}
		}

		internal static Color FromHex(string hex)
		{
			ColorUtility.TryParseHtmlString("#" + hex.ToUpper(), out var color);
			return color;
		}

		internal static Dictionary<TreasurePod, List<Gadget.Id>> gadgetIds = new Dictionary<TreasurePod, List<Gadget.Id>>();

		public static Assembly execAssembly = Assembly.GetExecutingAssembly();
	}
}
