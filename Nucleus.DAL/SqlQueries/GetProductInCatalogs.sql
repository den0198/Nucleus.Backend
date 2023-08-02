SELECT
    p.product_id AS [ProductId],
    p.name AS [ProductName],
    MIN(sp.Price) AS [MinPrice],
    MAX(sp.Price) AS [MaxPrice]
FROM
    products p
    INNER JOIN
    sub_products sp ON p.product_id = sp.product_id
GROUP BY
    p.product_id, p.name;