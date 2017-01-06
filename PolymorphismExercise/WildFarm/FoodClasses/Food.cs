namespace WildFarm.FoodClasses
{
    using System;
    public abstract class Food
    {
        private int quantity;
        private string type;

        protected Food(string type, int quantity)
        {
            this.type = type;
            this.quantity = quantity;
        }
        public int Quantity => this.quantity;
        public string Type => this.type;
    }
}
