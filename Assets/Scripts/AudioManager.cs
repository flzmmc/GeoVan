using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer, worldMixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float volume)
    {
        masterMixer.SetFloat("Background", volume);
    }

    public void SetWorldVolume(float volume)
    {
        worldMixer.SetFloat("World", volume);
    }

}
