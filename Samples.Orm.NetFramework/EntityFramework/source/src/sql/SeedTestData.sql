
DELETE FROM [Product];
GO
DELETE FROM [Category];
GO

SET IDENTITY_INSERT Category ON;
GO

INSERT INTO [Category] ([CategoryID],[CategoryName])VALUES(1, 'Bread and Cereal');
INSERT INTO [Category] ([CategoryID],[CategoryName])VALUES(2, 'Dairy');
INSERT INTO [Category] ([CategoryID],[CategoryName])VALUES(3, 'Fruits and Veggies');
INSERT INTO [Category] ([CategoryID],[CategoryName])VALUES(4, 'MEAT!');
INSERT INTO [Category] ([CategoryID],[CategoryName])VALUES(5, 'Junk Food');
INSERT INTO [Category] ([CategoryID],[CategoryName])VALUES(6, 'UNKNOWN');
GO

SET IDENTITY_INSERT Category ON;
GO

SET IDENTITY_INSERT Category OFF;
GO


SET IDENTITY_INSERT Product ON;
GO

INSERT INTO Product ([ProductID],[ProductName],[CategoryID],[UnitPrice],[Discontinued])VALUES(1, 'Bread', 1, '1.79', 0);
INSERT INTO Product ([ProductID],[ProductName],[CategoryID],[UnitPrice],[Discontinued])VALUES(2, 'Raisin Bran', 1, '2.15', 0);
INSERT INTO Product ([ProductID],[ProductName],[CategoryID],[UnitPrice],[Discontinued])VALUES(3, 'Apple', 3, '0.99', 0);
INSERT INTO Product ([ProductID],[ProductName],[CategoryID],[UnitPrice],[Discontinued])VALUES(4, 'Orange', 3, '0.99', 0);
INSERT INTO Product ([ProductID],[ProductName],[CategoryID],[UnitPrice],[Discontinued])VALUES(5, 'Green Beans', 3, '1.55', 0);
INSERT INTO Product ([ProductID],[ProductName],[CategoryID],[UnitPrice],[Discontinued])VALUES(6, 'Carrots', 3, '0.99', 1);
INSERT INTO Product ([ProductID],[ProductName],[CategoryID],[UnitPrice],[Discontinued])VALUES(7, 'Ground Sirlion', 4, '5.99', 0);
INSERT INTO Product ([ProductID],[ProductName],[CategoryID],[UnitPrice],[Discontinued])VALUES(8, 'Milk', 2, '1.99', 0);
INSERT INTO Product ([ProductID],[ProductName],[CategoryID],[UnitPrice],[Discontinued])VALUES(9, 'Cheese', 2, '1.99', 0);
GO

SET IDENTITY_INSERT Product ON;

SET IDENTITY_INSERT Product OFF;



