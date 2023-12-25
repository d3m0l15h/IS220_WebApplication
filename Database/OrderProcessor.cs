using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
namespace IS220_WebApplication.Database;

public class Order : Processor<Order>
{
    protected readonly MyDbContext _db;
    public Order(MyDbContext db) : base(db)
    {
        _db = db;
        SetDefaultDatabaseTable("Order");
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
    public override int CountData(string filter)
    {
        // Implement the method based on your requirements.
        // This is just a placeholder implementation.
        return _db.Addresses.Count();
    }
    public override Response GetData(int from, int quantity, string queryCondition, string sortQuery)

    {
        if (queryCondition.Length == 0)
        {
            queryCondition = "ADDRESS.USERID = USER.ID AND ADDRESS.GAMEID = GAME.ID";
        }
        else
        {
            queryCondition = queryCondition + " AND ADDRESS.USERID = USER.ID AND ADDRESS.GAMEID = GAME.ID";
        }

        return Select("ADDRESS.*", from, quantity, queryCondition, sortQuery, "ADDRESS, USER, GAME", GetDefaultDatabaseContext());
    }
    
}