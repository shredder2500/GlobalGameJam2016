using UnityEngine;
using System.Collections;
using System.Linq;

public class RitualSite : MonoBehaviour 
{
    [SerializeField]
    private bool _isLightSide;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "player")
        {
            int[] keys;

            if(_isLightSide)
            {
                keys = new []{0, 1, 2};
            }
            else
            {
                keys = new []{3, 4, 5};
            }

            foreach (var ritualItem in keys.Where(key => Inventory.Items[key] == InventoryItem.LocationEnum.InInventory))
            {
                Inventory.Items[ritualItem] = InventoryItem.LocationEnum.AtRitualSite;
            }
        }
    }
}
