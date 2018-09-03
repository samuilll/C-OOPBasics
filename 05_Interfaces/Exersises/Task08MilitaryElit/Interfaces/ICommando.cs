
using System.Collections.Generic;

public interface ICommando : ISpecializedSoldier
{
    List<Mission> Missions { get; }

    void CompleteMission(string codeName);

    void AddMission(Mission mission);
}
