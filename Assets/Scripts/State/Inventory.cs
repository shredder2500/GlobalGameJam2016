using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class Inventory 
{
    static Inventory()
    {
        Light1 = new InventoryItem { ID = 0, Location  = InventoryItem.LocationEnum.OnWorld };
        Light2 = new InventoryItem { ID = 1, Location = InventoryItem.LocationEnum.OnWorld };
        Light3 = new InventoryItem { ID = 2, Location = InventoryItem.LocationEnum.OnWorld };

        Dark1 = new InventoryItem { ID = 3, Location = InventoryItem.LocationEnum.OnWorld };
        Dark2 = new InventoryItem { ID = 4, Location = InventoryItem.LocationEnum.OnWorld };
        Dark3 = new InventoryItem { ID = 5, Location = InventoryItem.LocationEnum.OnWorld };
    }

    public static InventoryItem.LocationEnum GetLocationByID(int id)
    {
        switch (id)
        {
            case 0: return Light1.Location;
            case 1: return Light2.Location;
            case 2: return Light3.Location;
            case 3: return Dark1.Location;
            case 4: return Dark2.Location;
            case 5: return Dark3.Location;
        }
        throw new Exception("No ritual item with ID " + id + " exists");
    }

    public static void SetLocationByID(int id, InventoryItem.LocationEnum location)
    {
        switch (id)
        {
            case 0: Light1.Location = location;
                break;
            case 1: Light2.Location = location;
                break;
            case 2: Light3.Location = location;
                break;
            case 3: Dark1.Location = location;
                break;
            case 4: Dark2.Location = location;
                break;
            case 5: Dark3.Location = location;
                break;
        }
    }

    public static void CollectFromWorldByID(int id)
    {
        switch (id)
        {
            case 0: Light1.Location = InventoryItem.LocationEnum.OnWorld;
                break;
            case 1: Light2.Location = InventoryItem.LocationEnum.OnWorld;
                break;
            case 2: Light3.Location = InventoryItem.LocationEnum.OnWorld;
                break;
            case 3: Dark1.Location = InventoryItem.LocationEnum.OnWorld;
                break;
            case 4: Dark2.Location = InventoryItem.LocationEnum.OnWorld;
                break;
            case 5: Dark3.Location = InventoryItem.LocationEnum.OnWorld;
                break;
        }
    }

    public static void PlaceAtRitualByID(int id)
    {
        switch (id)
        {
            case 0:
                if (Light1.Location == InventoryItem.LocationEnum.InInventory)
                {
                    Light1.Location = InventoryItem.LocationEnum.OnWorld;
                }
                break;
            case 1:
                if (Light2.Location == InventoryItem.LocationEnum.InInventory)
                {
                    Light2.Location = InventoryItem.LocationEnum.OnWorld;
                }
                break;
            case 2:
                if (Light3.Location == InventoryItem.LocationEnum.InInventory)
                {
                    Light3.Location = InventoryItem.LocationEnum.OnWorld;
                }
                break;
            case 3:
                if (Dark1.Location == InventoryItem.LocationEnum.InInventory)
                {
                    Dark1.Location = InventoryItem.LocationEnum.OnWorld;
                }
                break;
            case 4:
                if (Dark2.Location == InventoryItem.LocationEnum.InInventory)
                {
                    Dark2.Location = InventoryItem.LocationEnum.OnWorld;
                }
                break;
            case 5:
                if (Dark3.Location == InventoryItem.LocationEnum.InInventory)
                {
                    Dark3.Location = InventoryItem.LocationEnum.OnWorld;
                }
                break;
        }
    }
    
    public static InventoryItem Light1 { get; set; }
    public static InventoryItem Light2 { get; set; }
    public static InventoryItem Light3 { get; set; }
    public static InventoryItem Dark1 { get; set; }
    public static InventoryItem Dark2 { get; set; }
    public static InventoryItem Dark3 { get; set; }
}



