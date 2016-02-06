using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

namespace GGJ
{
    public class Portal : MonoBehaviour
    {

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                portalCheck();
                TrySwapLevel();
            }
        }

        private void TrySwapLevel()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                FindObjectOfType<SceneToggle>().ToggleScenes();
            }
        }

        private bool CheckIfHasLevelItems()
        {
            return FindObjectsOfType<InventoryItem>()
                .All(item => Inventory.GetLocationByID(item.ID) == InventoryItem.LocationEnum.AtRitualSite);
            //return (SceneManager.GetActiveScene().name == "DarkLevel" && Ritual.HasDarkSideItems)
            //    || (SceneManager.GetActiveScene().name == "LightLevel" && Ritual.HasLightSideItems);
        }

        private void portalCheck()
        {
            foreach(var inventoryItem in FindObjectsOfType<InventoryItem>()
                .Where(item => Inventory.GetLocationByID(item.ID) == InventoryItem.LocationEnum.InInventory))
            {
                inventoryItem.PlaceAtRitual();
            }

            if (CheckIfHasLevelItems())
            {
                GetComponent<Animator>().SetBool("OpenPortal", true);
            }
        }
    }
}