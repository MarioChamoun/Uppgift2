﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUppgift
{
        public class userval
    {
        public void createcustomer()
        {

            Console.Clear();
            string companyname;
            string contactname;
            string adress;
            string country;
            string postcode;
            string customerid;

            Console.Write("Skriv in namn på kunden: ");
            contactname = Console.ReadLine();
            Console.Write("Skriv in företagsnamn: ");
            companyname = Console.ReadLine();
            Console.Write("Skriv in kundens adress: ");
            adress = Console.ReadLine();
            Console.Write("Skriv in vilket land kunden bor i: ");
            country = Console.ReadLine();
            Console.Write("Skriv in kundens postnummer: ");
            postcode = Console.ReadLine();
            Console.Write("Skriv customerID(Max 5 bokstäver): ");
            customerid = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True"))
            {

                SqlCommand cmd = new SqlCommand("dbo.InsertCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerid);
                cmd.Parameters.AddWithValue("@CompanyName", companyname);
                cmd.Parameters.AddWithValue("@ContactName", contactname);
                cmd.Parameters.AddWithValue("@ContactTitle", "");
                cmd.Parameters.AddWithValue("@Address", adress);
                cmd.Parameters.AddWithValue("@Region", "");
                cmd.Parameters.AddWithValue("@City", "");
                cmd.Parameters.AddWithValue("@PostalCode", postcode);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@Phone", "");
                cmd.Parameters.AddWithValue("@Fax", "");

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Kunden har registrerats i databasen.");

        }
        public void createproduct()
        {
            Console.Clear();
            string productname;
            string supplierID;
            string QuantityPerUnit;
            decimal UnitPrice;
            int UnitsInStock;
            int UnitsOnOrder;
            int ReorderLevel;
            int Discontinued;
            int categoryID;

            Console.Write("Produktnamn: ");
            productname = Console.ReadLine();
            Console.Write("SupplierID: ");
            supplierID = Console.ReadLine();
            Console.Write("QuantityPerUnit: ");
            QuantityPerUnit = Console.ReadLine();
            Console.Write("CategoryID: ");
            categoryID = int.Parse(Console.ReadLine());
            Console.Write("UnitPrice: ");
            UnitPrice = decimal.Parse(Console.ReadLine());
            Console.Write("UnitsInStock: ");
            UnitsInStock = int.Parse(Console.ReadLine());
            Console.Write("UnitsOnOrder: ");
            UnitsOnOrder = int.Parse(Console.ReadLine());
            Console.Write("ReorderLevel: ");
            ReorderLevel = int.Parse(Console.ReadLine());
            Console.Write("Discounted(0/1): ");
            Discontinued = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True"))
            {

                SqlCommand cmd = new SqlCommand("dbo.InsertProduct", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", productname);
                cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@QuantityPerUnit", QuantityPerUnit);
                cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
                cmd.Parameters.AddWithValue("@UnitsOnOrder", UnitsOnOrder);
                cmd.Parameters.AddWithValue("@ReorderLevel", ReorderLevel);
                cmd.Parameters.AddWithValue("@Discontinued", Discontinued);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Produkten har registrerats i databasen.");
        }
        public string updateprice()
        {
            Console.Clear();
            int ID;
            decimal nyapris;

            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True"))
            {
                con.Open();

                Console.WriteLine("Skriv produktens ID som du vill uppdatera pris på: ");
                ID = int.Parse(Console.ReadLine());

                SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductID =" + ID, con);
                string namn = (string)command.ExecuteScalar();
                Console.WriteLine("Du har valt att uppdatera priset på: " + namn);

                Console.Write("Skriv produktens nya pris: ");
                nyapris = decimal.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand("dbo.UpdateProductPrice", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productid", ID);
                cmd.Parameters.AddWithValue("@productprice", nyapris);

                cmd.ExecuteNonQuery();

                return "Priset på " + namn + " har uppdaterats till " + nyapris;

            }
        }
    }
}
