using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public class GameCategoryProcessor : Processor<GameCategory>
{
    public GameCategoryProcessor(MyDbContext db) : base(db)
    {
        SetDefaultDatabaseTable("Game_category");
        //SetDefaultDatabaseContext(db.GameCategories);
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
            queryCondition = " GAME_CATEGORY.CATEGORYID = CATEGORY.ID AND GAME_CATEGORY.GAMEID = GAME.ID";
        }
        else
        {
            queryCondition = queryCondition + " AND GAME_CATEGORY.CATEGORYID = CATEGORY.ID AND GAME_CATEGORY.GAMEID = GAME.ID";
        }
        return Select("GAME_CATEGORY.*", from, quantity, queryCondition, sortQuery, "GAME_CATEGORY, GAME, CATEGORY", GetDefaultDatabaseContext());
        
        
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}