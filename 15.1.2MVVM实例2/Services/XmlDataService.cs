using _15._1._2MVVM实例2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _15._1._2MVVM实例2.Services
{
    class XmlDataService : IDataService
    {
        public List<Dish> GetAllDishes()
        {
            List<Dish> dishList = new List<Dish>();
            string xmlFile = Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
            XDocument xDoc = XDocument.Load(xmlFile);
            var dishs = xDoc.Descendants("Dish");
            foreach (var item in dishs)
            {
                dishList.Add(new Dish() 
                { 
                    Name = item.Element("Name").Value,
                    Category = item.Element("Category").Value,
                    Comment = item.Element("Comment").Value,
                    Score = double.Parse(item.Element("Score").Value)
                });
            }
            return dishList;
        }
    }
}
