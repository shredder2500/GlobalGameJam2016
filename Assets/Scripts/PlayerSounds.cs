using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip clipLightWalk;
    public AudioClip clipLightAttack;

    public AudioSource audioLightWalk;
    public AudioSource audioLightAttack;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Awake()
    {
        audioLightWalk = AddAudio(clipLightWalk, true, true, 1f);
        audioLightAttack = AddAudio(clipLightAttack, true, true, 1f);
        Debug.Log("Audio is awake!");
    }

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }
}
