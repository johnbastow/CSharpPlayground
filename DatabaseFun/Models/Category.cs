using CsvHelper.Configuration.Attributes;

namespace DatabaseFun.Models;

public class Category
{
    [Name("Category_ID")]
    public int CategoryId { get; set; }

    [Name("Category_Name")]
    public string Name { get; set; }
}
