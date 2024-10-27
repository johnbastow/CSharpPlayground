using CsvHelper.Configuration.Attributes;

namespace CSharpTodoListImporter.Models;

public class User
{
    [Name("User_ID")]
    public int UserId { get; init; }
   
    [Name("Username")]
    public string Username { get; init; }
   
    [Name("First_Name")]
    public string FirstName { get; init; }
   
    [Name("Last_Name")]
    public string LastName { get; init; }
}
