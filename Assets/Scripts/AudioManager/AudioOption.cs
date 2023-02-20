using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEditor;

public class AudioOption : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundEffectSlider;

    [Header("AudioMixerGroup")]
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup soundEffectMixerGroup;

    [Header("SaveValue")]
    [SerializeField] private AudioSettingSO _currentAudioSave;

    private float musicVolume;
    private float soundEffectVolume;

    private void Awake()
    {
        if (_currentAudioSave == null)
        {
            _currentAudioSave = ScriptableObject.CreateInstance<AudioSettingSO>();

        }
    }

    private void Start()
    {
        SetValue();
    }

    private void Update()
    {
        SetValue();
    }

    private void SetValue()
    {
        //EditorUtility.SetDirty(_currentAudioSave);
        //Music
        musicVolume = _currentAudioSave.CurrentMusicValue;
        musicSlider.value = musicVolume;
        musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(musicVolume) * 20);

        //SoundEffect
        soundEffectVolume = _currentAudioSave.CurrentSoundEffectValue;
        soundEffectSlider.value = soundEffectVolume;
        soundEffectMixerGroup.audioMixer.SetFloat("SoundEffect Volume", Mathf.Log10(soundEffectVolume) * 20);
    }

    public void OnChangeMusicSlider(float value)
    {
        //Send float value from this to AudioSave ScriptableObject to save value of audio
        _currentAudioSave.SetCurrentMusicValue(value);
    }

    public void OnChangeSoundEffectSlider(float value)
    {
        //Send float value from this to AudioSave ScriptableObject to save value of audio
        _currentAudioSave.SetCurrentSoundEffectValue(value);
    }

}
