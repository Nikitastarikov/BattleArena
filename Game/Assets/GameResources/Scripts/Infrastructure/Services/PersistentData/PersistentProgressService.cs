namespace BattleArena.Infrastructure.Services.PersistentData
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public HeroState HeroState { get; set; }
        public PositionOnLevel PositionOnLevel { get; set; }
    }
}

