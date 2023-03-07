// See https://aka.ms/new-console-template for more information
using BikeRepairShop.DL.Repositories;
using System.Configuration;

Console.WriteLine("Hello, World!");
//string conn = "Data Source=NB21-6CDPYD3\\SQLEXPRESS;Initial Catalog=BikeRepairShopDinsdag;Integrated Security=True";
string conn = ConfigurationManager.ConnectionStrings["ADOconnSQL"].ConnectionString;
CustomerRepository repo = new CustomerRepository(conn);
var bikes=repo.GetBikesInfo();
Console.WriteLine("end");
