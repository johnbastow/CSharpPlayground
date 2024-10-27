using CsvHelper.Configuration.Attributes;

namespace CSharpTodoListImporter.Models;

public class ListItem 
{
    [Name("Item_ID")]
    public int ListItemId { get; init; }
   
    [Name("Category_ID")]
    public int CategoryId { get; init; }
   
    [Name("User_ID")]
    public int UserId { get; init; }
   
    [Name("To_Do_Item")]
    public string Item { get; init; }
}
