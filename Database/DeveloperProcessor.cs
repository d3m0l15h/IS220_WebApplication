using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public class DeveloperProcessor : Processor<Developer>
{
    public DeveloperProcessor(MyDbContext db) : base(db)
    {
        SetDefaultDatabaseContext(db.Developers);
        SetDefaultDatabaseTable("Developer");
        
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
            queryCondition = " DEVELOPER.ID = GAME.DEVELOPER";
        }
        else
        {
            queryCondition = queryCondition + " AND DEVELOPER.ID = GAME.DEVELOPER";
        }
        return Select("DEVELOPER.*", from, quantity, queryCondition, sortQuery, "DEVELOPER, GAME", GetDefaultDatabaseContext());
        
        
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}