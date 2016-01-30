using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ
{
    public class SceneToggle : MonoBehaviour
    {
        [SerializeField]
        private string _otherSceneName;

        public void ToggleScenes()
        {
            SceneManager.LoadScene(_otherSceneName);
        }
    }
}
