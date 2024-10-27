using System.IO;
using Microsoft.Extensions.Logging;
// dotnet package add CsvHelper
using CsvHelper;
using System.Globalization;
using CSharpTodoListImporter.Models;
using CsvHelper.Configuration;
using DatabaseFun.Providers;
using DatabaseFun.Services;

namespace DatabaseFun;

public class Service(
    ILoaderService<Category> categoryLoaderService,
    ILogger<Service> logger)
{

    public async Task<int> RunService(){
        try{
            var categories = categoryLoaderService.GetAllRows();
            int categoryCount = 0;

            foreach(Category category in categories){
                logger.LogInformation("ID: {CategoryId}, Name: {Name}", category.CategoryId, category.Name);
                categoryCount++;
            }

            logger.LogInformation("# of Categories: {numCategories}", categoryCount);
            return 0;
        }
        catch(Exception ex){
            logger.LogError("The following exception occured:\n{Exception}", ex.ToString());
            return 1;
        }
        finally{
        }
    }
}
