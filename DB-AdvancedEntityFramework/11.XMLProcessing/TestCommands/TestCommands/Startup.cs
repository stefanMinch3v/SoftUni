
namespace TestCommands
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class Startup
    {
        public static void Main()
        {
            //string str =
            //@"<?xml version=""1.0""?>
            //<!-- comment at the root level -->
            //<Root>
            //    <Child>Content</Child>
            //</Root>";
            //XDocument doc = XDocument.Parse(str);
            //System.Console.WriteLine(doc);

            XDocument xmlDoc = XDocument.Load(@"../../../cars.xml");
            //System.Console.WriteLine(xmlDoc);

            //var cars = xmlDoc.Root.Elements();
            //foreach (var car in cars)
            //{
            //    string make = car.Element("make").Value;
            //    string model = car.Element("model").Value;
            //    Console.WriteLine($"{make} {model}");
            //}

            //var cars = xmlDoc.Root.Elements()
            //  .Where(e => e.Element("make").Value == "Opel" &&
            //              (long)e.Element("travelled-distance") >= 300000)
            //  .Select(c => new
            //  {
            //      Model = c.Element("model").Value,
            //      Traveled = c.Element("travelled-distance").Value
            //  })
            //  .ToList();
            //foreach (var car in cars)
            //{
            //    Console.WriteLine(car.Model + " " + car.Traveled);
            //}

            XDocument xmlDocs = new XDocument();
            xmlDocs.Add(
              new XElement("books",
                new XElement("book",
                  new XElement("author", "Don Box"),
                  new XElement("title", "ASP.NET", new XAttribute("lang", "en"))
            )));

            Console.WriteLine(xmlDocs);
        }
    }
}
