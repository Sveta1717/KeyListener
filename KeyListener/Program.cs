using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KeyListener
{
    internal class KeyListener
    {
        public delegate void MethodKey();
        public event MethodKey PressedKey;

        public void Listen()
        {
            Person person = new Person();
            ConsoleKey key;
            while (true)
            {
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine("Enter");
                        PressedKey += person.Select;
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Escape");                   
                        PressedKey += person.Escape;
                        break ; 
                    case ConsoleKey.F1:
                        Console.WriteLine("F1");
                        PressedKey += person.F;
                        break;
                    case ConsoleKey.Spacebar:
                        Console.WriteLine("Space");
                        PressedKey += person.Jump;
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("Left");
                        PressedKey += person.Move_Left;
                        break ;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine("Right");
                        PressedKey += person.Move_Right;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("Down");
                        PressedKey += person.Move_Down;
                        break;
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("Up");
                        PressedKey += person.Move_Up;
                        break;                   
                }
                PressedKey.Invoke();
            }
        }

        private void KeyListener_PressedKey()
        {
            throw new NotImplementedException();
        }
    }

    class Person 
        {       
        public void Jump()
        {
            Console.WriteLine("Скок-скок!");
        }
        public void Select()
        {
            Console.WriteLine("Зробить свiй вибiр"); 
        }
        public void F()
        {
            Console.WriteLine("Падаємо!");
        }
        public void Move_Left()
        {
            Console.WriteLine("Повертаемось влiво");
        }
        public void Move_Right()
        {
            Console.WriteLine("Повертаемось вправо");
        }
        public void Move_Up()
        {
            Console.WriteLine("Йдемо вперед");
        }
        public void Move_Down()
        {
            Console.WriteLine("Йдемо назад");
        }
        
        public void Escape()
        {
            Environment.Exit(0);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 Enter\n2 F1\n3 Space\n4 ->\n5 <-\n6 Вверх\n7 Низ\n8 Вихiд");            

            KeyListener listener = new KeyListener();            
            listener.Listen();
        }       
    }    
}
