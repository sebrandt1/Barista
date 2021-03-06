using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Barista.Builder;
using Barista.CoffeeTypes;

namespace Barista
{
    class Program
    {
        static void Main(string[] args)
        {
            IBeverage coffee = new Latte().Init()
                .AddWater(40)
                .AddBean(new Bean()
                {
                    BeanType = BeanType.Arabica,
                    Grams = 18
                }).GrindBeans()
                .AddMilk(15)
                .AddMilkFoam()
                .Validate(94);

            IBeverage coffee2 = new Espresso().Init()
                .AddWater(25)
                .AddBean(new Bean()
                {
                    BeanType = BeanType.Robusta,
                    Grams = 15
                }).GrindBeans()
                .Validate(86);

            Console.WriteLine(coffee.ToString());
            Console.WriteLine(coffee2.ToString());
            Console.ReadKey();
        }
    }
}
