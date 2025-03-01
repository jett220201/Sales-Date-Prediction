-- Get Client Orders --
DECLARE @CustomerId INT
SET @CustomerId = 1
SELECT orderid AS 'Orderid', requireddate AS 'RequiredDate',
shippeddate AS 'Shippeddate', shipname AS 'Shipname',
shipaddress AS 'ShipAddress', shipcity AS 'Shipcity'
FROM Sales.Orders WHERE custid = @CustomerId