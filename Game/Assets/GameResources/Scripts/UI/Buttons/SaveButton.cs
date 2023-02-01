using BattleArena.Infrastructure.Services.PersistentData;
using BattleArena.Infrastructure.Services.SaveLoad;
using Zenject;

namespace UI
{
    public class SaveButton : AbstractButtonView
    {
        private ISaveLoadService _saveLoadService = default;

        [Inject]
        private void Constructor(ISaveLoadService saveLoadService) => 
            _saveLoadService = saveLoadService;

        protected override void OnButtonClick() => 
            _saveLoadService.SaveProgressByType<HeroState>();
    }
}
