using UnityEngine;
using System.Collections;

public static class Ritual
{
    public static bool HasLightSideItems
    {
        get
        {
            return
                  (
                    Inventory.GetLocationByID(0) == InventoryItem.LocationEnum.AtRitualSite
                    &&
                    Inventory.GetLocationByID(1) == InventoryItem.LocationEnum.AtRitualSite
                    &&
                    Inventory.GetLocationByID(2) == InventoryItem.LocationEnum.AtRitualSite
                  );
        }
    }

    public static bool HasDarkSideItems
    {
        get
        {
            return
                  (
                    Inventory.GetLocationByID(3) == InventoryItem.LocationEnum.AtRitualSite
                    &&
                    Inventory.GetLocationByID(4) == InventoryItem.LocationEnum.AtRitualSite
                    &&
                    Inventory.GetLocationByID(5) == InventoryItem.LocationEnum.AtRitualSite
                  );
        }
    }

    public static bool HasAllItems
    {
        get
        {
            return HasLightSideItems && HasDarkSideItems;
        }
    }
}
