# Creating Database Schema:

Create database UniCardFirst

--Design a database schema for a simple e-commerce platform with the following requirement
use UniCardFirst

```sh
go 
- 1.Users (UserId, Username, Password, Email) 
create table Users (  -- user Table
    UserId int primary key identity,
    Username nvarchar(50) not null,
    Passsword nvarchar(50) not null,
    Email nvarchar(100) not null
);
```
- 2.Products (ProductId, ProductName, Description, Price)

 
 ```sh
create table  Products ( -- Product table
    ProductId int primary key identity,
    ProductName nvarchar(100) not null,
    Description nvarchar(50),
    price DECIMAL(10, 2) not null
);
```
- 3.Orders (OrderId, UserId, OrderDate, TotalAmount)

<br>
``` sh
create table Orders ( -- order table
    OrderId int primary key identity,
    UserId int not null,
    OrderDate datetime not null,
    TotalAmount decimal(18, 2) not null,
    foreign key (UserId) references Users(UserId)
);
```
<br>
- 4.OrderItems (OrderItemId, OrderId, ProductId, Quantity, Price)
  <br>
  
  ```sh
create table OrderItems (
    OrderItemId int primary key identity,
    OrderId int not null,
    ProductId int not null,
    Quantity int not null,
    Price decimal(18, 2) not null,
    foreign key (OrderId) references Orders(OrderId),
    foreign key (ProductId) references Products(ProductId)
);
```
<br>

-add indexes for optimizy queries:
<br>
```sh
create unique index IDX_Username on Users(Username);
create unique index IDX_Email on Users(Email);
create index IDX_ProductName on Products(ProductName);
create index IDX_UserId on Orders(UserId);
create index IDX_OrderDate on Orders(OrderDate);
create index IDX_OrderId on OrderItems(OrderId);
create index IDX_ProductId on OrderItems(ProductId);
```
<br>
# Write stored procedures for the following:

- 1.Retrieve all users who have placed an order:
  
  <br>
  ```sh
go
create procedure GetUsersWithOrders
as
begin
    select distinct u.UserId, u.Username, u.Email
    from Users u
    inner join Orders o on u.UserId = o.UserId;
END;
```
<br>
- 2.Retrieve the top 5 products based on the total quantity sold:
<br>
```sh
go
create procedure GetTop5ProductsByQuantitySold
as
begin
    select top 5 p.ProductId, p.ProductName, SUM(oi.Quantity) as TotalQuantitySold
    from Products p
    inner join OrderItems oi on p.ProductId = oi.ProductId
    group by p.ProductId, p.ProductName
    order  by TotalQuantitySold desc;
end;
```
<br>
- 3.Calculate the total revenue generated from orders in the last month:
<br>
```sh
go
Create procedure GetTotalRevenueLastMonth
as
begin
    select SUM(TotalAmount) as TotalRevenue
    from Orders
    where OrderDate >= DATEADD(MONTH, -1, GETDATE()) and OrderDate < GETDATE();
end;
```

<br>
- 4.Retrieve the list of orders along with the user and product details for each order item.
<br>
```sh
go
create procedure GetOrdersWithDetails
as
begin
    select o.OrderId, o.OrderDate, o.TotalAmount,
           u.UserId, u.Username, u.Email,
           oi.OrderItemId, oi.Quantity, oi.Price,
           p.ProductId, p.ProductName, p.Description
    from Orders o
    inner  join Users u on o.UserId = u.UserId
    inner join OrderItems oi on o.OrderId = oi.OrderId
    inner join Products p on oi.ProductId = p.ProductId;
end;
```
<br>
# Task 3: Performance Optimization
Objective: Test ability to optimize database queries and API performance.
<br>
- 1. Given the following query, identify potential performance issues and suggest improvements:
<br>
  ```sh
SELECT p.ProductName, SUM(oi.Quantity) AS TotalQuantity
FROM Products p
JOIN OrderItems oi ON p.ProductId = oi.ProductId
GROUP BY p.ProductName
ORDER BY TotalQuantity DESC;
```
<br>

```sh
--it  do not  have problem if  data is small and  not large , but   if data will be large  there  will be  few potential issues
--Indexing: If Products(ProductId) and OrderItems(ProductId) are not indexed, the join operation whill kill  data integrity

--Aggregation: Performing aggregation (SUM) without appropriate indexes on OrderItems(ProductId) will  couse  slow performance when  data will be large

--Sorting: Sorting  can be   costly when  data is large  if we  are not using correct indexings
```
<br>
-2. Optimize the above query for better performance.
<br>
```sh
--add indexes for optimizy query :
CREATE INDEX IDX_ProductId ON Products(ProductId);
CREATE INDEX IDX_ProductId ON OrderItems(ProductId);
-- add alll posible indexes from product :
CREATE INDEX IDX_ProductId_Quantity ON OrderItems(ProductId, Quantity);
```
<br>
if  we still do not like  performance we  can re write the query after add indexes, lets use temporary table:
<br>

```sh
with ProductQuantities as (
    select oi.ProductId, sum(oi.Quantity) as TotalQuantity
    from OrderItems oi
    group by oi.ProductId
)
select p.ProductName, pq.TotalQuantity
from Products p
inner join ProductQuantities pq on p.ProductId = pq.ProductId
order by pq.TotalQuantity desc;
```
<br>
- 3) In the context of the API developed in Task 2, identify potential performance bottlenecks and suggest optimizations.
<br>
 ```sh
same in this case we  need optimize  database using indexes , and  segregate keys, also
use  asynchronous programing for better performance, and  may use memory cash if  we work with big data
```

# Task 4: Data Integrity and Transactions
Objective: Evaluate understanding of data integrity and transaction management in SQL.
- 1. Write a stored procedure(s) to create a new order with multiple order items. Ensure that the procedure handles transactions and rolls back in case of any errors.
     <br>
```sh
go
create procedure CreateOrderWithItems
    @UserId INT,
    @OrderDate DATETIME,
    @OrderItems AS dbo.OrderItemsType READONLY  -- user defined type
as
begin
    set nocount on;
    declare @OrderId int;

    begin try
        begin Transaction;
        insert into Orders (UserId, OrderDate, TotalAmount)
        values (@UserId, @OrderDate, 0);

        set @OrderId =scope_identity()

        insert into  OrderItems (OrderId, ProductId, Quantity, Price)
        select @OrderId, oi.ProductId, oi.Quantity, p.Price
        from @OrderItems oi
        inner join Products p on oi.ProductId = p.ProductId;

        update Orders
        set TotalAmount = (
            select sum(oi.Quantity * oi.Price)
            from OrderItems oi
            where oi.OrderId = @OrderId
        )
        where OrderId = @OrderId;

        commit  Transaction;
    end try
    begin catch
        if @@TRANCOUNT > 0
            rollback transaction;
        throw;
    end catch
end;
```
<br>
- 2. Describe how you would ensure data integrity in the database, particularly for the `Orders` `OrderItems` tables.
<br>
```sh
--we have few  principes for data integrity , first of all it is  use  foreign key for conection
--data types  ,  we must use  data types  in correct  way , for example int, decimal , datetime  ect
-- add indexes to foreign keys OrderId, ProductId ,  it iwll  make performance better becouse we  call the fields  many times , and  use indexes will be good in  such case
-- Transaction Managment - when  we have  two connected table and want  write  procdeure which will fill the tables out , we must use  transaction in case if error   ocured  ,we will be able roll it back
-- normalization , it is  strictly recomendet  use normalzation rules when   creating database schem, also in this case we must use these normalisation rules
```
<br>
