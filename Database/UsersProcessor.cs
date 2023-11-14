using IS220_WebApplication.Context;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public class UsersProcessor : Processor
{
    public UsersProcessor(MyDbContext db) : base(db)
    {
        SetDefaultDatabaseContext(db.Users);
        SetDefaultDatabaseTable("User");
        
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
        // if (queryCondition.Length == 0) {
        //     queryCondition = "USERS.USER_CATEGORY_ID = USER_CATEGORY.ID";
        // } else {
        //     queryCondition = queryCondition + " AND USERS.USER_CATEGORY_ID = USER_CATEGORY.ID";
        // }
        return Select("*", from, quantity, queryCondition, sortQuery, GetDefaultDatabaseTable(), GetDefaultDatabaseContext());
        
        
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}