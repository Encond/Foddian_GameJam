using UnityEngine;
using UnityEngine.UI;

public class VolumeMenager : MonoBehaviour
{
    private static readonly string FirstPlay = "Firstplay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private int firsPlayInt = 1;
    public Slider musicSlider, sounfEffectsSlidere;
    private float musicFloat, soundEffectsFloat;
    public AudioSource musicAudio;
    public AudioSource musicAudio1;
    public AudioSource[] soundEffectsAudio;

    private void Start()
    {
        if(firsPlayInt == 0)
        {
            musicFloat = 0f;
            soundEffectsFloat = 0.75f;
            musicSlider.value = musicFloat;
            sounfEffectsSlidere.value =soundEffectsFloat;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
            
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            sounfEffectsSlidere.value = soundEffectsFloat;
            

        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, sounfEffectsSlidere.value);
        
    }

    public void UpdateSound()
    {
        musicAudio.volume = musicSlider.value;
        musicAudio1.volume = musicSlider.value;
        for(int i = 0; i< soundEffectsAudio.Length; i++)
            soundEffectsAudio[i].volume = sounfEffectsSlidere.value;
        
    }
    public void StartCliksAudio(int number) => soundEffectsAudio[number].Play();
}
