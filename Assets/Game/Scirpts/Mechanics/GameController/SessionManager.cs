using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class SessionManager : MonoBehaviour, IService
{
    [SerializeField] private TMP_Text text;
    public Wave[] waves;
    private EnemyManager manager;

    private float timer;
    public static bool isPlaying {get; private set;}
    public void Execute()
    {
        StartGame();
    }
    private void StartGame()
    {
        isPlaying = true;
        timer = 0;

        manager = ServiceLocator.Get<EnemyManager>();
    }
    private void Update()
    {
        if(isPlaying)
        {
            timer += Time.deltaTime;
            Wave currentWave = waves.FirstOrDefault(x => x.time == Mathf.RoundToInt(timer));

            DisplayTime();

            if(currentWave != null)
            {
                manager.Spawn(currentWave.amount, currentWave.radius);
                waves = waves.Where(x => x != currentWave).ToArray();
            }
        }
    }
    private void DisplayTime()
    {
        string minutes = (Mathf.RoundToInt(timer)/60).ToString();
        string seconds = (Mathf.RoundToInt(timer)%60).ToString();

        if(Convert.ToInt16(seconds) < 10) seconds = $"0{seconds}";

        text.text = $"{minutes}:{seconds}";
    }
}

[System.Serializable]
public class Wave
{
    public int amount;
    public int time;
    public int radius;
}
