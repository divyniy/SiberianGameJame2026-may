using System;
using NUnit.Framework;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Awake()
    {
        Initialize(player);
    }

    private void Initialize<T>(T service) where T : IService
    {
        if(service == null) return;

        ServiceLocator.Register(service);
        service.Execute();
    }
}
