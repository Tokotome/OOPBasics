namespace WildFarm.FoodClasses
{
    using System;
    public class Vegetable : Food
    {
        public const string Type = "Vegetable";

        public Vegetable(int quantity)
            :base(Type, quantity)
        {
        }
    }
}
