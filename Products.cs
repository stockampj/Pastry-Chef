using System;
using System.Collections.Generic;

namespace Products
{
  public class Product
  {
    public string Name { get; private set; }
    public float Cost { get; private set; }
    public string Type { get; private set; }

    public Product (string name, float cost, string type)
    {
      Name = name; 
      Cost = cost;
      Type = type;
    }

  }

}