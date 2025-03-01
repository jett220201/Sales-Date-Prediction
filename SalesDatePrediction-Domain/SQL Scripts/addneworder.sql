-- Add New Order --
BEGIN TRANSACTION;

-- Declare Order variables
DECLARE @OrderId INT;
DECLARE @Empid INT;
DECLARE @Shipperid INT;
DECLARE @Shipname NVARCHAR(40);
DECLARE @Shipaddress NVARCHAR(60);
DECLARE @Shipcity NVARCHAR(15);
DECLARE @Shipcountry NVARCHAR(15);
DECLARE @Orderdate DATETIME;
DECLARE @Requireddate DATETIME;
DECLARE @Shippeddate DATETIME;
DECLARE @Freight MONEY;

-- Declare Order details variables
DECLARE @Productid INT;
DECLARE @Unitprice MONEY;
DECLARE @Qty SMALLINT;
DECLARE @Discount NUMERIC(4, 3);

-- Set values
SET @Empid = 1;
SET @Shipperid = 1;
SET @Shipname = 'Shipper A';
SET @Shipaddress = 'CLL 5 # 5-14';
SET @Shipcity = 'CALI';
SET @Shipcountry = 'COLOMBIA';
SET @Orderdate = '2025-02-24 00:00:00';
SET @Requireddate = '2025-02-26 00:00:00';
SET @Shippeddate = '2025-02-28 00:00:00';
SET @Freight = 10.5;
SET @Productid = 1;
SET @Unitprice = 10.5;
SET @Qty = 1;
SET @Discount = 0.5;

-- Insert into Order
INSERT INTO Sales.Orders (Empid, Shipperid, Shipname, Shipaddress, Shipcity, Orderdate, Requireddate, Shippeddate, Freight, Shipcountry)
VALUES (@Empid, @Shipperid, @Shipname, @Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry);

SET @OrderId = SCOPE_IDENTITY(); -- Get Order ID

-- Insert into OrderDetails
INSERT INTO Sales.OrderDetails (Orderid, Productid, Unitprice, Qty, Discount)
VALUES (@OrderId, @Productid, @Unitprice, @Qty, @Discount);

COMMIT TRANSACTION;