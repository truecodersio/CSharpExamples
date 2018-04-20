using System;

namespace CSharpExamples
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public abstract void MakeSound();
        public virtual void SayName()
        {
            Console.WriteLine($"My name is: {Name}");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Bark!!");
        }

        public override void SayName()
        {
            Console.WriteLine($"Bark bark! My name is: {Name}");
        }
    }
}
