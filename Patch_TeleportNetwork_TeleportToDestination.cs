using System;
using System.Collections.Generic;
using HarmonyLib;

namespace SlimyGadgets
{
	[HarmonyPatch(typeof(TeleportNetwork), "TeleportToDestination", new Type[]
	{
		typeof(TeleportablePlayer),
		typeof(TeleportSource),
		typeof(TeleportDestination)
	})]
	public class Patch_TeleportNetwork_TeleportToDestination
	{
		public static bool Prefix(TeleportNetwork __instance, TeleportablePlayer toTeleport, TeleportSource source, TeleportDestination destination)
		{
			Gadget component = source.transform.parent.GetComponent<Gadget>();
			bool flag = component == null;
			bool flag2;
			if (flag)
			{
				flag2 = true;
			}
			else
			{
				bool flag3 = Enums.ModdedEnum.TELEPORTER_BLACK > Gadget.Id.NONE;
				if (flag3)
				{
					bool flag4 = component.id == Enums.ModdedEnum.TELEPORTER_BLACK;
					if (flag4)
					{
						source.OnDepart();
						destination.OnDepart();
						bool flag5 = SRSingleton<SceneContext>.Instance.Player.GetInterfaceComponent<Damageable>().Damage(50, __instance.gameObject);
						if (flag5)
						{
							DeathHandler.Kill(SRSingleton<SceneContext>.Instance.Player, DeathHandler.Source.SLIME_ATTACK, __instance.gameObject, "TeleportNetwork.TeleportToDestination");
						}
						destination.OnArrive();
					}
				}
				bool flag6 = component.id == Enums.Gadgets.TELEPORTER_QUESTION;
				if (flag6)
				{
					List<TeleportDestination> list = new List<TeleportDestination>();
					foreach (TeleportNetwork.Destination destination2 in __instance.destinationLookup.Values)
					{
						foreach (TeleportDestination teleportDestination in destination2.exits)
						{
							list.Add(teleportDestination);
						}
					}
					list.RemoveAll((TeleportDestination x) => !x.IsLinkActive());
					list.RemoveAll(delegate(TeleportDestination x)
					{
						TeleportSource component2 = x.GetComponent<TeleportSource>();
						bool flag8 = component2 != null && !component2.activated;
						bool flag9;
						if (flag8)
						{
							flag9 = true;
						}
						else
						{
							bool flag10 = component2 == null;
							flag9 = flag10;
						}
						return flag9;
					});
					TeleportDestination teleportDestination2 = list.RandomObject<TeleportDestination>();
					bool flag7 = teleportDestination2 != null;
					if (flag7)
					{
						toTeleport.TeleportTo(teleportDestination2.GetPosition(), teleportDestination2.regionSetId, teleportDestination2.GetEulerAngles(), true, true);
						teleportDestination2.OnArrive();
					}
					flag2 = false;
				}
				else
				{
					flag2 = true;
				}
			}
			return flag2;
		}
	}
}
