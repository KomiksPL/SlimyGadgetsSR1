using System;
using System.Collections.Generic;
using SRML.SR;
using UnityEngine;

namespace SlimyGadgets.Gadgets
{
    internal class GlitchSlime
    {
        public static void Build()
        {
            Color slimeColor = Color.white;
            Identifiable.Id glitchBugReportId = Identifiable.Id.GLITCH_BUG_REPORT;
            Identifiable.Id glitchPlortId;

            bool isGlitchPlortParsed = Enum.TryParse<Identifiable.Id>("GLITCH_PLORT", out glitchPlortId);
            if (isGlitchPlortParsed)
            {
                glitchBugReportId = glitchPlortId;
            }
            else
            {
                AmmoRegistry.RegisterRefineryResource(glitchBugReportId);
            }

            GameObject teleporterGameObject = ScienceUtils.CreateTeleporter(Enums.Gadgets.TELEPORTER_QUESTION, "?", slimeColor, ScienceUtils.CreateTeleporterCraftCosts(glitchBugReportId, Identifiable.Id.MANIFOLD_CUBE_CRAFT));
            Material teleporterMaterial = teleporterGameObject.transform.Find("model_telepad/mesh_telepad").GetComponent<SkinnedMeshRenderer>().sharedMaterial;
            teleporterMaterial.SetColor("_Color20", Color.magenta);

            GameObject lampGameObject = ScienceUtils.CreateLamp(Enums.Gadgets.LAMP_QUESTION, "?", Identifiable.Id.GLITCH_SLIME, ScienceUtils.CreateLampCraftCosts(glitchBugReportId, Identifiable.Id.MANIFOLD_CUBE_CRAFT));
            Material[] lampMaterials = lampGameObject.transform.Find("slimeslime").GetComponent<SkinnedMeshRenderer>().sharedMaterials;
            SlimeDefinition glitchSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME);
            for (int i = 0; i < lampMaterials.Length; i++)
            {
                if (lampMaterials[i].name == "mouthElated")
                {
                    lampMaterials[i] = glitchSlimeDefinition.AppearancesDefault[0].Face.GetExpressionFace(SlimeFace.SlimeExpression.Happy).Mouth;
                }
                else if (lampMaterials[i].name == "eyeElated")
                {
                    lampMaterials[i] = glitchSlimeDefinition.AppearancesDefault[0].Face.GetExpressionFace(SlimeFace.SlimeExpression.Happy).Eyes;
                }
            }

            List<Material> lampMaterialList = new List<Material>();
            foreach (Material material in lampMaterials)
            {
                lampMaterialList.Add(material);
            }
            lampGameObject.transform.Find("slimeslime").GetComponent<SkinnedMeshRenderer>().sharedMaterials = lampMaterialList.ToArray();

            GameObject warpDepotGameObject = ScienceUtils.CreateWarpDepot(Enums.Gadgets.WARP_DEPOT_QUESTION, "?", slimeColor, ScienceUtils.CreateWarpDepotCraftCosts(glitchBugReportId, Identifiable.Id.MANIFOLD_CUBE_CRAFT));
            Material warpDepotMaterial = warpDepotGameObject.transform.Find("warpdepot").GetComponent<MeshRenderer>().sharedMaterial;
            warpDepotMaterial.SetColor("_Color20", Color.magenta);
            warpDepotMaterial.SetColor("_Color31", Color.magenta);

            SRCallbacks.PreSaveGameLoad += delegate (SceneContext context)
            {
                List<Gadget.Id> gadgetIds = new List<Gadget.Id>
                {
                    Enums.Gadgets.TELEPORTER_QUESTION,
                    Enums.Gadgets.LAMP_QUESTION,
                    Enums.Gadgets.WARP_DEPOT_QUESTION
                };

                GameObject treasurePodGameObject = ScienceUtils.CreateTreasurePod(gadgetIds, GameObject.Find("zoneSLIMULATIONS/cellSlimulationQuarry_FeralColumns/Sector/Loot").transform, "QuestionGadget");
                treasurePodGameObject.transform.localPosition = new Vector3(1014.937f, 21.40518f, 1225.853f);
                treasurePodGameObject.transform.position = new Vector3(1014.937f, 21.40518f, 1225.853f);
            };
        }
    }
}
