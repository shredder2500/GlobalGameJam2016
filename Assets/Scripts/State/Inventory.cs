using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class Inventory 
{
    static Inventory()
    {
        Items = new Dictionary<int, InventoryItem.LocationEnum>();
        for (int i = 0; i < 5; i++)
        {
            Items.Add(i, InventoryItem.LocationEnum.OnWorld);
        }
    }

    public static Dictionary<int, InventoryItem.LocationEnum> Items { get; set; }

    public static InventoryItem.LocationEnum GetLocationByID(int id)
    {
        return Items[id];
    }

    public static void SetLocationByID(int id, InventoryItem.LocationEnum location)
    {
        Items[id] = location;
    }

    public static void DropItemByID(int id)
    {
        Items[id] = InventoryItem.LocationEnum.OnWorld;
    }

    public static void CollectFromWorldByID(int id)
    {
        Items[id] = InventoryItem.LocationEnum.InInventory;
    }

    public static void PlaceAtRitualByID(int id)
    {
        if (Items[id] == InventoryItem.LocationEnum.InInventory)
        {
            Items[id] = InventoryItem.LocationEnum.OnWorld;
        }
    }
}



