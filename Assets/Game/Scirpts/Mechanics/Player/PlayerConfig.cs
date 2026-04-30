using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Custom/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public LayerMask groundMask;
    public float speed;
    public AnimationCurve curve;
}
