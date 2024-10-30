using System.IO;
using Microsoft.Extensions.Logging;
// dotnet package add CsvHelper
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using DatabaseFun.Models;
using DatabaseFun.Providers;
using DatabaseFun.Services;

namespace DatabaseFun;

public class Service(
    ILoaderService<Category> categoryLoaderService,
    ILoaderService<User> userLoaderService,
    ILoaderService<ToDoItem> toDoItemLoaderService,
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

            var users = userLoaderService.GetAllRows();
            int userCount = 0;

            foreach(User user in users){
                logger.LogInformation("ID: {UserId}, Name: {Name}", user.UserId, user.Username );
                userCount++;
            }

            logger.LogInformation("# of Users: {numUsers}", userCount);

            var toDoItems = toDoItemLoaderService.GetAllRows();
            int toDoItemCount = 0;

            foreach(ToDoItem toDoItem in toDoItems){
                logger.LogInformation("ID: {UserId}, Name: {Name}", toDoItem.ItemId, toDoItem.Item );
                toDoItemCount++;
            }

            logger.LogInformation("# of To Do Items: {numUsers}", toDoItemCount);

            var joined = toDoItems
                .Join(
                    categories,
                    todoItem => todoItem.CategoryId,
                    category => category.CategoryId,
                    (todoItem, category) => new {
                        ItemId = todoItem.ItemId,
                        Item = todoItem.Item,
                        CategoryName = category.Name,
                        UserId = todoItem.UserId
                    }
                )
                .Join(
                    users,
                    toDoItem => toDoItem.UserId,
                    user => user.UserId,
                    (toDoItem, user) => new {
                    ToDoItemId = toDoItem.ItemId,
                        ToDoItem = toDoItem.Item,
                        CategoryName = toDoItem.CategoryName,
                        Username = user.Username
                    }
                );

                using var writer = new StreamWriter("../test-data/joined.csv");
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(joined);
                writer.Flush();

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
