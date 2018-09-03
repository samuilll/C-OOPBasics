
using System.Collections.Generic;

public interface IEngineer : ISpecializedSoldier
{
    List<Repair> Repairs { get; }

    void AddReapir(Repair repair);
}
