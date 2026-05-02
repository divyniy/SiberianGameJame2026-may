using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Custom/GameConfig")]
public class GameConfig : ScriptableObject
{
    public GameObject SceneTransition;
    public Ability[] abilities;
}
