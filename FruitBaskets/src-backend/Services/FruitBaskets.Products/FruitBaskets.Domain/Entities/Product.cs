﻿namespace FruitBaskets.Domain
{

    public class Product:Entity
    {
        public required string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
