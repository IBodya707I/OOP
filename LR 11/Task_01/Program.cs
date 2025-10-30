namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;
    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            while(true)
            {
                string command = Console.ReadLine();
                if (command == "HARVEST")
                {
                    break;
                }
                switch(command.ToLower())
                {
                    case "private":
                        foreach(var f in fields)
                        {
                            if(f.IsPrivate)
                            {
                                Console.WriteLine("private " + f.FieldType.Name + " " + f.Name);
                            }
                        }
                        break;
                    case "protected":
                        foreach(var f in fields)
                        {
                            if(f.IsFamily)
                            {
                                Console.WriteLine("protected " + f.FieldType.Name + " " + f.Name);
                            }
                        }
                        break;
                    case "public":
                        foreach(var f in fields)
                        {
                            if(f.IsPublic)
                            {
                                Console.WriteLine("public " + f.FieldType.Name + " " + f.Name);
                            }
                        }
                        break;
                    case "all":
                        foreach(var f in fields)
                        {
                            if (f.IsPublic)
                            {
                                Console.WriteLine("public " + f.FieldType.Name + " " + f.Name);
                            }
                            if (f.IsFamily)
                            {
                                Console.WriteLine("protected " + f.FieldType.Name + " " + f.Name);
                            }
                            if (f.IsPrivate)
                            {
                                Console.WriteLine("private " + f.FieldType.Name + " " + f.Name);
                            }
                        }
                        break;
                }
            }
        }
    }
}