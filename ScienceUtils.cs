using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Script.Util.Extensions;
using SRML.SR;
using SRML.SR.SaveSystem;
using SRML.SR.Translation;
using SRML.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SlimyGadgets
{
	public class ScienceUtils
	{
		internal static GameObject CreateTeleporter(Gadget.Id gadgetId, string name, Color color, GadgetDefinition.CraftCost[] craftCosts)
		{
			bool flag = name == "?";
			if (flag)
			{
				name = "Glitch";
			}
			Sprite sprite = Shortcutter.CreateSpriteFromImage("iconGadgetTeleport" + name);
			GadgetDefinition gadgetDefinition = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.TELEPORTER_PINK);
			GameObject gameObject = PrefabUtils.CopyPrefab(gadgetDefinition.prefab);
			gameObject.name = "gadgetTeleport" + name;
			gameObject.GetComponent<Gadget>().id = gadgetId;
			gameObject.GetComponentInChildren<TeleporterGadget>().linkName = "gadgetTeleport" + name + "_linked";
			SkinnedMeshRenderer component = gameObject.transform.Find("model_telepad/mesh_telepad").GetComponent<SkinnedMeshRenderer>();
			Material material = Object.Instantiate<Material>(component.sharedMaterial);
			material.name = "Telepad_" + name;
			material.SetColor(ScienceUtils.Color00, color);
			material.SetColor(ScienceUtils.Color01, color);
			material.SetColor(ScienceUtils.Color20, color);
			material.SetColor(ScienceUtils.Color21, color);
			component.sharedMaterial = material;
			GadgetDefinition gadgetDefinition2 = Shortcutter.CopyGadgetDefinition(gadgetDefinition, gadgetId, sprite, gameObject, craftCosts);
			LookupRegistry.RegisterGadget(gadgetDefinition2);
			Gadget.TELEPORTER_CLASS.Add(gadgetId);
			bool flag2 = name == "Glitch";
			if (flag2)
			{
				name = "?";
			}
			bool flag3 = gadgetId == Enums.Gadgets.TELEPORTER_QUESTION;
			if (flag3)
			{
				gadgetId.GetTranslation().SetNameTranslation(name + " Teleport").SetDescriptionTranslation("A sEt oF TwO TeLePoRTerS tHaT cAn Be UsEd tO CrEAtE YOuR oWn QuICK tRaVeL lInK.");
			}
			else
			{
				gadgetId.GetTranslation().SetNameTranslation(name + " Teleport").SetDescriptionTranslation("A set of two teleporters that can be used to create your own quick travel link.");
			}
			return gameObject;
		}

		public static GameObject CreateTeleporter(Gadget.Id gadgetId, string name, Sprite sprite, Color color, GadgetDefinition.CraftCost[] craftCosts = null, GadgetRegistry.BlueprintLockCreateDelegate unlocker = null)
		{
			bool flag = craftCosts == null;
			if (flag)
			{
				craftCosts = new GadgetDefinition.CraftCost[0];
			}
			bool flag2 = sprite == null;
			if (flag2)
			{
				sprite = Resources.FindObjectsOfTypeAll<Sprite>().First((Sprite x) => x.name == "unknownLarge");
			}
			GadgetDefinition gadgetDefinition = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.TELEPORTER_PINK);
			GameObject gameObject = PrefabUtils.CopyPrefab(gadgetDefinition.prefab);
			gameObject.name = "gadgetTeleport" + name;
			gameObject.GetComponent<Gadget>().id = gadgetId;
			gameObject.GetComponentInChildren<TeleporterGadget>().linkName = "gadgetTeleport" + name + "_linked";
			SkinnedMeshRenderer component = gameObject.transform.Find("model_telepad/mesh_telepad").GetComponent<SkinnedMeshRenderer>();
			Material material = Object.Instantiate<Material>(component.sharedMaterial);
			material.name = "Telepad_" + name;
			material.SetColor(ScienceUtils.Color00, color);
			material.SetColor(ScienceUtils.Color01, color);
			material.SetColor(ScienceUtils.Color20, color);
			material.SetColor(ScienceUtils.Color21, color);
			component.sharedMaterial = material;
			GadgetDefinition gadgetDefinition2 = Shortcutter.CopyGadgetDefinition(gadgetDefinition, gadgetId, sprite, gameObject, craftCosts);
			LookupRegistry.RegisterGadget(gadgetDefinition2);
			gadgetId.GetTranslation().SetNameTranslation(name + " Teleport").SetDescriptionTranslation("A set of two teleporters that can be used to create your own quick travel link.");
			Gadget.TELEPORTER_CLASS.Add(gadgetId);
			bool flag3 = unlocker != null;
			if (flag3)
			{
				GadgetRegistry.RegisterBlueprintLock(gadgetId, unlocker);
			}
			return gameObject;
		}

		internal static GameObject CreateLamp(Gadget.Id gadgetId, string name, Identifiable.Id slimeId, GadgetDefinition.CraftCost[] craftCosts)
		{
			bool flag = name == "?";
			if (flag)
			{
				name = "Glitch";
			}
			Sprite sprite = Shortcutter.CreateSpriteFromImage("iconDecorSlimeLamp" + name);
			GadgetDefinition gadgetDefinition = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.LAMP_RED);
			SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slimeId);
			Material[] defaultMaterials = slimeByIdentifiableId.AppearancesDefault[0].Structures[0].DefaultMaterials;
			SlimeAppearance.Palette palette = SlimeAppearance.Palette.FromMaterial(defaultMaterials[0]);
			GameObject gameObject = PrefabUtils.CopyPrefab(gadgetDefinition.prefab);
			gameObject.name = "decorSlimeLamp" + name;
			gameObject.GetComponent<Gadget>().id = gadgetId;
			SkinnedMeshRenderer component = gameObject.transform.Find("slimeslime").GetComponent<SkinnedMeshRenderer>();
			MeshRenderer component2 = gameObject.transform.Find("glass_inside").GetComponent<MeshRenderer>();
			ParticleSystem component3 = gameObject.transform.Find("Glow").GetComponent<ParticleSystem>();
			Light component4 = gameObject.transform.Find("Point light").GetComponent<Light>();
			Material material = Object.Instantiate<Material>(component.sharedMaterial);
			material.name = "SlimeLamp_body_" + name;
			material.SetColor(ScienceUtils.TopColor, palette.Top);
			material.SetColor(ScienceUtils.MiddleColor, palette.Middle);
			material.SetColor(ScienceUtils.BottomColor, palette.Bottom);
			component.sharedMaterial = defaultMaterials[0];
			component2.sharedMaterial = material;
			var component3Main = component3.main;
			component3Main.startColor = new ParticleSystem.MinMaxGradient(palette.Middle);
			component4.color = palette.Middle;
			GadgetDefinition gadgetDefinition2 = Shortcutter.CopyGadgetDefinition(gadgetDefinition, gadgetId, sprite, gameObject, craftCosts);
			LookupRegistry.RegisterGadget(gadgetDefinition2);
			Gadget.LAMP_CLASS.Add(gadgetId);
			bool flag2 = name == "Glitch";
			if (flag2)
			{
				name = "?";
			}
			gadgetId.GetTranslation().SetNameTranslation(name + " Slime Lamp").SetDescriptionTranslation("A decorative lamp housing a happy slime.");
			return gameObject;
		}

		public static GameObject CreateLamp(Gadget.Id gadgetId, string name, Sprite sprite, Identifiable.Id slimeId, GadgetDefinition.CraftCost[] craftCosts = null, GadgetRegistry.BlueprintLockCreateDelegate unlocker = null)
		{
			bool flag = craftCosts == null;
			if (flag)
			{
				craftCosts = new GadgetDefinition.CraftCost[0];
			}
			bool flag2 = sprite == null;
			if (flag2)
			{
				sprite = Resources.FindObjectsOfTypeAll<Sprite>().First((Sprite x) => x.name == "unknownLarge");
			}
			GadgetDefinition gadgetDefinition = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.LAMP_RED);
			SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(slimeId);
			Material[] defaultMaterials = slimeByIdentifiableId.AppearancesDefault[0].Structures[0].DefaultMaterials;
			SlimeAppearance.Palette palette = SlimeAppearance.Palette.FromMaterial(defaultMaterials[0]);
			GameObject gameObject = PrefabUtils.CopyPrefab(gadgetDefinition.prefab);
			gameObject.name = "decorSlimeLamp" + name;
			gameObject.GetComponent<Gadget>().id = gadgetId;
			SkinnedMeshRenderer component = gameObject.transform.Find("slimeslime").GetComponent<SkinnedMeshRenderer>();
			MeshRenderer component2 = gameObject.transform.Find("glass_inside").GetComponent<MeshRenderer>();
			Material material = Object.Instantiate<Material>(component.sharedMaterial);
			material.name = "SlimeLamp_body_" + name;
			material.SetColor(ScienceUtils.TopColor, palette.Top);
			material.SetColor(ScienceUtils.MiddleColor, palette.Middle);
			material.SetColor(ScienceUtils.BottomColor, palette.Bottom);
			component.sharedMaterial = defaultMaterials[0];
			component2.sharedMaterial = material;
			GadgetDefinition gadgetDefinition2 = Shortcutter.CopyGadgetDefinition(gadgetDefinition, gadgetId, sprite, gameObject, craftCosts);
			LookupRegistry.RegisterGadget(gadgetDefinition2);
			gadgetId.GetTranslation().SetNameTranslation(name + " Slime Lamp").SetDescriptionTranslation("A decorative lamp housing a happy slime.");
			Gadget.LAMP_CLASS.Add(gadgetId);
			bool flag3 = unlocker != null;
			if (flag3)
			{
				GadgetRegistry.RegisterBlueprintLock(gadgetId, unlocker);
			}
			return gameObject;
		}

		internal static GameObject CreateWarpDepot(Gadget.Id gadgetId, string name, Color color, GadgetDefinition.CraftCost[] craftCosts)
		{
			bool flag = name == "?";
			if (flag)
			{
				name = "Glitch";
			}
			Sprite sprite = Shortcutter.CreateSpriteFromImage("iconGadgetWarpDepot" + name);
			GadgetDefinition gadgetDefinition = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.WARP_DEPOT_RED);
			GameObject gameObject = PrefabUtils.CopyPrefab(gadgetDefinition.prefab);
			gameObject.name = "gadgetWarpDepot" + name;
			gameObject.GetComponent<Gadget>().id = gadgetId;
			MeshRenderer component = gameObject.transform.Find("warpdepot").GetComponent<MeshRenderer>();
			Material material = Object.Instantiate<Material>(component.sharedMaterial);
			material.name = "WarpDepot_" + name;
			material.SetColor(ScienceUtils.Color11, color);
			material.SetColor(ScienceUtils.Color20, color);
			material.SetColor(ScienceUtils.Color21, color);
			material.SetColor(ScienceUtils.Color30, color);
			material.SetColor(ScienceUtils.Color31, color);
			component.sharedMaterial = material;
			GadgetDefinition gadgetDefinition2 = Shortcutter.CopyGadgetDefinition(gadgetDefinition, gadgetId, sprite, gameObject, craftCosts);
			LookupRegistry.RegisterGadget(gadgetDefinition2);
			Gadget.WARP_DEPOT_CLASS.Add(gadgetId);
			bool flag2 = name == "Glitch";
			if (flag2)
			{
				name = "?";
			}
			gadgetId.GetTranslation().SetNameTranslation(name + " Warp Depot").SetDescriptionTranslation("A set of two gadgets that allow you to remotely transfer resources between two points.");
			return gameObject;
		}

		public static GameObject CreateWarpDepot(Gadget.Id gadgetId, string name, Sprite sprite, Color color, GadgetDefinition.CraftCost[] craftCosts = null, GadgetRegistry.BlueprintLockCreateDelegate unlocker = null)
		{
			bool flag = craftCosts == null;
			if (flag)
			{
				craftCosts = new GadgetDefinition.CraftCost[0];
			}
			bool flag2 = sprite == null;
			if (flag2)
			{
				sprite = Resources.FindObjectsOfTypeAll<Sprite>().First((Sprite x) => x.name == "unknownLarge");
			}
			GadgetDefinition gadgetDefinition = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.WARP_DEPOT_RED);
			GameObject gameObject = PrefabUtils.CopyPrefab(gadgetDefinition.prefab);
			gameObject.name = "gadgetWarpDepot" + name;
			gameObject.GetComponent<Gadget>().id = gadgetId;
			MeshRenderer component = gameObject.transform.Find("warpdepot").GetComponent<MeshRenderer>();
			Material material = Object.Instantiate<Material>(component.sharedMaterial);
			material.name = "WarpDepot_" + name;
			material.SetColor(ScienceUtils.Color11, color);
			material.SetColor(ScienceUtils.Color20, color);
			material.SetColor(ScienceUtils.Color21, color);
			material.SetColor(ScienceUtils.Color30, color);
			material.SetColor(ScienceUtils.Color31, color);
			component.sharedMaterial = material;
			GadgetDefinition gadgetDefinition2 = Shortcutter.CopyGadgetDefinition(gadgetDefinition, gadgetId, sprite, gameObject, craftCosts);
			LookupRegistry.RegisterGadget(gadgetDefinition2);
			gadgetId.GetTranslation().SetNameTranslation(name + " Warp Depot").SetDescriptionTranslation("A set of two gadgets that allow you to remotely transfer resources between two points.");
			Gadget.WARP_DEPOT_CLASS.Add(gadgetId);
			bool flag3 = unlocker != null;
			if (flag3)
			{
				GadgetRegistry.RegisterBlueprintLock(gadgetId, unlocker);
			}
			return gameObject;
		}

		public static GameObject CreateTreasurePod(List<Gadget.Id> ids, Transform parent, string nameOfIdHandler)
		{
			parent.gameObject.SetActive(false);
			GameObject gameObject = Object.Instantiate<GameObject>(GameObject.Find("zoneREEF/cellReef_Intro/Sector/Loot/treasurePod Rank3"), parent);
			TreasurePod component = gameObject.GetComponent<TreasurePod>();
			component.director = parent.GetRequiredComponentInParent<IdDirector>(false);
			component.director.persistenceDict.Add(component, ModdedStringRegistry.ClaimID(component.IdPrefix(), nameOfIdHandler));
			component.blueprint = Gadget.Id.NONE;
			component.spawnObjs = null;
			gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
			EntryPoint.gadgetIds.Add(component, ids);
			parent.gameObject.SetActive(true);
			return gameObject;
		}

		public static GadgetDefinition.CraftCost[] CreateWarpDepotCraftCosts(Identifiable.Id plortId, Identifiable.Id resourceId)
		{
			return new GadgetDefinition.CraftCost[]
			{
				new GadgetDefinition.CraftCost
				{
					id = plortId,
					amount = 1
				},
				new GadgetDefinition.CraftCost
				{
					id = resourceId,
					amount = 6
				},
				new GadgetDefinition.CraftCost
				{
					id = Identifiable.Id.SLIME_FOSSIL_CRAFT,
					amount = 3
				},
				new GadgetDefinition.CraftCost
				{
					id = Identifiable.Id.LAVA_DUST_CRAFT,
					amount = 1
				}
			};
		}

		public static GadgetDefinition.CraftCost[] CreateLampCraftCosts(Identifiable.Id plortId, Identifiable.Id resourceId)
		{
			return new GadgetDefinition.CraftCost[]
			{
				new GadgetDefinition.CraftCost
				{
					id = Identifiable.Id.PHOSPHOR_PLORT,
					amount = 12
				},
				new GadgetDefinition.CraftCost
				{
					id = plortId,
					amount = 12
				},
				new GadgetDefinition.CraftCost
				{
					id = resourceId,
					amount = 8
				},
				new GadgetDefinition.CraftCost
				{
					id = Identifiable.Id.SPIRAL_STEAM_CRAFT,
					amount = 8
				}
			};
		}

		public static GadgetDefinition.CraftCost[] CreateTeleporterCraftCosts(Identifiable.Id plortId, Identifiable.Id resourceId)
		{
			return new GadgetDefinition.CraftCost[]
			{
				new GadgetDefinition.CraftCost
				{
					id = plortId,
					amount = 25
				},
				new GadgetDefinition.CraftCost
				{
					id = resourceId,
					amount = 10
				},
				new GadgetDefinition.CraftCost
				{
					id = Identifiable.Id.SPIRAL_STEAM_CRAFT,
					amount = 5
				},
				new GadgetDefinition.CraftCost
				{
					id = Identifiable.Id.STRANGE_DIAMOND_CRAFT,
					amount = 1
				}
			};
		}

		private static readonly int Color00 = Shader.PropertyToID("_Color00");

		private static readonly int Color01 = Shader.PropertyToID("_Color01");

		private static readonly int Color11 = Shader.PropertyToID("_Color11");

		private static readonly int Color20 = Shader.PropertyToID("_Color20");

		private static readonly int Color21 = Shader.PropertyToID("_Color21");

		private static readonly int Color30 = Shader.PropertyToID("_Color30");

		private static readonly int Color31 = Shader.PropertyToID("_Color31");

		private static readonly int TopColor = Shader.PropertyToID("_TopColor");

		private static readonly int MiddleColor = Shader.PropertyToID("_MiddleColor");

		private static readonly int BottomColor = Shader.PropertyToID("_BottomColor");
	}
}
