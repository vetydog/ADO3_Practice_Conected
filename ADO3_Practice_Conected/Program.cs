using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO3_Practice_Conected
{
    internal class Program
    {
        static SqlConnection conn = null;
        static void Main(string[] args)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString);
            try
            {
                conn.Open();
                Console.WriteLine("Connection Opened");

                string Pr = "select * from Products";
                SqlCommand cmdPr = new SqlCommand(Pr, conn);

                SqlDataReader readerPr = cmdPr.ExecuteReader();

                Console.WriteLine("===Task 1===");
                while (readerPr.Read()) {
                    Console.WriteLine($"Id: {readerPr["Id"]}, Name: {readerPr["Name"]},TypeId: {readerPr["TypeId"]}, Quantity: {readerPr["Quantity"]}, CostPrice: {readerPr["CostPrice"]} ");
                }

                readerPr.Close();

                string ty = "select * from Types";
                SqlCommand cmdty = new SqlCommand(ty, conn);

                SqlDataReader readerty = cmdty.ExecuteReader();

                Console.WriteLine("===Task 2===");

                while (readerty.Read()) {
                    Console.WriteLine($"Id: {readerty["Id"]}, Name: {readerty["Name"]}");
                }

                readerty.Close();

                string ma = "select * from Managers";

                SqlCommand cmdma = new SqlCommand(ma, conn);

                SqlDataReader readerma = cmdma.ExecuteReader();

                Console.WriteLine("===Task 3===");

                while (readerma.Read())
                {
                    Console.WriteLine($"Id: {readerma["Id"]}, FirstName: {readerma["FirstName"]}, LastName: {readerma["LastName"]}, Phone: {readerma["Phone"]}");
                }

                readerma.Close();


                string maxqua = "select * from Products where Quantity = (select max(Quantity) from Products)";

                SqlCommand cmdmaxqua = new SqlCommand(maxqua, conn);

                SqlDataReader readermaxqua = cmdmaxqua.ExecuteReader();

                Console.WriteLine("===Task 4===");

                while (readermaxqua.Read())
                {
                    Console.WriteLine($"{readermaxqua["Name"]} - {readermaxqua["Quantity"]}");
                }

                readermaxqua.Close();

                string minqua = "select [Name], Quantity from Products where Quantity = (select min(Quantity) from Products)";

                SqlCommand cmdminqua = new SqlCommand(minqua, conn);

                SqlDataReader readerminqua = cmdminqua.ExecuteReader();

                Console.WriteLine("===Task 5===");

                while (readerminqua.Read())
                {
                    Console.WriteLine($"{readerminqua["Name"]} - {readerminqua["Quantity"]}");
                }

                readerminqua.Close();



                string mincost = "select [Name], CostPrice from Products where CostPrice = (select min(CostPrice) from Products)";

                SqlCommand cmdmincost = new SqlCommand(mincost, conn);

                SqlDataReader readermincost = cmdmincost.ExecuteReader();

                Console.WriteLine("===Task 6===");

                while (readermincost.Read())
                {
                    Console.WriteLine($"{readermincost["Name"]} - {readermincost["CostPrice"]}");
                }

                readermincost.Close();



                string maxcost = "select [Name], CostPrice from Products where CostPrice = (select max(CostPrice) from Products)";

                SqlCommand cmdmaxcost = new SqlCommand(maxcost, conn);

                SqlDataReader readermaxcost = cmdmaxcost.ExecuteReader();

                Console.WriteLine("===Task 7===");

                while (readermaxcost.Read())
                {
                    Console.WriteLine($"{readermaxcost["Name"]} - {readermaxcost["CostPrice"]}");
                }

                readermaxcost.Close();

                string prty = "select * from Products where TypeId = @p1";

                SqlCommand cmdprty = new SqlCommand(prty, conn);

                Console.WriteLine("Enter Id for Type:");
                int typeid = Convert.ToInt32(Console.ReadLine());

                cmdprty.Parameters.Add("@p1", System.Data.SqlDbType.Int).Value = typeid;

                SqlDataReader rederidtype = cmdprty.ExecuteReader();

                Console.WriteLine("===Task 8===");

                while (rederidtype.Read()) {
                    Console.WriteLine($"Id: {rederidtype["Id"]}, Name: {rederidtype["Name"]},TypeId: {rederidtype["TypeId"]}, Quantity: {rederidtype["Quantity"]}, CostPrice: {rederidtype["CostPrice"]} ");
                }

                rederidtype.Close();

                string productmanager = "select p.* from Products p join SaleDetails sd on p.Id = sd.ProductId join Sales s on sd.SaleId = s.Id where s.ManagerId = @p2";

                SqlCommand cmdproductmanager = new SqlCommand(productmanager, conn);

                Console.WriteLine("Enter Id for Manager:");
                int managerid = Convert.ToInt32(Console.ReadLine());

                cmdproductmanager.Parameters.Add("@p2", System.Data.SqlDbType.Int).Value = managerid;

                SqlDataReader readerproductmanager = cmdproductmanager.ExecuteReader();

                Console.WriteLine("===Task 8===");

                while (readerproductmanager.Read())
                {
                    Console.WriteLine($"Id: {readerproductmanager["Id"]}, Name: {readerproductmanager["Name"]}, TypeId: {readerproductmanager["TypeId"]}, Quantity: {readerproductmanager["Quantity"]}, CostPrice: {readerproductmanager["CostPrice"]}");
                }

                readerproductmanager.Close();

                string productcustomer = "select p.* from Products p join SaleDetails sd on p.Id = sd.ProductId join Sales s on sd.SaleId = s.Id where s.CustomerId = @p3";

                SqlCommand cmdproductcustomer = new SqlCommand(productcustomer, conn);

                Console.WriteLine("Enter Id for Customer:");
                int customerid = Convert.ToInt32(Console.ReadLine());

                cmdproductcustomer.Parameters.Add("@p3", System.Data.SqlDbType.Int).Value = customerid;

                SqlDataReader readerproductcustomer = cmdproductcustomer.ExecuteReader();

                Console.WriteLine("===Task 9===");

                while (readerproductcustomer.Read())
                {
                    Console.WriteLine($"Id: {readerproductcustomer["Id"]}, Name: {readerproductcustomer["Name"]}, TypeId: {readerproductcustomer["TypeId"]}, Quantity: {readerproductcustomer["Quantity"]}, CostPrice: {readerproductcustomer["CostPrice"]}");
                }

                readerproductcustomer.Close();

                string lastsale = "select top 1 * from Sales order by SaleDate desc";

                SqlCommand cmdlastsale = new SqlCommand(lastsale, conn);

                SqlDataReader readerlastsale = cmdlastsale.ExecuteReader();

                Console.WriteLine("===Task 10===");

                while (readerlastsale.Read())
                {
                    Console.WriteLine($"Id: {readerlastsale["Id"]}, CustomerId: {readerlastsale["CustomerId"]}, ManagerId: {readerlastsale["ManagerId"]}, SaleDate: {readerlastsale["SaleDate"]}");
                }

                readerlastsale.Close();

                string avgtype = "select TypeId, avg(Quantity) as AverageQuantity from Products group by TypeId";

                SqlCommand cmdavgtype = new SqlCommand(avgtype, conn);

                SqlDataReader readeravgtype = cmdavgtype.ExecuteReader();

                Console.WriteLine("===Task 11===");

                while (readeravgtype.Read())
                {
                    Console.WriteLine($"TypeId: {readeravgtype["TypeId"]}, Average Quantity: {readeravgtype["AverageQuantity"]}");
                }

                readeravgtype.Close();


            }

            catch (Exception ex) { 
            
            Console.WriteLine(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }
    }
}

