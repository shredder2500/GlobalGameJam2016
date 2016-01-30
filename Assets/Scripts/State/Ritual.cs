using UnityEngine;
using System.Collections;

public static class Ritual
{
    public bool HasLightSideItems
    {
        get
        {
            return
                  (
                    Inventory.Light1.Location == InventoryItem.LocationEnum.AtRitualSite
                    &&
                    Inventory.Light2.Location == InventoryItem.LocationEnum.AtRitualSite
                    &&
                    Inventory.Light3.Location == InventoryItem.LocationEnum.AtRitualSite
                  );
        }
    }

    public bool HasDarkSideItems
    {
        get
        {
            return
                  (
                    Inventory.Dark1.Location == InventoryItem.LocationEnum.AtRitualSite
                    &&
                    Inventory.Dark1.Location == InventoryItem.LocationEnum.AtRitualSite
                    &&
                    Inventory.Dark1.Location == InventoryItem.LocationEnum.AtRitualSite
                  );
        }
    }

    public bool HasAllItems
    {
        get
        {
            return HasLightSideItems && HasDarkSideItems;
        }
    }
}
