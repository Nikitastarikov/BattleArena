using BattleArena.Infrastructure.InputService;
using BattleArena.Infrastructure.Services.Assets;
using BattleArena.Infrastructure.Services.SaveLoad;
using BattleArena.Infrastructure.Services.StaticData;
using BattleArena.StaticData;
using Scripts.Hero;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BattleArena.Infrastructure.Services.GameFactory
{
    public interface IGameFactory
    {
        public Task<GameObject> CreateHeroAsync(Vector3 at);
    }

    public class GameFactory : IGameFactory
    {
        private readonly IInputService _inputService;
        private readonly IAssets _assets;

        public GameFactory(IAssets assets, IInputService inputService)
        {
            _assets = assets;
            _inputService = inputService;
        }

        public async Task<GameObject> CreateHeroAsync(Vector3 at)
        {
            GameObject hero = await _assets.Instantiate(AssetAdresses.HERO, at);
            hero.GetComponent<HeroMove>().Constructor(_inputService);
            hero.GetComponent<HeroLook>().Constructor(_inputService);
            
            return hero;
        }
    }
}