/*
 Create Database StationeryCompany
go

use StationeryCompany
go

create Table [Types](
Id int primary key identity(1,1) not null,
[Name] nvarchar(100) not null check([Name]<>'') unique,
)

create Table Products(
Id int primary key identity(1,1) not null,
[Name] nvarchar(100) not null check([Name]<>'') unique,
TypeId int not null,
foreign key (TypeId) references [Types](Id),
Quantity int not null check(Quantity>=0),
CostPrice decimal(10,2) not null check(CostPrice>0)
)

Create Table Managers(
Id int primary key identity(1,1) not null,
FirstName nvarchar(100) not null check(FirstName<>''),
LastName nvarchar(100) not null check(LastName<>''),
Phone nvarchar(20) not null check(Phone <>'')
)

Create Table Customers(
Id int primary key identity(1,1) not null,
[Name] nvarchar(100) not null check([Name]<>'') unique,
Address nvarchar(150) not null check(Address<>''),
Phone nvarchar(20) not null check(Phone <>'')
)

create Table Sales(
Id int primary key identity(1,1) not null,
CustomerId int not null,
foreign key (CustomerId) references Customers(Id),
ManagerId int not null,
foreign key (ManagerId) references Managers(Id),
SaleDate date not null default getdate()
)

create Table SaleDetails(
Id int primary key identity(1,1) not null,
SaleId int not null,
foreign key (SaleId) references Sales(Id),
ProductId int not null,
foreign key (ProductId) references Products(Id),
QuantitySold int not null check(QuantitySold>=0),
UnitPrice decimal(10,2) not null check(UnitPrice>0)
)

insert into [Types] ([Name])
values
('Pens'),
('Notebooks'),
('Pencils'),
('Paper'),
('Markers');


insert into Products ([Name], TypeId, Quantity, CostPrice)
values
('BIC Crystal Blue', 1, 500, 0.50),
('Parker Jotter', 1, 100, 8.50),
('A4 Notebook 96 pages', 2, 300, 1.20),
('A5 Notebook 48 pages', 2, 600, 0.70),
('HB Pencil', 3, 800, 0.30),
('2B Pencil', 3, 400, 0.40),
('A4 Paper 500 sheets', 4, 200, 4.50),
('Black Marker', 5, 250, 1.00);


insert into Managers (FirstName, LastName, Phone)
values
('John', 'Smith', '+380501112233'),
('Anna', 'Johnson', '+380671234567'),
('Michael', 'Brown', '+380931112222');


insert into Customers ([Name], Address, Phone)
values
('Alpha LLC', 'Kyiv, Khreshchatyk Street 10', '+380441112233'),
('Beta LLC', 'Lviv, Shevchenko Street 25', '+380322223344'),
('Gamma LLC', 'Odesa, Deribasivska Street 5', '+380482223333');


insert into Sales(CustomerId, ManagerId, SaleDate)
values
(1, 1, '2026-09-01'),
(2, 2, '2026-09-05'),
(3, 3, '2026-09-10'),
(1, 2, '2026-09-15');


insert into SaleDetails(SaleId, ProductId, QuantitySold, UnitPrice)
values
(1, 1, 100, 1.00),
(1, 3, 50, 2.50),
(2, 7, 20, 6.00),
(2, 8, 30, 2.00),
(3, 5, 200, 0.80),
(3, 6, 100, 1.00),
(4, 2, 10, 12.00),
(4, 4, 80, 1.50);
 */