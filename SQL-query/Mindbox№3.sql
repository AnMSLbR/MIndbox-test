	CREATE TABLE Products
(
    Id INT PRIMARY KEY IDENTITY,
    Product NVARCHAR(30)
);

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Category NVARCHAR(30)
);

CREATE TABLE ProductsCategories 
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id) NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NULL
);

INSERT INTO Products VALUES
('���������'),
('����'),
('�����'),
('������'),
('�������'),
('���������� ������'),
('�����'),
('�����������'),
('����'),
('����'),
('����'),
('����������'),
('��������'),
('���');
INSERT INTO Categories VALUES
('������'),
('�������'),
('���'),
('���������'),
('�������������');
INSERT INTO ProductsCategories VALUES
(1,2),
(1,4),
(2,1),
(2,5),
(3,1),
(3,4),
(4,3),
(4,5),
(5,2),
(5,4),
(6,2),
(6,4),
(7,5),
(8,2),
(8,5),
(9,3),
(9,5),
(10,1),
(10,5),
(11,1),
(11,4),
(12,2),
(12,4),
(13,3),
(13,5),
(14, NULL)
/*����� ���� ��� �������� � ���������*/
SELECT P."Product", C."Category"
FROM ProductsCategories PC
LEFT JOIN Products P
	ON P.Id = PC.ProductId
LEFT JOIN Categories C
	ON C.Id = PC.CategoryId;
