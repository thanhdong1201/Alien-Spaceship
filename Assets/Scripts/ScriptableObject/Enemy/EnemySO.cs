using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Character/Enemy ")]
public class EnemySO : ScriptableObject
{
	[Header("Health")]
	public float maxHealth;	
	[Header("Move settings")]
	public float speed = 5f;
	public float range = 3.8f;
	[Header("Attack settings")]
	public float resetShoot = 1f;
	public GameObject projectitlePrefab;
	[Header("Destroy settings")]
	public int scoreCanGet;
	public GameObject explosionFX;
	

}
