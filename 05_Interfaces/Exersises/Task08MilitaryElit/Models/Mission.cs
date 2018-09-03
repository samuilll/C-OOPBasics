
using System;

public class Mission : IMission
{
    public string CodeName { get; private set; }

    private string state;

    public string State
    {
        get { return this.state; }
        private set
        {
            if (value != "inProgress" && value != "Finished")
            {
                throw new ArgumentException("Invalid Mission");
            }

            this.state = value;
        }
    }

public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}
