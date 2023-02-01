using BattleArena.Infrastructure.InputService;
using BattleArena.Infrastructure.Services.Assets;
using BattleArena.Infrastructure.Services.GameFactory;
using Scripts.Hero;
using System;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class TestSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAssets();
            BindInputService();
            BindGameFactory();
        }

        private void BindAssets() => 
            Container.Bind<IAssets>().
            To<AssetProvider>().AsSingle();

        private void BindGameFactory() => 
            Container.Bind<GameFactory>().AsSingle();

        private void BindInputService() => 
            Container.Bind<IInputService>().
            To<InputService>().AsSingle();
    }
}