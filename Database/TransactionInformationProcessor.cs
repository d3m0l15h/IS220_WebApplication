using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public class TransactionInformationProcessor : Processor<TransactionInfomation>
{
    public TransactionInformationProcessor(MyDbContext db) : base(db)
    {
        SetDefaultDatabaseContext(db.TransactionInfomations);
        SetDefaultDatabaseTable("Transaction_information");
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
            queryCondition = "TRANSACTION_TYPE.ID = TRANSACTION_INFORMATION.TYPEID AND TRANSACTION_INFORMATION.ID = TRANSACTION.TRANSACTIONINFOID";
        }
        else
        {
            queryCondition = queryCondition + " AND TRANSACTION_TYPE.ID = TRANSACTION_INFORMATION.TYPEID AND TRANSACTION_INFORMATION.ID = TRANSACTION.TRANSACTIONINFOID";
        }
        return Select("TRANSACTION_INFORMATION.*", from, quantity, queryCondition, sortQuery, "TRANSACTION_INFORMATION, TRANSACTION_TYPE, TRANSACTION", GetDefaultDatabaseContext());
    }

    public override int CountData(string queryCondition)
    {
        return Count(queryCondition, GetDefaultDatabaseTable());
    }
}