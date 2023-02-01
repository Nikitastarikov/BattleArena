namespace BattleArena.Infrastructure.Services.PersistentData
{
    public interface IPersistentProgressService
    {
        HeroState HeroState { get; set; }
        PositionOnLevel PositionOnLevel { get; set; }
    }
}

