using BattleArena.Infrastructure.Services.PersistentData;

namespace BattleArena.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void LoadProgress();
        void SaveProgress();

        void SaveProgressByType<T>(T type = null) where T : class, IProgress;
    }

    public interface ISavedProgressReader
    {
        public void LoadProgress(IPersistentProgressService progressData);
    }

    public interface ISavedProgress : ISavedProgressReader
    {
        public void UpdateProgress(IPersistentProgressService progressData);
    }
}

