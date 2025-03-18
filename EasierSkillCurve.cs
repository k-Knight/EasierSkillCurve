using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using static Skills;

namespace MyBepInExPlugin
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        const string pluginGUID = "EasierSkillCurve";
        const string pluginName = "EasierSkillCurve";
        const string pluginVersion = "0.1.0";

        private readonly Harmony HarmonyInstance = new Harmony(pluginGUID);

        public static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource(pluginName);

        public void Awake() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            HarmonyInstance.PatchAll(assembly);
        }

        // More Code Here!
        [HarmonyPatch(typeof(Skill), "GetNextLevelRequirement")]
        public static class Patch_Skill_GetNextLevelRequirement {
            public static bool Prefix(Skill __instance, ref float __result) {
                __result = Mathf.Floor(__instance.m_level + 1f);
                return false;
            }
        }
    }
}