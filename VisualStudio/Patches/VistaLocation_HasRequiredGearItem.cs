namespace MapManager
{
	[HarmonyPatch(typeof(Panel_Map), nameof(Panel_Map.HasVistaLocationRequiredGearItem))]
	internal class VistaLocation_HasRequiredGearItem
	{
		private static void Postfix(Panel_Map __instance, VistaLocation vistaLocation, ref bool __result)
		{
			if (Settings.Instance.MapWithPolariods && vistaLocation != null && !__result)
			{
				GearItem requiredGearItem = vistaLocation.m_RequiredGearItem;
				if (requiredGearItem != null)
				{
					MelonLogger.Log($"Add: {requiredGearItem.GetDisplayNameWithoutConditionForInventoryInterfaces()}");
					GameManager.GetPlayerManagerComponent().AddItemToPlayerInventory(requiredGearItem, true, true);
					__result = true;
				}
			}
			if (!__result && vistaLocation != null)
			{
				MelonLogger.Log($"{vistaLocation.m_LocationName.Text()}: Result is false");
			}
		}
	}
}
