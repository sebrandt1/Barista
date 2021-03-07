using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Barista.CoffeeTypes;

namespace Barista.Builder
{
    public abstract class Coffee : IBeverage, IBeverageBuildStageOne, IBeverageBuildStageTwo, IBeverageBuildStageThree, IBeverageBuildStageFour, IBeverageBuildStageFive
    {
        //Private fields over protected, inheriting classes should not have access to these, they only need to know the value
        private Bean _bean;
        private int _milk;
        private int _water;
        private int _temperature;
        private bool _milkFoam;
        private bool _isGround;
        private CupSize _size;

        //public properties so inheriting classes can find out what its own values are
        public Bean Bean => this._bean;
        public int Milk => this._milk;
        public int Water => this._water;
        public int Temperature => _temperature;
        public bool IsGround => _isGround;
        public bool HasMilkFoam => _milkFoam;
        public CupSize Size => this._size;


        public IBeverage Init()
        {
            return this;
        }

        public IBeverageBuildStageOne AddWater(int amt)
        {
            this._water += amt;
            return this;
        }

        public IBeverageBuildStageTwo AddBean(Bean bean)
        {
            this._bean = bean;
            return this;
        }
        
        public IBeverageBuildStageThree GrindBeans()
        {
            if (this._bean != null)
            {
                this._isGround = true;
                return this;
            }
            throw new NullReferenceException("Could not grind beans because no beans have been added.");
        }

        public IBeverageBuildStageFour AddMilk(int amt)
        {
            this._milk += amt;
            return this;
        }

        public IBeverageBuildStageFive AddMilkFoam()
        {
            this._milkFoam = true;
            return this;
        }

        public Coffee Validate(int temp)
        {
            this._temperature = temp;
            if (temp == 86) return this as Espresso;
            if (temp == 89) return this as Americano;
            if (temp == 90) return this as Macchiato;
            if (temp == 94) return this as Latte;
            if (temp == 95) return this as Mocha;
            if (temp == 99) return this as Cappuccino;
            return this as CustomCoffee;
        }

        public override string ToString()
        {
            string milk = _milk > 0 ? $" with {_milk}cl of milk" : string.Empty;
            string milkFoam = _milkFoam ? " and milk foam" : "";
            string coffeeType = this.GetType().Name;
            string prefix = (coffeeType.ToLower()[0] == 'a' ||
                            coffeeType.ToLower()[0] == 'e' ||
                            coffeeType.ToLower()[0] == 'i' ||
                            coffeeType.ToLower()[0] == 'o' ||
                            coffeeType.ToLower()[0] == 'u' ||
                            coffeeType.ToLower()[0] == 'y') ? "an" : "a"; 

            return $"This coffee contains {this._water}cl of water, {this._bean.Grams}g of {this._bean.BeanType} beans{milk}{milkFoam} and is {prefix} {coffeeType}";
        }
    }
}
