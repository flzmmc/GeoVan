using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer musicMixer, environmentMixer;
    [SerializeField] Slider masterSlider, environmentSlider;

    [SerializeField] AudioSource musicAudio, environmentAudio;

    static AudioManager instance;

    //Sahneler arasý geçiþte bu nesneyi yok etme
    //Eðer ki bu nesneden baþka bir tane daha oluþtuysa oluþan nesneyi sil
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
        if (LevelManager.level == 0) StopAudio();
        //Background/Environment adlý anahtarlar var mý kontrol et, eðer varsa slider deðerini anahtardaki deðere eþitle
        if (PlayerPrefs.HasKey("Background")) masterSlider.value = PlayerPrefs.GetFloat("Background");
        musicMixer.SetFloat("Background", masterSlider.value);

        if (PlayerPrefs.HasKey("Environment")) environmentSlider.value = PlayerPrefs.GetFloat("Environment");
        environmentMixer.SetFloat("Environment", environmentSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Ses seviyelerini ayarla ve kaydet
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
    //Ýçine gönderilen klibi oynat, hali hazýrda oynayan bir klip varsa onu kapat yenisini oynat
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
            environmentAudio.clip = clip;
            environmentAudio.PlayOneShot(clip);
        }
    }
    //Eðer oynayan bir klip varsa onu durdur
    public void StopAudio()
    {
        if (environmentAudio.isPlaying)
        {
            environmentAudio.Stop();
            environmentAudio.clip = null;
        }
    }
    //Klibin uzunluðunu hesapla ve deðeri döndür
    public float SoundTime(AudioClip clip)
    {
        return clip.length;
    }

}
