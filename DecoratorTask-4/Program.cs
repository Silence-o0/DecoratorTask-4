using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree tree = new ChristmasTree();
            ChristmasDecoration decor1 = new ChristmasDecoration();
            Garland decor2 = new Garland();

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
        public override void Operation()
        {
            Console.WriteLine("The christmas tree was installed.");
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

        public override void Operation()
        {
            base.Operation();
            decoration = "Christmas tree decoration.";
            Console.WriteLine($"Christmas tree was decorated with {decoration}");
        }
    }

    // "Garland" 
    class Garland : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("Christmas tree was decorated with garland");
        }
        void AddedBehavior()
        {
            Console.WriteLine("Christmas tree lights up.");
        }
    }
}