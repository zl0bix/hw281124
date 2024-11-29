using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw281124
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                        Пользователь запускает приложение и перед ним находится меню, в котором он может выбрать,
                        к какому вольеру подойти.При приближении к вольеру, пользователю выводится информация о том, что это за вольер, сколько
                        животных там обитает, их пол и какой звук издает животное.
                        Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера.
                        */

            Valliere zoo = new Valliere();

            zoo.CreateZoo();
            zoo.ShowZoo();
        }
    }


    class Valliere
    {
        public List<Animals> _zoo = new List<Animals>();

        public void CreateZoo() 
        {
            Horse horse = new Horse();
            Rabbit rabbit = new Rabbit();
            Pig pig = new Pig();

            _zoo.Add(horse);
            _zoo.Add(rabbit);
            _zoo.Add(pig);
        }

        public void ShowZoo()
        {
            foreach(Animals it in _zoo)
            {
                it.ActionAnimal();
            }
        }

    }
    abstract class Animals
    {
        public string _name { get; private set; }

        public Animals(string name)
        {
            _name = name;
        }

        public virtual void ActionAnimal()
        {
            Console.WriteLine($"{_name} что-то делает!!! переписать в наследуемых классах");
        }
    }

    class Horse : Animals
    {
        public Horse() : base("Лошадь") { }
        
        public override void ActionAnimal()
        {
            Console.WriteLine($"{_name} фыркает и ржет!!!");
        }
    }

    class Rabbit : Animals
    {
        public Rabbit() : base("Кролик") { }

        public override void ActionAnimal()
        {
            Console.WriteLine($"{_name} топает!!!");
        }
    }

    class Pig : Animals
    {
        public Pig() : base("Свинья") { }

        public override void ActionAnimal()
        {
            Console.WriteLine($"{_name} хрюкает!!!");
        }
    }

}
