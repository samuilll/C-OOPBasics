
    using System.Collections.Generic;

public interface ILeutanantGeneral:IPrivate
    {
        List<Soldier> Privates { get; }

        void AddPrivate(Soldier soldier);
    }
