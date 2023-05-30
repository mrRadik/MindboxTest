CREATE TABLE Products (
	ProductId INT PRIMARY KEY,
	"ProductName" varchar
);

CREATE TABLE Categories (
	CategoryId INT PRIMARY KEY,
	"CategoryName" varchar
);

CREATE TABLE "ProductsCategories"
(
    "ProductId"  integer
        constraint "ProductId"
            references Products (ProductId),
    "CategoryId" integer
        constraint "CategoryId"
            references Categories (CategoryId)
);


SELECT p."ProductName", c."CategoryName"
FROM products p
LEFT JOIN productsCategories pc
	ON p.ProductId = pc.ProductId
LEFT JOIN Categories c
	ON pc.CategoryId = c.CategoryId;