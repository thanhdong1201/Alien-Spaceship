using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Save", menuName = "Audio/Audio Save")]
public class AudioSettingSO : ScriptableObject
{
	[Tooltip("The initial value")]
	[SerializeField] private float _currentMusicValue;
	[SerializeField] private float _currentSoundEffectValue;

	public float CurrentMusicValue => _currentMusicValue;
	public float CurrentSoundEffectValue => _currentSoundEffectValue;

	public void SetCurrentMusicValue(float newValue)
	{
		_currentMusicValue = newValue;
	}
	public void SetCurrentSoundEffectValue(float newValue)
	{
		_currentSoundEffectValue = newValue;
	}
}
