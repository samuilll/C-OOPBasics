using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public abstract  class Monument
    {
    protected Monument(string name)
    {
       this. Name = name;
    }

    public string Name { get;protected set; }

    public abstract int GetAffinityPower();
}

