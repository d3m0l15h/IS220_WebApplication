using System.Transactions;
using IS220_WebApplication.Context;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;
using Transaction = IS220_WebApplication.Models.Transaction;

namespace IS220_WebApplication.Database;

public class TransactionProcessor : Processor<Transaction>
{
    public TransactionProcessor(MyDbContext db) : base(db)
    {
        SetDefaultDatabaseContext(db.Transactions);
        SetDefaultDatabaseTable("Transaction");
        
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
            queryCondition = "TRANSACTION.USERID = USER.ID AND TRANSACTION.TRANSINFOID = TRANSACTION_INFORMATION.ID";
        }
        else
        {
            queryCondition = queryCondition + " AND TRANSACTION.USERID = USER.ID AND TRANSACTION.TRANSINFOID = TRANSACTION_INFORMATION.ID";
        }
        return Select("TRANSACTION.*", from, quantity, queryCondition, sortQuery, "TRANSACTION, USER, TRANSACTION_INFORMATION", GetDefaultDatabaseContext());
        
        
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}