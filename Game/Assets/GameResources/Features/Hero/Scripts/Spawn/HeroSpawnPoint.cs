using BattleArena.Infrastructure.Services.GameFactory;
using UnityEngine;
using Zenject;

public class HeroSpawnPoint : MonoBehaviour
{
    private IGameFactory _gameFactory = default;

    [Inject]
    private void Constructor(IGameFactory gameFactory) => 
        _gameFactory = gameFactory;

    private async void Start() =>
        await _gameFactory.CreateHeroAsync(transform.position);
}
