namespace MapManager
{
    [HarmonyPatch( typeof(Panel_Map), nameof(Panel_Map.RevealOnPolaroidDiscovery), new Type[] { typeof(string), typeof(bool) } )]
    internal class Panel_Map_RevealOnPolaroidDiscovery
    {
        private static bool Prefix(ref string polaroidGearItemName, ref bool showOnMap)
        {
            MelonLogger.Log($"polaroidGearItemName: {polaroidGearItemName}. showOnMap: {showOnMap}");
            return !Settings.Instance.MapWithPolariods;
        }
    }
}
