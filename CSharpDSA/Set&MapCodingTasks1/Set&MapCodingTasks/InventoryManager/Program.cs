using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            //Stopwatch sw = Stopwatch.StartNew();

            HashSet<string> names = new HashSet<string>();
            Dictionary<string, List<Product>> categoryDict = new Dictionary<string, List<Product>>();
            Dictionary<double, List<Product>> priceDict = new Dictionary<double, List<Product>>();

            StringBuilder output = new StringBuilder();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split(' ').ToArray();
                string commandType = commands[0];


                if(commandType == "add")
                {
                    string prodName = commands[1];
                    double prodPrice = double.Parse(commands[2]);
                    string prodType = commands[3];
              
                    if(!names.Add(prodName))
                    {
                        output.AppendLine($"Error: Item {prodName} already exists");
                    }
                    else
                    {
                        if (!categoryDict.ContainsKey(prodType))
                        {
                            categoryDict[prodType] = new List<Product>();
                        }
                        categoryDict[prodType].Add(new Product(prodName, prodPrice, prodType));

                        if (!priceDict.ContainsKey(prodPrice))
                        {
                            priceDict[prodPrice] = new List<Product>();
                        }
                        priceDict[prodPrice].Add(new Product(prodName,prodPrice, prodType));
                        //print

                        output.AppendLine($"Ok: Item {prodName} added successfully");
                    }

                }
                else if(commandType == "filter")
                {
                    if(commands.Count() == 4) // by type
                    {
                        string type = commands[3];

                        if(!categoryDict.ContainsKey(type))
                        {
                            output.AppendLine($"Error: Type {type} does not exist");
                            //Console.WriteLine(output.ToString().Trim());
                            continue;
                        }

                        var sortedKvp = categoryDict[type].OrderBy(p => p.Price).ThenBy(p => p.Name).Take(10);

                        //print

                        //output.Append("Ok: ");
                        //foreach( var kvp in sortedKvp )
                        //{
                        //    output.Append(kvp.ToString() + ", ");
                        //}
                        //output = output.Replace(", ", string.Empty, output.Length - 2, 2);
                        output.AppendLine($"Ok: {string.Join(", ", sortedKvp)}");

                    }
                    else if(commands.Count() == 5)// by price
                    {
                        string way = commands[3];
                        double price = double.Parse(commands[4]);

                        if(way == "to")
                        {
                            var sortedKvp = priceDict.Where(kvp => kvp.Key <= price).SelectMany(x => x.Value).OrderBy(kvp => kvp.Price).ThenBy(kvp => kvp.Name).ThenBy(kvp => kvp.Type).Take(10);

                            //print
                            //output.Append("Ok: ");
                            //foreach (var kvp in sortedKvp)
                            //{
                            //    output.Append(kvp.ToString() + ", ");
                            //}
                            //output = output.Replace(", ", string.Empty, output.Length - 2, 2);
                            output.AppendLine($"Ok: {string.Join(", ", sortedKvp)}");
                        }
                        else // from
                        {
                            var sortedKvp = priceDict.Where(kvp => kvp.Key >= price).SelectMany(x => x.Value).OrderBy(kvp => kvp.Price).ThenBy(kvp => kvp.Name).ThenBy(kvp => kvp.Type).Take(10);

                            //print
                            //output.Append("Ok: ");
                            //foreach (var kvp in sortedKvp)
                            //{
                            //    output.Append(kvp.ToString() + ", ");
                            //}
                            //output = output.Replace(", ", string.Empty, output.Length - 2, 2);
                            output.AppendLine($"Ok: {string.Join(", ", sortedKvp)}");
                        }
                    }
                    else // filter by price from min to max
                    {
                        double min = double.Parse(commands[4]);
                        double max = double.Parse(commands[6]);


                        var sortedKvp = priceDict.Where(kvp => kvp.Key >= min && kvp.Key <= max).SelectMany(x => x.Value).OrderBy(kvp => kvp.Price).ThenBy(kvp => kvp.Name).ThenBy(kvp => kvp.Type).Take(10);

                        //print
                        //output.Append("Ok: ");
                        //foreach (var kvp in sortedKvp)
                        //{
                        //    output.Append(kvp.ToString() + ", ");
                        //}
                        //output = output.Replace(", ", string.Empty, output.Length - 2, 2);
                        output.AppendLine($"Ok: {string.Join(", ", sortedKvp)}");
                    }
                }
                


            }
                Console.WriteLine(output.ToString().Trim());
            //Console.WriteLine(sw.Elapsed.Milliseconds);
        }
    }

    internal struct Product
    {
        public Product(string name, double price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Name}({Price:f2})";
        }
    }
}