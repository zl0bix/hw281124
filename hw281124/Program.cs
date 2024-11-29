using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw281124
{
    
    internal class Program
    {
        public static Random _rnd = new Random();
        static void Main(string[] args)
        {
                        /*
                        Пользователь запускает приложение и перед ним находится меню, в котором он может выбрать,
                        к какому вольеру подойти.При приближении к вольеру, пользователю выводится информация о том, что это за вольер, сколько
                        животных там обитает, их пол и какой звук издает животное.
                        Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера.
                        */            
            ExecutionProgram program = new ExecutionProgram();

            program.StartProgram();

        }
    }


    class ExecutionProgram
    {
        PaddockOne one = new PaddockOne();
        PaddockTwo two = new PaddockTwo();
        PaddockTree tree = new PaddockTree();
        PaddockFour four = new PaddockFour();
        public void StartProgram()
        {
            one.CreateZoo();
            two.CreateZoo();
            tree.CreateZoo();
            four.CreateZoo();

            string logOut = "exit";
            string strCoice = "";
            int numChoice = 0;

            Console.WriteLine("\n\n\n\t\tВы подходите ближе и видите четыре вольера...\n\t\tПожалуйста подождите");
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
            while (strCoice.ToLower() != logOut) 
            { 
            Drow(ref strCoice, ref logOut, ref numChoice);
            Coice(ref numChoice);

            System.Threading.Thread.Sleep(1500);

            Console.Clear() ;              
            }
        }

        private void Drow(ref string str1, ref string str2, ref int num)
        {
            do
            {
                Console.Write("\n\n\n\t\tСделайте выбор:\n\t\t1: Подойти к первому вольеру\n\t\t2: Подойти к второму вольеру\n\t\t3: Подойти к третьему вольеру\n\t\t4: Подойти к четвертому вольеру\n\t\tВаш выбор -> ");

                str1 = Console.ReadLine();

                Console.Clear();
            }
            while (!int.TryParse(str1, out num) && str2 != str1.ToLower());
        }

        private void Coice(ref int num)
        {
            switch(num)
            {
                case 1:
                    Console.Clear();
                    one.ShowZoo();
                   
                    break;

                case 2:
                    Console.Clear();
                    two.ShowZoo();
                    break;

                case 3:
                    Console.Clear();
                    tree.ShowZoo();
                    break;

                case 4:
                    Console.Clear();
                    four.ShowZoo();
                    break;

                    default:
                    Console.Clear();
                    //Console.WriteLine("\n\n\n\t\tОшибка ввода!!!");
                    break;

            }
        }
    }

    abstract class Valliere
    {
        public List<Animals> _zoo = new List<Animals>();

        public void CreateZoo() 
        { 
            Horse horse = new Horse();
            Rabbit rabbit = new Rabbit();
            Pig pig = new Pig();

            int num = Program._rnd.Next(5,26);

            while (num != 0)
            {
                if (Program._rnd.Next(1, 4) == 1)
                
                    _zoo.Add(horse.ReturnAnimals());
                
                else if(Program._rnd.Next(1, 4) == 2)
                
                    _zoo.Add(rabbit.ReturnAnimals());
                
                else

                    _zoo.Add(pig.ReturnAnimals());

                num--;
            }
        }
       
        public void ShowZoo()
        {
            Console.WriteLine($"Животных в этом вольере {_zoo.Count}"); 

            foreach (Animals it in _zoo)
            {
                it.ActionAnimal();

                System.Threading.Thread.Sleep(190);
            }
        }

    }
    abstract class Animals
    {
        //public static Random _rnd = new Random();
        public string _name { get; private set; }

        public string _sex { get; private set; }

        public Animals(string name, string sex)
        {
            _name = name;
            _sex = sex;
        }

        public static string GetSex()
        {                      
            if (Program._rnd.Next(1, 3) == 1)
            
                return "male";
            
            else

                return "female";
        }

        public virtual void ActionAnimal()
        {
            Console.WriteLine($"{_name} что-то делает!!! переписать в наследуемых классах");
        }

        public virtual Animals ReturnAnimals()
        {
            Animals animals = null;

            return animals;
        }
    }

    class Horse : Animals
    {
        public Horse() : base("Лошадь",  GetSex()) { }
        
        public override void ActionAnimal()
        {
            Console.WriteLine($"{_name} пол {_sex} животное фыркает и ржет!!! ");
        }

        public override Animals ReturnAnimals()
        {
            return new Horse(); 
        }
    }

    class Rabbit : Animals
    {
        public Rabbit() : base("Кролик", GetSex()) { }

        public override void ActionAnimal()
        {
            Console.WriteLine($"{_name} пол {_sex} животное топает!!!");
        }
        public override Animals ReturnAnimals()
        {
            return new Rabbit();
        }
    }

    class Pig : Animals
    {
        public Pig() : base("Свинья", GetSex()) { }

        public override void ActionAnimal()
        {
            Console.WriteLine($"{_name} пол {_sex} животное хрюкает!!!");
        }
        public override Animals ReturnAnimals()
        {
            return new Pig();
        }
    }

    class PaddockOne : Valliere
    {

    }

    class PaddockTwo : Valliere
    {

    }

    class PaddockTree : Valliere
    {

    }

    class PaddockFour : Valliere
    {

    }
}
