using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public class GameOwnerProcessor : Processor<GameOwned>
{
    public GameOwnerProcessor(MyDbContext db) : base(db)
    {
        SetDefaultDatabaseContext(db.GameOwneds);
        SetDefaultDatabaseTable("Game_owned");
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
            queryCondition = "GAME_OWNED.USERID = USER.ID AND GAME_OWNED.GAMEID = GAME.ID";
        }
        else
        {
            queryCondition = queryCondition + " AND GAME_OWNED.USERID = USER.ID AND GAME_OWNED.GAMEID = GAME.ID";
        }

        return Select("GAME_OWNED.*", from, quantity, queryCondition, sortQuery, "GAME_OWNED, USER, GAME", GetDefaultDatabaseContext());
        
        
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}