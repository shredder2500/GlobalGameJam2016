using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class Inventory 
{
    static Inventory()
    {
        Items = new Dictionary<int, InventoryItem.LocationEnum>();
    }

    public static Dictionary<int, InventoryItem.LocationEnum> Items { get; set; }

    public static InventoryItem.LocationEnum GetLocationByID(int id)
    {
        InventoryItem.LocationEnum location;

        if(!Items.TryGetValue(id, out location))
        {
            location = InventoryItem.LocationEnum.OnWorld;
            AddNewWorldItemRef(id);
        }

        return location;
    }

    public static void SetLocationByID(int id, InventoryItem.LocationEnum location)
    {
        if (Items.ContainsKey(id))
        {
            Items[id] = location;
        }
        else
        {
            Items.Add(id, location);
        }
    }

    public static void DropItemByID(int id)
    {
        if (Items.ContainsKey(id))
        {
            Items[id] = InventoryItem.LocationEnum.OnWorld;
        }
        else
        {
            AddNewWorldItemRef(id);
        }
    }

    private static void AddNewWorldItemRef(int id)
    {
        Items.Add(id, InventoryItem.LocationEnum.OnWorld);
    }

    public static void CollectFromWorldByID(int id)
    {
        if(!Items.ContainsKey(id))
        {
            AddNewWorldItemRef(id);
        }
        Items[id] = InventoryItem.LocationEnum.InInventory;
    }

    public static void PlaceAtRitualByID(int id)
    {
        if (Items[id] == InventoryItem.LocationEnum.InInventory)
        {
            Items[id] = InventoryItem.LocationEnum.AtRitualSite;
        }
    }
}



