using UnityEngine.Audio;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public void SoundPlay()
    {
        audioData.Play(0);
    }
}
