CREATE TABLE Menu (
    menu_id INT PRIMARY KEY,
    description VARCHAR(100),
    price DECIMAL(10, 2)
);
GO

CREATE TABLE Delivery (
    dlvry_id INT PRIMARY KEY,
    description VARCHAR(100)
);
GO

CREATE TABLE Customer (
    cust_id INT PRIMARY KEY,
    cust_name VARCHAR(100),
    cust_hp VARCHAR(100)
);
GO

CREATE TABLE Menu (
    menu_id INT PRIMARY KEY,
    description VARCHAR(100),
    price DECIMAL(10, 2)
);
GO

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    order_date DATE,
    cust_id INT,
    dlvry_id INT,
    FOREIGN KEY (cust_id) REFERENCES Customer(cust_id),
    FOREIGN KEY (dlvry_id) REFERENCES Delivery(dlvry_id)
);
GO

CREATE TABLE Order_line (
    order_id INT,
    menu_id INT,
    qty INT,
    PRIMARY KEY (order_id, menu_id),
    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (menu_id) REFERENCES Menu(menu_id)
);
GO

-- Step 1: Make sure the customer exists
INSERT INTO Customer (cust_id, cust_name, cust_hp)
VALUES (2601, 'Adam', '0111-353-4732');
GO

-- Step 2: Make sure the delivery method exists
INSERT INTO Delivery (dlvry_id, description)
VALUES (6107, 'dahmakan');
GO

-- Step 3: Create the order
INSERT INTO Orders (order_id, order_date, cust_id, dlvry_id)
VALUES (8001, '2021-05-20', 2601, 6107);
GO

-- Step 4: Make sure the menu item exists
INSERT INTO Menu (menu_id, description, price)
VALUES (5137, 'Blazing Seafood', 29.90);
GO

-- Step 5: Add items to the order
INSERT INTO Order_line (order_id, menu_id, qty)
VALUES (8001, 5137, 2);
GO
