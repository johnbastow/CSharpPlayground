-- Create the to-do list database
CREATE DATABASE ToDoListDB;

-- Use the database
USE ToDoListDB;

-- Create tblUsers table
CREATE TABLE tblUsers (
    UserID INT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL
);

-- Create Categories table
CREATE TABLE tblCategories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL UNIQUE
);

-- Create To_Do_Items table with foreign keys to Users and Categories
CREATE TABLE tblToDoItems (
    ItemID INT PRIMARY KEY,
    CategoryID INT,
    UserID INT,
    ToDoItem TEXT NOT NULL,
    DueDate DATE,
    IsCompleted BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE SET NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);
