using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour
{
    public int ID { get; set; }

    public LocationEnum Location { get; set; }

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
        Location = LocationEnum.OnWorld;
    }

    public void PlaceAtRitual()
    {
        if (Location == LocationEnum.InInventory)
        {
            Location = LocationEnum.OnWorld;
        }
    }
}
