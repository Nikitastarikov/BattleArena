using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _player;

    public override void InstallBindings()
    {
        Container.InstantiatePrefab(_player, _spawnPoint.position, Quaternion.identity, null);
    }
}