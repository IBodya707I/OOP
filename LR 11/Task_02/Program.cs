namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;
    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, Type.EmptyTypes);
            BlackBoxInteger box = (BlackBoxInteger)constructor.Invoke(null);
            FieldInfo field = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);  
            while (true)
            {
                string[] text = Console.ReadLine().Split("_");
                if (text[0].ToLower() == "end")
                    break;
                MethodInfo method = type.GetMethod(text[0], BindingFlags.Instance | BindingFlags.NonPublic);
                int x = int.Parse(text[1]);
                method.Invoke(box, new object[] { x });
                Console.WriteLine(field.GetValue(box));
            }
        }
    }
}