using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public class PublishersProcessor : Processor<Publisher>
{
    public PublishersProcessor(MyDbContext db) : base(db)
    {
        SetDefaultDatabaseContext(db.Publishers);
        SetDefaultDatabaseTable("Publisher");
        
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
            queryCondition = "PUBLISHER.ID = GAME.PUBLISHER";
        }
        else
        {
            queryCondition = queryCondition + " AND PUBLISHER.ID = GAME.PUBLISHER";
        }
        return Select("PUBLISHER.*", from, quantity, queryCondition, sortQuery, "PUBLISHER, GAME", GetDefaultDatabaseContext());
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}