using BepInEx;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace JesusLovesYou;
[BepInPlugin("com.neboskript.gorillatag.jesuslovesyou", "JesusLovesYou", "1.0.0"), HarmonyPatch]
public class Plugin : BaseUnityPlugin
{
    private void Awake() => Harmony.CreateAndPatchAll(GetType().Assembly, Info.Metadata.GUID);
    private static async void FetchVerse(TextMeshPro text)
    {
        UnityWebRequest req = UnityWebRequest.Get("https://labs.bible.org/api/?passage=random");

        await req.SendWebRequest();
        if (req.result == UnityWebRequest.Result.Success)
        {
            text.richText = true;
            text.text = req.downloadHandler.text.ToUpper().Replace("</b>", "</b>\n");

            return;
        }

        Debug.LogError($"cant fetch random verse: {req.result}");
    }
    [HarmonyPatch(typeof(PlayFabTitleDataTextDisplay), "OnTitleDataRequestComplete")]
    private static bool Prefix(ref PlayFabTitleDataTextDisplay __instance)
    {
        if (!__instance.name.Contains("motd")) return true;

        Debug.Log($"fetching random verse for motd: {__instance.transform.parent.name}/{__instance.name}");
        FetchVerse(Traverse.Create(__instance).Field("textBox").GetValue<TextMeshPro>());
        return false;
    }
}