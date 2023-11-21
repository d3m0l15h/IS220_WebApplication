using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public class CategoriesProcessor : Processor<Category>
{
    public CategoriesProcessor(MyDbContext db) : base(db)
    {
        SetDefaultDatabaseContext(db.Categories);
        SetDefaultDatabaseTable("Category");
        
    }

    public override Response InsertData(Dictionary<string, string> columnValueMap, bool isCommit)
    {
        return Insert(columnValueMap, GetDefaultDatabaseTable(), isCommit);
    }

    public override Response UpdateData(Dictionary<string, string> columnValueDictionary, string queryCondition, bool isCommit)
    {
        return Update(columnValueDictionary, queryCondition, GetDefaultDatabaseTable(), isCommit);
    }

    public override Response DeleteData(string queryCondition, bool isCommit)
    {
        return Delete(queryCondition, GetDefaultDatabaseTable(), isCommit);
    }

    public override Response GetData(int from, int quantity, string queryCondition, string sortQuery)
    {
        if (queryCondition.Length == 0) {
            queryCondition = " GAME_CATEGORY.USERID = CATEGORY.ID";
        }
        else
        {
            queryCondition = queryCondition + " AND GAME_CATEGORY.USERID = CATEGORY.ID";
        }
        return Select("CATEGORY.*", from, quantity, queryCondition, sortQuery, "CATEGORY, GAME_CATEGORY", GetDefaultDatabaseContext());
        
        
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}