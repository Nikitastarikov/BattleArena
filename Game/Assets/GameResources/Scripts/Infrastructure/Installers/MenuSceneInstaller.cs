using BattleArena.Infrastructure.Services.PersistentData;
using BattleArena.Infrastructure.Services.SaveLoad;
using Zenject;

namespace Infrastructure.Installers
{
    public class MenuSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPersistentProgressService();
            BindSaveLoadService();
        }


        private void BindSaveLoadService()
        {
            Container.Bind<ISaveLoadService>().
                        To<SaveLoadService>().
                        AsSingle();
        }

        private void BindPersistentProgressService()
        {
            Container.Bind<IPersistentProgressService>().
                        To<PersistentProgressService>().
                        AsSingle();
        }
    }
}