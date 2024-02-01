using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppBuilderExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MealBuilder builder;

            Restaurant restaurant = new Restaurant();

            builder = new FamilyFeast();
            restaurant.Construct(builder);
            builder.Meal.Show();

            builder = new BuddyMeal();
            restaurant.Construct(builder);
            builder.Meal.Show();

            builder = new VegFarm();
            restaurant.Construct(builder);
            builder.Meal.Show();
        }
    }
    class Meal
    {
        private string _mealType;
        private Dictionary<string, string> _dishes = new Dictionary<string, string>();
        public Meal(string mealType)
        {
            this._mealType = mealType;
        }
        public string this[string key]
        {
            get { return _dishes[key]; }
            set { _dishes[key] = value; }
        }
        public void Show()
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Meal Type: {0}", _mealType);
            Console.WriteLine(" Burger : {0}", _dishes["bruger"]);
            Console.WriteLine(" Drink : {0}", _dishes["drink"]);
            Console.WriteLine(" Desert : {0}", _dishes["desert"]);
            Console.WriteLine(" Toy : {0}", _dishes["toy"]);
        }
    }
    abstract class MealBuilder
    {
        protected Meal meal;

        public Meal Meal
        {
            get { return meal; }
        }
        //Abstract build methods
        public abstract void CookBurger();
        public abstract void FillDrink();
        public abstract void PrepareDesert();
        public abstract void UnwrapToy();
    }
    class Restaurant
    {
        public void Construct(MealBuilder mealBuilder)
        {
            mealBuilder.CookBurger();
            mealBuilder.FillDrink();
            mealBuilder.PrepareDesert();
            mealBuilder.UnwrapToy();
        }
    }
    class FamilyFeast : MealBuilder
    {
        public FamilyFeast()
        {
            meal = new Meal("FamilyFeast");
        }
        public override void CookBurger()
        {
            meal["bruger"] = "Chicken Zinger";
        }
        public override void FillDrink()
        {
            meal["drink"] = "Coke";
        }
        public override void PrepareDesert()
        {
            meal["desert"] = "Chicken Popcorn";
        }
        public override void UnwrapToy()
        {
            meal["toy"] = "Car";
        }
    }
    class BuddyMeal : MealBuilder
    {
        public BuddyMeal()
        {
            meal = new Meal("BuddyMeal");
        }
        public override void CookBurger()
        {
            meal["bruger"] = "Signature Chicken Burger";
        }
        public override void FillDrink()
        {
            meal["drink"] = "Pepsi";
        }
        public override void PrepareDesert()
        {
            meal["desert"] = "Chicken Nuggets";
        }
        public override void UnwrapToy()
        {
            meal["toy"] = "Iron-Man";
        }
    }
    class VegFarm : MealBuilder
    {
        public VegFarm()
        {
            meal = new Meal("VegFarm");
        }
        public override void CookBurger()
        {
            meal["bruger"] = "Veg Maharaja Burger";
        }
        public override void FillDrink()
        {
            meal["drink"] = "Mirinda";
        }
        public override void PrepareDesert()
        {
            meal["desert"] = "Chocolate Lava Cake";
        }
        public override void UnwrapToy()
        {
            meal["toy"] = "Barbie set";
        }
    }
}
