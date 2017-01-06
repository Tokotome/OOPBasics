namespace WildFarm.FoodClasses
{
    using System;
    
    public class Meat : Food
    {
        public const string Type = "Meat";

        public Meat(int quantity)
            : base(Type, quantity)
        {
        }
    }
}
