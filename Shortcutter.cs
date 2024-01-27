using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SRML.Console;
using UnityEngine;

namespace SlimyGadgets
{
	internal class Shortcutter
	{
		internal static GadgetDefinition CopyGadgetDefinition(GadgetDefinition gadgetDefinition, Gadget.Id id, Sprite sprite, GameObject prefab, GadgetDefinition.CraftCost[] craftCost)
		{
			bool flag = sprite == null;
			if (flag)
			{
				sprite = Resources.FindObjectsOfTypeAll<Sprite>().First((Sprite x) => x.name == "unknownLarge");
			}
			GadgetDefinition gadgetDefinition2 = ScriptableObject.CreateInstance<GadgetDefinition>();
			gadgetDefinition2.icon = sprite;
			gadgetDefinition2.id = id;
			gadgetDefinition2.prefab = prefab;
			gadgetDefinition2.blueprintCost = gadgetDefinition.blueprintCost;
			gadgetDefinition2.countLimit = gadgetDefinition.countLimit;
			gadgetDefinition2.craftCosts = craftCost;
			gadgetDefinition2.pediaLink = gadgetDefinition.pediaLink;
			gadgetDefinition2.buyCountLimit = gadgetDefinition.buyCountLimit;
			gadgetDefinition2.buyInPairs = gadgetDefinition.buyInPairs;
			gadgetDefinition2.countOtherIds = gadgetDefinition.countOtherIds;
			gadgetDefinition2.destroyOnRemoval = gadgetDefinition.destroyOnRemoval;
			return gadgetDefinition2;
		}

		private static Texture2D CreateTexture2DFromImage(string fileName)
		{
			string text = "SlimyGadgets.Images." + fileName + ".png";
			Texture2D texture2D = new Texture2D(4, 4);
			Stream manifestResourceStream = EntryPoint.execAssembly.GetManifestResourceStream(text);
			bool flag = manifestResourceStream != null;
			Texture2D texture2D2;
			if (flag)
			{
				byte[] array = new byte[manifestResourceStream.Length];
				_ = manifestResourceStream.Read(array, 0, (int)manifestResourceStream.Length);
				texture2D.LoadImage(array);
				texture2D.name = fileName;
				texture2D2 = texture2D;
			}
			else
			{
				SRML.Console.Console.LogError("Missing Texture2D: " + fileName, true);
				texture2D2 = Resources.FindObjectsOfTypeAll<Sprite>().First((Sprite x) => x.name == "unknownLarge").texture;
			}
			return texture2D2;
		}

		internal static Sprite CreateSpriteFromImage(string fileName)
		{
			bool flag = !Shortcutter.cache.ContainsKey(fileName);
			Sprite sprite2;
			if (flag)
			{
				Texture2D texture2D = null;
				try
				{
					texture2D = Shortcutter.CreateTexture2DFromImage(fileName);
				}
				catch (NullReferenceException)
				{
					SRML.Console.Console.LogError("Missing Sprite: " + fileName, true);
					return Resources.FindObjectsOfTypeAll<Sprite>().First((Sprite x) => x.name == "unknownLarge");
				}
				Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f));
				sprite.name = fileName;
				Shortcutter.cache.Add(fileName, sprite);
				sprite2 = sprite;
			}
			else
			{
				sprite2 = Shortcutter.cache[fileName];
			}
			return sprite2;
		}

		private static Dictionary<string, Sprite> cache = new Dictionary<string, Sprite>();
	}
}
