using BattleArena.Enemy.Data;
using BattleArena.Enemy.StaticData;
using BattleArena.StaticData;

namespace BattleArena.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        LevelStaticData ForLevel(string sceneKey);
        MonsterStaticData ForMonster(MonsterTypeId typeId);
        //WindowConfig ForWindow(WindowId shop);
        void LoadMonsters();
    }
}
