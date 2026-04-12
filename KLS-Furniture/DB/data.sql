USE [KLSFurniture]
GO

-- Reset data
DELETE FROM dbo.return_transaction_items;
DELETE FROM dbo.return_transactions;
DELETE FROM dbo.rental_transaction_items;
DELETE FROM dbo.rental_transactions;
DELETE FROM dbo.furniture;
DELETE FROM dbo.furniture_styles;
DELETE FROM dbo.furniture_categories;
DELETE FROM dbo.members;
DELETE FROM dbo.employees;
GO

DBCC CHECKIDENT ('dbo.employees', RESEED, 0);
DBCC CHECKIDENT ('dbo.members', RESEED, 9999);
DBCC CHECKIDENT ('dbo.furniture_categories', RESEED, 0);
DBCC CHECKIDENT ('dbo.furniture_styles', RESEED, 0);
DBCC CHECKIDENT ('dbo.furniture', RESEED, 0);
DBCC CHECKIDENT ('dbo.rental_transactions', RESEED, 1);
DBCC CHECKIDENT ('dbo.return_transactions', RESEED, 1);
GO

-- Employees
SET IDENTITY_INSERT [dbo].[employees] ON 

INSERT [dbo].[employees]
    ([employee_id], [username], [password_hash], [is_admin], [last_name], [first_name], [sex], [date_of_birth], [phone], [address_line_1], [address_line_2], [city], [state], [zip_code])
VALUES
    (1, N'jane',   N'$2a$10$rOpoDuxCGZvurkQAiEEVAOHbyzgkwgxv9bzkdTvn.3xt8apreyI8K', 1, N'Doe',    N'Jane',    N'F', CAST(N'1998-05-10' AS date), N'5551112222', N'42 Maple Street', NULL, N'Carrollton', N'GA', N'30117'),
    (2, N'thomas', N'$2a$10$X1G9XMxpSkoRCfYGh/AU3eSgTylTKlCLpsItRh1etqOk8e6jwoc5a', 0, N'Thomas', N'Michael', N'M', CAST(N'1989-11-22' AS date), N'5552223333', N'18 Cedar Bluff',  NULL, N'Carrollton', N'GA', N'30117');

SET IDENTITY_INSERT [dbo].[employees] OFF
GO


-- Members
SET IDENTITY_INSERT [dbo].[members] ON 

INSERT [dbo].[members]
    ([member_id], [last_name], [first_name], [sex], [date_of_birth], [phone], [address_line_1], [address_line_2], [city], [state], [zip_code])
VALUES
    (10000, N'Smith',   N'John',  N'M', CAST(N'1995-03-12' AS date), N'7705551001', N'14 West Avenue',   NULL,        N'Carrollton',  N'GA', N'30117'),
    (10001, N'Johnson', N'Mary',  N'F', CAST(N'1988-07-21' AS date), N'7705551002', N'88 Cedar Creek Rd', N'Apt 4B',  N'Newnan',      N'GA', N'30263'),
    (10002, N'Brown',   N'David', N'M', CAST(N'1992-11-05' AS date), N'7705551003', N'231 Mill Stone Dr', NULL,       N'Douglasville', N'GA', N'30134'),
    (10003, N'Davis',   N'Sarah', N'F', CAST(N'2000-01-30' AS date), N'7705551004', N'7 Highland Court',  NULL,       N'Villa Rica',   N'GA', N'30180'),
    (10004, N'Miller',  N'John',  N'M', CAST(N'1985-09-14' AS date), N'7705551005', N'412 River Bend Ln', NULL,       N'Bremen',       N'GA', N'30110'),
    (10005, N'Smith',   N'Emily', N'F', CAST(N'1997-06-18' AS date), N'7705551006', N'55 Willow Trace',   N'Unit 2',  N'Carrollton',   N'GA', N'30116');

SET IDENTITY_INSERT [dbo].[members] OFF
GO


-- Furniture categories
SET IDENTITY_INSERT [dbo].[furniture_categories] ON 

INSERT [dbo].[furniture_categories]
    ([category_id], [category_name])
VALUES
    (1, N'Chair'),
    (2, N'Desk'),
    (3, N'Bed'),
    (4, N'Table'),
    (5, N'Shelf');

SET IDENTITY_INSERT [dbo].[furniture_categories] OFF
GO


-- Furniture styles
SET IDENTITY_INSERT [dbo].[furniture_styles] ON 

INSERT [dbo].[furniture_styles]
    ([style_id], [style_name])
VALUES
    (1, N'Classic'),
    (2, N'Modern'),
    (3, N'Electric'),
    (4, N'Forest'),
    (5, N'Water');

SET IDENTITY_INSERT [dbo].[furniture_styles] OFF
GO


-- Furniture
SET IDENTITY_INSERT [dbo].[furniture] ON 

INSERT [dbo].[furniture]
    ([furniture_id], [name], [description], [category_id], [style_id], [daily_rate], [quantity])
VALUES
    (1, N'Pikachu Lounge Chair', N'A bright yellow lounge chair with soft cushions and a playful electric theme.', 1, 3, CAST(12.99 AS decimal(10,2)), 4),
    (2, N'Snorlax Day Bed',      N'A large and extra-comfortable bed designed for deep rest and relaxing naps.',   3, 1, CAST(24.50 AS decimal(10,2)), 2),
    (3, N'Bulbasaur Bookshelf',  N'A compact green bookshelf with a natural wood finish and leaf-inspired details.',5, 4, CAST(14.75 AS decimal(10,2)), 3),
    (4, N'Squirtle Coffee Table',N'A round coffee table with a smooth blue surface and a clean water-inspired design.', 4, 5, CAST(10.50 AS decimal(10,2)), 5),
    (5, N'Charizard Gaming Desk',N'A large desk with bold lines, dark trim, and a fiery modern look.',             2, 2, CAST(18.99 AS decimal(10,2)), 3),
    (6, N'Eevee Accent Chair',   N'A soft neutral-toned accent chair that fits easily into many room styles.',      1, 2, CAST(11.25 AS decimal(10,2)), 4),
    (7, N'Lapras Writing Desk',  N'A sturdy writing desk with a calm blue finish and wide working surface.',        2, 5, CAST(17.50 AS decimal(10,2)), 2),
    (8, N'Gengar Night Stand',   N'A compact bedside stand with a dark finish and a slightly mischievous design.',  4, 1, CAST(8.99 AS decimal(10,2)), 6);

SET IDENTITY_INSERT [dbo].[furniture] OFF
GO
