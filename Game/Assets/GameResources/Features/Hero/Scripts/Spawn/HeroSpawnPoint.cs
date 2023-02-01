using BattleArena.Infrastructure.Services.GameFactory;
using UnityEngine;
using Zenject;

public class HeroSpawnPoint : MonoBehaviour
{
    private GameFactory _gameFactory = default;

    [Inject]
    private void Constructor(GameFactory gameFactory) => 
        _gameFactory = gameFactory;

    private async void Start() => 
        await _gameFactory.CreateHeroAsync(transform.position);
}
