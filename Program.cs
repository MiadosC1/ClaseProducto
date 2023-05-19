﻿using System;
using System.IO;


internal class Program
{
    class Product
    {
        public string Code;
        public string Description;
        public decimal Price;

        public Product(string c, string d, decimal p)
        {
            Code = c;
            Description = d;
            Price = p;
        }


    }

    class ProductsDB
    {
        public static void SaveProducts(List<Product>products)
        {
           StreamWriter textOut = new StreamWriter(new FileStream(@"C:\Users\Ricardo Ibarra\ClaseProducto\Products.txt", FileMode.Create, FileAccess.Write));

            foreach (var product in products)
            {
                textOut.Write(product.Code + "|");
                textOut.Write(product.Description + "|");
                textOut.WriteLine(product.Price);
            }
            textOut.Close();
        }
            public static List<Product> GetProducts()
        {
        StreamReader textIn =
        new StreamReader(
        new FileStream(@"C:\Users\Ricardo Ibarra\ClaseProducto\Products.txt", FileMode.OpenOrCreate, FileAccess.Read));

        List<Product>products = new List<Product>();
        while(textIn.Peek() != -1)
        {
            string row = textIn.ReadLine();
            string[] columns = row.Split("|");
            Product product = new Product(columns[0], columns[1],Convert.ToDecimal(columns[2]));
            products.Add(product);
        }
        textIn.Close();

        return products;
        }
    }

    private static void Main(string[] args)
    {
        /*
        List<Product> products = new List<Product>();
        products.Add(new Product("A01", "Pasta", 10.99m)); 
        products.Add(new Product("A02", "Salsa", 8.99m));
        ProductsDB.SaveProducts(products);

        Product Pasta = new Product ("0001", "Pasta", 10.99m);
        Product salsa = new Product ("0002", "Salsa", 8.99m);
        */

        List<Product> pds = new();
        pds = ProductsDB.GetProducts();
        foreach (Product p in pds)
        {
            if (p.Price > 8.99m)
            {
                Console.WriteLine(p.Price);
            }
        }
    }
}