using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour
{
    public InventoryItem()
    {
        Location = LocationEnum.OnWorld;
    }


    [SerializeField]
    private int _id;


    public int ID { get { return _id; } set {_id = value } }

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

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void CollectFromWorld()
    {
        Inventory.CollectFromWorldByID(ID);
    }

    public void PlaceAtRitual()
    {
        Inventory.PlaceAtRitualByID(ID);
    }
}
