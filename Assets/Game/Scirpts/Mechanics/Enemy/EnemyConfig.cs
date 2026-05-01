using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Custom/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public int health;
    public float speed;
    public float damage;
}
