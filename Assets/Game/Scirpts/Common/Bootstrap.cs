using System;
using NUnit.Framework;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemyManager manager;
    [SerializeField] private PlayerAbilityManager playerManager;

    private void Awake()
    {
        Initialize(player);
        Initialize(manager);
        Initialize(playerManager);
    }

    private void Initialize<T>(T service) where T : IService
    {
        if(service == null) return;

        ServiceLocator.Register(service);
        service.Execute();
    }
}
