using System;
using System.Collections.Generic;
using System.Text;


    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; private set; }
        public void CompleteMission(string codeName)
        {
            throw new System.NotImplementedException();
        }

        public void AddMission(Mission mission)
        {
            this.Missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(base.ToString());
            builder.Append("\nMissions:");
            foreach (var mission in Missions)
            {
                builder.Append(Environment.NewLine+mission);
            }

            return builder.ToString();
        }
    }
