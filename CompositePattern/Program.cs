using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CompositePattern
{

    public class GraphicalObject
    {
        private Lazy<List<GraphicalObject>> _children = new Lazy<List<GraphicalObject>>();

        public virtual string Name { get; set; } = "Group";
        public string Color { get; set; }

        public List<GraphicalObject> Children => _children.Value;

        public override string ToString()
        {
            var stringBuild = new StringBuilder();

            Print(stringBuild, 0);

            return stringBuild.ToString();

        }

        private void Print(StringBuilder stringBuild, int depth)
        {
            stringBuild.Append(new string('*', depth))
                .Append(string.IsNullOrEmpty(Color) ? string.Empty : $"{Color} ")
                .AppendLine($"{Name} ");

            foreach (var child in Children)
                child.Print(stringBuild, depth + 1);
        }
    }

    public class Circle : GraphicalObject
    {
        public override string Name => "Circle";
    }

    public class Square : GraphicalObject
    {
        public override string Name => "Square";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var drawing = new GraphicalObject { Name = "My Drawing" };
            drawing.Children.Add(new Square() { Color = "Red" });
            drawing.Children.Add(new Circle() { Color = "Yellow" });

            var group = new GraphicalObject() { Name = "Group" };
            group.Children.Add(new Square() { Color = "Blue" });
            group.Children.Add(new Square() { Color = "Blue" });

            drawing.Children.Add(group);


            Console.WriteLine(drawing);

            Console.ReadKey();


        }
    }
}
