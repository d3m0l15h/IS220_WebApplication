using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public class TransactionTypeProcessor : Processor<TransactionType>
{
    public TransactionTypeProcessor(MyDbContext db) : base(db)
    {
        SetDefaultDatabaseContext(db.TransactionTypes);
        SetDefaultDatabaseTable("Transaction_type");
        
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
            queryCondition = "TRANSACTION_TYPE.ID = TRANSACTION_INFORMATION.TYPEID";
        }
        else
        {
            queryCondition = queryCondition + " AND TRANSACTION_TYPE.ID = TRANSACTION_INFORMATION.TYPEID";
        }
        return Select("TRANSACTION_TYPE.*", from, quantity, queryCondition, sortQuery, "TRANSACTION_TYPE, TRANSACTION_INFORMATION", GetDefaultDatabaseContext());
        
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}