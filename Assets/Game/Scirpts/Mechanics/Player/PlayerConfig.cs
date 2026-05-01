using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Custom/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public LayerMask groundMask;
    public float speed;
    public int health;
    [Tooltip("ДЛЯ АНИМАЦИИ ПОДНЯТИЕ НА ГОРКУ")] public AnimationCurve curve;
}
