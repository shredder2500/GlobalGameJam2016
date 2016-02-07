using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Events;

namespace GGJ
{
    public class Portal : MonoBehaviour
    {
        [SerializeField]
        private string _endingScene;

        private void Start()
        {
            portalCheck();
        }

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
                if (Ritual.HasAllItems)
                {
                    SceneManager.LoadScene(_endingScene);
                }
                else if(CheckIfHasLevelItems())
                {
                    FindObjectOfType<SceneToggle>().ToggleScenes();
                }
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