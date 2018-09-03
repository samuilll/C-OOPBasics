using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
  public abstract  class Product
    {


        private double price;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get { return price; }

          protected  set
            {
                if (value<0)
                {
                    throw new InvalidOperationException(Constants.PriceCannotBeNegativeOperationException);
                }
                price = value;
            }
        }

        public double Weight { get;}

    }
}
