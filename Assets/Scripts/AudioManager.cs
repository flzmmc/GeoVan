using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer musicMixer, environmentMixer;
    [SerializeField] Slider masterSlider, environmentSlider;

    [SerializeField] AudioSource musicAudio, environmentAudio;

    static AudioManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Background")) masterSlider.value = PlayerPrefs.GetFloat("Background");
        musicMixer.SetFloat("Background", masterSlider.value);

        if (PlayerPrefs.HasKey("Environment")) environmentSlider.value = PlayerPrefs.GetFloat("Environment");
        environmentMixer.SetFloat("Environment", environmentSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float volume)
    {
        musicMixer.SetFloat("Background", volume);
        PlayerPrefs.SetFloat("Background", volume);
    }

    public void SetEnvironmentVolume(float volume)
    {
        environmentMixer.SetFloat("Environment", volume);
        PlayerPrefs.SetFloat("Environment", volume);
    }

    public void PlayAudio(AudioClip clip)
    {
        if (environmentAudio.isPlaying)
        {
            environmentAudio.Stop();
            environmentAudio.clip = clip;
            environmentAudio.PlayOneShot(clip);
        }
        else
        {
            //Debug.Log(clip);
            environmentAudio.clip = clip;
            environmentAudio.PlayOneShot(clip);
        }
    }

    public float SoundTime(AudioClip clip)
    {
        return clip.length;
    }

}
