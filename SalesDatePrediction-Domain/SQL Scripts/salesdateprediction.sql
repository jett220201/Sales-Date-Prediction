-- Sales Date Prediction --
WITH OrderIntervals AS (
    SELECT 
        o.custid,
        o.OrderDate,
        LAG(o.OrderDate) OVER (PARTITION BY o.custid ORDER BY o.OrderDate) AS PreviousOrderDate
    FROM SALES.Orders o
),
AverageIntervals AS (
    SELECT 
        custid,
        AVG(DATEDIFF(DAY, PreviousOrderDate, OrderDate)) AS AvgDaysBetweenOrders
    FROM OrderIntervals
    WHERE PreviousOrderDate IS NOT NULL
    GROUP BY custid
),
LastOrder AS (
    SELECT 
        o.custid,
        MAX(o.OrderDate) AS LastOrderDate
    FROM Sales.Orders o
    GROUP BY o.custid
)
SELECT 
    c.CompanyName AS 'CustomerName',
    COALESCE(lo.LastOrderDate, '') AS 'LastOrderDate',
    CASE 
        WHEN lo.LastOrderDate IS NULL THEN ''
        ELSE DATEADD(DAY, COALESCE(ai.AvgDaysBetweenOrders, 0), lo.LastOrderDate)
    END AS 'NextPredictedOrder'
FROM Sales.Customers c
LEFT JOIN LastOrder lo ON c.custid = lo.custid
LEFT JOIN AverageIntervals ai ON c.custid = ai.custid;
