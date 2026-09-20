using Session01LinqG01.DataSources;
using Session01LinqG01.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace LINQ1
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            var PList = Source.ProductList;
            var CList = Source.CustomerList;

            #region Q1

            var SeaFoodProducts = PList.Where(p => p.Category == "Seafood");

            foreach (var product in SeaFoodProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName} Price: {product.UnitPrice}");
            }

            #endregion

            #region Q2

            var Names = PList.Select(p => p.ProductName);
            Console.WriteLine($"\n ------ All Product Names ------ \n");

            foreach (var name in Names)
            {
                Console.WriteLine($"{name}");
            }

            #endregion

            #region Q3

            var sortedByPrice = PList.OrderBy(p => p.UnitPrice);
            Console.WriteLine($"\n ------ Products Sorted By Price ------ \n");


            foreach (var product in sortedByPrice)
            {
                Console.WriteLine($"Product Name: {product.ProductName} Price: {product.UnitPrice}");
            }


            #endregion

            #region Q4

            var bet10And30 = PList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            Console.WriteLine($"\n ------ Products Between 10 and 30 ------ \n");


            foreach (var product in bet10And30)
            {
                Console.WriteLine($"Product Name: {product.ProductName} Price: {product.UnitPrice}");
            }



            #endregion

            #region Q5

            var inStockCondiments = PList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
            Console.WriteLine($"\n ------ Condiments in stock ------ \n");


            foreach (var product in inStockCondiments)
            {
                Console.WriteLine($"Product Name: {product.ProductName} Price: {product.UnitPrice}");
            }


            #endregion

            #region Q6

            var anoType = PList.Select(p => new
            {
                name = p.ProductName,
                price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            Console.WriteLine($"\n ------ Ano Type ------ \n");


            foreach (var product in anoType)
            {
                Console.WriteLine($"Product Name: {product.name} Price: {product.price} Status: {product.StockStatus}");
            }


            #endregion

            #region Q7
            var orderedList = PList.Select((p, index) => new
            {

                position = index + 1,
                name = p.ProductName

            });
            Console.WriteLine($"\n ------ Ordered List ------ \n");

            foreach (var product in orderedList)
            {
                Console.WriteLine($"{product.position}. {product.name},");
            }


            #endregion

            #region Q8

            var sortByCat = PList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            Console.WriteLine($"\n ------ Sorted By Category ------ \n");

            foreach (var product in sortByCat)
            {
                Console.WriteLine($"Product Category: {product.Category} Product Name: {product.ProductName} Price: {product.UnitPrice}");
            }

            #endregion

            #region Q9

            var beverages = PList.OrderByDescending(p => p.UnitsInStock).Where(p => p.Category == "Beverages");
            Console.WriteLine($"\n ------ Beverages in stock ------ \n");


            foreach (var product in beverages)
            {
                Console.WriteLine($"Product Name: {product.ProductName} Stock: {product.UnitsInStock}");
            }

            #endregion

            #region Q10

            var Orders1997 = from c in CList
                             from o in c.Orders
                             where o.OrderDate >= new DateTime(1997, 1, 1)
                             select new
                             {
                                 id = c.CustomerID,
                                 date = o.OrderDate
                             };


            Console.WriteLine($"\n ------ Orders 1997 ------ \n");


            foreach (var o in Orders1997)
            {
                Console.WriteLine($"Customer ID: {o.id} Order Date: {o.date}");
            }

            #endregion

            #region Q11

            var products = PList.Select((p, index) => new
            {
                Position = index + 1,
                p.ProductName
            });

            Console.WriteLine($"\n ------ Positions ------ \n");

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Position}. {p.ProductName}");
            }


            #endregion

            #region Q12

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sorted = Arr.OrderBy(x => x.Length).ThenBy(x => x, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"\n ------ Words ------ \n");


            foreach (var word in sorted)
            {
                Console.WriteLine(word);
            }

            #endregion

            #region Q13

            var result = Arr.Where(x => x[1] == 'i').Reverse();

            Console.WriteLine($"\n ------ Reversed Words ------ \n");


            foreach (var word in result)
            {
                Console.WriteLine(word);
            }


            #endregion

        }
    }
}
