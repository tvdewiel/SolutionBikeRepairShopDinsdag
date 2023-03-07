// See https://aka.ms/new-console-template for more information
using BikeRepairShop.DL.Repositories;

Console.WriteLine("Hello, World!");
string conn = "Data Source=NB21-6CDPYD3\\SQLEXPRESS;Initial Catalog=BikeRepairShopDinsdag;Integrated Security=True";
CustomerRepository repo = new CustomerRepository(conn);
var bikes=repo.GetBikesInfo();
Console.WriteLine("end");
