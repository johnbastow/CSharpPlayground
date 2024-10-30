-- Create To_Do_Items table with foreign keys to Users and Categories
CREATE TABLE tblToDoItems (
    ItemID INT PRIMARY KEY,
    CategoryID INT,
    UserID INT,
    ToDoItem TEXT NOT NULL,
    DueDate DATE,
    IsCompleted BIT DEFAULT 0,
    FOREIGN KEY (CategoryID) REFERENCES tblCategories(CategoryID) ON DELETE SET NULL,
    FOREIGN KEY (UserID) REFERENCES tblUsers(UserID) ON DELETE CASCADE
); 
