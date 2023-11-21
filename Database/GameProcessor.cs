using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public class GameProcessor : Processor<Game>
{
    public GameProcessor(MyDbContext db) : base(db)
    {
       SetDefaultDatabaseContext(db.Games);
        SetDefaultDatabaseTable("Game");
        
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
            queryCondition = "GAME.ID = GAME_CATEGORY.GAME AND GAME_CATEGORY.CATEGORY = CATEGORY.ID";
        }
        else
        {
            queryCondition = queryCondition + " AND GAME.ID = GAME_CATEGORY.GAME AND GAME_CATEGORY.CATEGORY = CATEGORY.ID";
        }

        return Select("GAME.*", from, quantity, queryCondition, sortQuery, "GAME, GAME_CATEGORY, CATEGORY", GetDefaultDatabaseContext());
        
        
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}