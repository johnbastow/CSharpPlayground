﻿using CsvHelper.Configuration.Attributes;

namespace DatabaseFun.Models;

public class ToDoItem 
{
    [Name("Item_ID")]
    public int ToDoItemId { get; init; }
   
    [Name("Category_ID")]
    public int CategoryId { get; init; }
   
    [Name("User_ID")]
    public int UserId { get; init; }
   
    [Name("To_Do_Item")]
    public string Item { get; init; }
}
