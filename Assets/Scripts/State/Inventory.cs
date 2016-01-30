using UnityEngine;
using System.Collections;

public static class Inventory 
{
    static Inventory()
    {
        Light1 = new InventoryItem { ID = 0, Location  = InventoryItem.LocationEnum.OnWorld};
        Light2 = new InventoryItem { ID = 1, Location = InventoryItem.LocationEnum.OnWorld };
        Light3 = new InventoryItem { ID = 2, Location = InventoryItem.LocationEnum.OnWorld };
        Dark1 = new InventoryItem { ID = 3, Location = InventoryItem.LocationEnum.OnWorld };
        Dark2 = new InventoryItem { ID = 4, Location = InventoryItem.LocationEnum.OnWorld };
        Dark3 = new InventoryItem { ID = 5, Location = InventoryItem.LocationEnum.OnWorld };
    }

    public static InventoryItem Light1 { get; set; }
    public static InventoryItem Light2 { get; set; }
    public static InventoryItem Light3 { get; set; }
    public static InventoryItem Dark1 { get; set; }
    public static InventoryItem Dark2 { get; set; }
    public static InventoryItem Dark3 { get; set; }
}



