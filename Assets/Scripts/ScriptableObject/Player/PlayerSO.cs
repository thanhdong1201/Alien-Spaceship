using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Character/Player ")]
public class PlayerSO : ScriptableObject
{
	[Header("Health")]
	public float maxHealth;
	public float shieldTime = 5f;
	public float speed = 5f;
	public GameObject defaultProjectitlePrefab;
	public GameObject currentProjectitlePrefab;
	public GameObject explosionFX;
	[Header("Sound effect")]
	public AudioClip shootSound;
	public AudioClip destroySound;


	public void SetDefaultProjectitle()
	{
		currentProjectitlePrefab = defaultProjectitlePrefab;
	}
	public void SetProjectitle(GameObject gameObject)
    {
		currentProjectitlePrefab = gameObject;
    }
}