using System;
using System.Collections.Generic;
using System.Text;


public class Dough
{

    private string flourType;

    private string FlourType
    {
        get { return flourType; }

         set
        {
            if (value.ToLower() != "wholegrain" && value.ToLower() != "white")
            {
                throw new ArgumentException(ExceptionMessages.InvalidDoughType);
            }
            flourType = value;
        }
    }

    private string bakingTechnique;

    private string BakingTechnique
    {
        get { return bakingTechnique; }

         set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException(ExceptionMessages.InvalidDoughType);
            }
            bakingTechnique = value;
        }
    }
    private double weight;

    private double Weight
    {
        get { return weight; }

        set
        {
            if (!(value>=1 && value<=200))
            {
                throw new ArgumentException(ExceptionMessages.InvalidDoughWeight);
            }
            weight = value;
        }
    }

    public Dough(string type, string technique, double weight)
    {
        this.FlourType = type;
        this.BakingTechnique = technique;
        this.Weight = weight;
    }

    public double GetTheCalories()
    {

        double flourModifier = this.FlourType.ToLower() == "white" ? 1.5 : 1.0;

        double techniqueModifier = this.BakingTechnique.ToLower() == "crispy" ? 0.9 : this.BakingTechnique.ToLower() == "chewy" ? 1.1 : 1.0;

        return 2 * this.Weight * flourModifier * techniqueModifier;
    }


}

