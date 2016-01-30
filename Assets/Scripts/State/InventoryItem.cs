﻿using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private int _id;


    public int ID { get { return _id; } set { _id = value; } }

    public LocationEnum Location
    {
        get { return Inventory.GetLocationByID(_id); }
        set { Inventory.SetLocationByID(_id, value); }
    }

    public enum LocationEnum
    {
        OnWorld,
        InInventory,
        AtRitualSite
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "player")
        {
            Inventory.CollectFromWorldByID(ID);
        }
    }

    public void PlaceAtRitual()
    {
        Inventory.PlaceAtRitualByID(ID);
    }
}
