using UnityEngine;
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

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Item " + ID + " hit by object w/ tag " + col.gameObject.tag);

        if (col.gameObject.tag == "Player")
        {
            Inventory.CollectFromWorldByID(ID);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void PlaceAtRitual()
    {
        Inventory.PlaceAtRitualByID(ID);
    }

    public void DropItem()
    {
        Inventory.DropItemByID(ID);
    }
}
