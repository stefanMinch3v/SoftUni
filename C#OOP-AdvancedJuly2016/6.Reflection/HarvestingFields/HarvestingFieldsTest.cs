namespace HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (input != "HARVEST")
            {
                var fields = typeof(HarvestingFieldsClass).GetFields();

                switch (input)
                {
                    case "private":
                        fields = typeof(HarvestingFieldsClass).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                        
                        foreach (var field in fields)
                        {
                            if (field.IsPrivate)
                            {
                                var correctFieldType = field.FieldType.FullName.ToString().Split(new[] {'.'}).Last();
                                Console.WriteLine($"private {correctFieldType} {field.Name}");
                            }   
                        }

                        break;
                    case "public":
                        foreach (var field in fields)
                        {
                            var correctFieldType = field.FieldType.FullName.ToString().Split(new[] { '.' }).Last();
                            Console.WriteLine($"public {correctFieldType} {field.Name}");
                        }
                        break;
                    case "protected":
                        fields = typeof(HarvestingFieldsClass).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

                        foreach (var field in fields)
                        {
                            if (field.IsFamily)
                            {
                                var correctFieldType = field.FieldType.FullName.ToString().Split(new[] { '.' }).Last();
                                Console.WriteLine($"protected {correctFieldType} {field.Name}");
                            }
                        }

                        break;
                    case "all":
                        fields = typeof(HarvestingFieldsClass).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                        foreach (var field in fields)
                        {
                            var correctFieldType = field.FieldType.FullName.ToString().Split(new[] { '.' }).Last();
                            var correctFieldsAccessibility = field.Attributes.ToString().ToLower().Replace("family", "protected");
                            Console.WriteLine($"{correctFieldsAccessibility} {correctFieldType} {field.Name}");
                        }

                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
