using UnityEngine;
using System.Collections;

public class MenuSounds : MonoBehaviour
{
    private AudioSource _menuAudioSource;

    [SerializeField]
    private AudioClip _menuClickSound;
    
    void Start()
    {
        _menuAudioSource = this.gameObject.AddComponent<AudioSource>();
        _menuAudioSource.clip = _menuClickSound;
        DontDestroyOnLoad(_menuAudioSource);
    }

    public void PlayClickSound()
    {
        _menuAudioSource.Play();
    }
}
