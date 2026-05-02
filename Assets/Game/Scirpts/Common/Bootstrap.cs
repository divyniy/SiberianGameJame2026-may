using System;
using NUnit.Framework;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemyManager manager;
    [SerializeField] private PlayerAbilityManager playerManager;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private ChunkController chunk;
    [SerializeField] private SessionManager game;


    private void Awake()
    {
        ServiceLocator.Clear();

        Initialize(itemManager);

        Initialize(player);
        Initialize(manager);
        Initialize(playerManager);
        Initialize(chunk);
        Initialize(game);
    }

    private void StartGame()
    {
        
    }

    private void Initialize<T>(T service) where T : IService
    {
        if(service == null) return;

        ServiceLocator.Register(service);
        service.Execute();
    }
}
