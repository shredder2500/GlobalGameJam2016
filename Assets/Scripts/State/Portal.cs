using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace GGJ
{
    public class Portal : MonoBehaviour
    {

        //private bool playerTouchingPortal = false;

        //public GameObject Player;

        void Update()
        {
            //if (playerTouchingPortal)
            //{
            //    // Check the ritual states to determine action.

            //}
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                //playerTouchingPortal = true;

                // Check the ritual states to determine action.
                Debug.Log("Player entered portal!");
                portalCheck();
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                //playerTouchingPortal = false;

                // Check the ritual states to determine action.
                Debug.Log("Player left portal!");
            }
        }

        private void portalCheck()
        {
            if (Ritual.HasAllItems)
            {
                // Player won game/level.

            }
            else if ((SceneManager.GetActiveScene().name == "DarkLevel" && Ritual.HasDarkSideItems) || (SceneManager.GetActiveScene().name == "LightLevel" && Ritual.HasLightSideItems))
            {
                // Port player to other level.
                SceneToggle sceneToggle = FindObjectOfType<SceneToggle>();
                sceneToggle.ToggleScenes();
            }
        }
    }
}