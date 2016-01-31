using UnityEngine;
using System.Collections.Generic;

public class InventoryItem : MonoBehaviour
{
    private static Dictionary<int, Vector3> _itemWorkPositions
        = new Dictionary<int, Vector3>();

    [SerializeField]
    private int _id;

    private AudioSource _itemCollectionSound;

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

    public void Start()
    {
        Vector3 position;
        if(_itemWorkPositions.TryGetValue(ID, out position))
        {
            Debug.Log("Loading Item " + ID);
            transform.position = position;
        }
        else
        {
            Debug.Log("Adding Item " + ID);
            _itemWorkPositions.Add(ID, transform.position);
        }

        this._itemCollectionSound = GetComponent<AudioSource>();
    }

    public void OnDestroy()
    {
        _itemWorkPositions[ID] = transform.position;
        Inventory.DropItemByID(ID);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Item " + ID + " hit by object w/ tag " + col.gameObject.tag);

        if (col.gameObject.tag == "Player")
        {
            _itemCollectionSound.Play();
            Inventory.CollectFromWorldByID(ID);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
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
