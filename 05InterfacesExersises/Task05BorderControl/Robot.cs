
using System;

public class Robot:IDetainable
    {
        private string Model { get; set; }
        public string Id { get; private set; }
      

        public Robot(string model, string id)
        {
        this.Model = model;
        this.Id = id;
        }

        public bool IsDetained(string id)
        {
            if (this.Id.LastIndexOf(id)==this.Id.Length - id.Length)
            {
                return true;
            }

            return false;
        }
}
