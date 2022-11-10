using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree tree = new ChristmasTree(2);
            ChristmasDecoration decor1 = new ChristmasDecoration("blue", "bulbs");
            Garland decor2 = new Garland(2.25);

            // Link decorators
            decor1.SetComponent(tree);
            decor2.SetComponent(decor1);

            decor2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ChristmasTree"
    class ChristmasTree : Component
    {
        public double height;     //in meter
        public ChristmasTree(double h) { height = h;  }
        public override void Operation()
        {
            Console.WriteLine($"The {height}-meter christmas tree was installed.");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ChristmasDecoration"
    class ChristmasDecoration : Decorator
    {
        private string decoration;
        public string color;

        public ChristmasDecoration (string c, string d) { color= c; decoration = d; }
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine($"Christmas tree was decorated with {color} {decoration}.");
        }
    }

    // "Garland" 
    class Garland : Decorator
    {
        public double length;   //in meter
        public Garland (double l) { length = l; }
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine($"Christmas tree was decorated with a {length}-meter garland.");
            Lighting();
        }
        void Lighting ()
        {
            Console.WriteLine("Christmas tree lights up.");
        }
    }
}