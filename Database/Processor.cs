using System.Collections;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;

using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Database;

public abstract class Processor<TEntity> where TEntity : class
{
    private readonly MyDbContext _db;
    private string DefaultDatabaseTable { get; set; } = null!;
    private dynamic DefaultDatabaseContext { get; set; } = null;

    protected Processor(MyDbContext db)
    {
        _db = db;
    }
    
    protected dynamic GetDefaultDatabaseContext()
    {
        return DefaultDatabaseContext;
    }
    
    protected void SetDefaultDatabaseContext(dynamic value)
    {
        DefaultDatabaseContext = value;
    }
    protected void SetDefaultDatabaseTable(string value)
    {
        DefaultDatabaseTable = value;
    }
    protected string GetDefaultDatabaseTable()
    {
        return DefaultDatabaseTable;
    }

    public abstract Response InsertData(Dictionary<string, string> columnValueMap, bool isCommit);

    protected Response Insert(Dictionary<string, string> columnValueMap, string table, bool isCommit) {
        var columnsValuesList = Utils.Utils.GetKeysValuesFromDictionary(columnValueMap);

        var columns = columnsValuesList[0];
        var values = columnsValuesList[1];

        var insertColumns = string.Join(", ", columns);
        var insertValues = "'" + string.Join("', '", values) + "'";

        var query = $"INSERT INTO {table} ({insertColumns}) VALUES ({insertValues})";
        try {
            Console.WriteLine(query);
            var rowsAffected = _db.Database.ExecuteSqlRaw(query + ";");
            Console.WriteLine($"Rows insert: {rowsAffected}");
            return new Response("Ok", StatusCode.Ok);
        } catch (Exception e) {
            Console.WriteLine(e);
            return new Response(e.ToString(), StatusCode.BadRequest);
        }
    }

    private static string ConstructUpdateSqlSetStatement(List<string> columns, List<string> values) {
        var setStatement = "";
        for (var i = 0 ; i < columns.Count; ++i) {
            setStatement += $"{columns[i]} = '{values[i]}'";
            if (i < columns.Count - 1) {
                setStatement += ", ";
            }
        }
        return setStatement;
    }
    public abstract Response UpdateData(Dictionary<string, string> columnValueDictionary, string queryCondition, bool isCommit);

    protected Response Update (Dictionary<string, string> columnValueMap, string queryCondition, string table,  bool isCommit) {
        var columnsValuesList = Utils.Utils.GetKeysValuesFromDictionary(columnValueMap);

        var columns = columnsValuesList[0];
        var values = columnsValuesList[1];
        
        var query = $"UPDATE {table} SET {ConstructUpdateSqlSetStatement(columns, values)} WHERE {queryCondition}";
        
        try {
           Console.WriteLine(query);
           var rowsAffected = _db.Database.ExecuteSqlRaw(query + ";");
           Console.WriteLine($"Rows updated: {rowsAffected}");
            return new Response("Ok", StatusCode.Ok);
        } catch (Exception e) {
            Console.WriteLine(e);
            return new Response(e.ToString(), StatusCode.BadRequest);
        }

    }
    public abstract Response DeleteData(string queryCondition, bool isCommit);

    protected Response Delete(string queryCondition, string table, bool isCommit) {
        var query = $"DELETE FROM {table} WHERE {queryCondition}";
        
        try {
            Console.WriteLine(query);
            var rowsAffected = _db.Database.ExecuteSqlRaw(query + ";");
            Console.WriteLine($"Rows deleted: {rowsAffected}");
            return new Response("Ok", StatusCode.Ok);
        } catch (Exception e) {
            Console.WriteLine(e);
            return new Response(e.ToString(), StatusCode.BadRequest);
        }
    }

    protected static Response Select<T> (string values, int from, int quantity, string queryCondition, string sortQuery, string table,DbSet<T> context) where T : class
    {
        
        var query = $"SELECT {values} FROM {table}";
        if (!string.IsNullOrEmpty(queryCondition)) {
            query = query + " WHERE " + queryCondition;
        }
        if (!string.IsNullOrEmpty(sortQuery)) {
            query = query + " ORDER BY " + sortQuery;
        }
        if (quantity > -1) {
            query = query + $" LIMIT {from}, {quantity}";
        }
       
        var result = new List<List<string>>();
        
        try {
            Console.WriteLine(query);
            var data = context.FromSqlRaw(query + ";").ToList();
            foreach (var res in data)
            {
                Console.WriteLine($"{res}");
            }
            
            if (data.Count > 0)
            {
               
                var columnNames = data[0].GetType().GetProperties().Select(p => p.Name).ToList();
                var columnTypes = data[0].GetType().GetProperties().Select(p => p.PropertyType.Name).ToList();
                
                result.Add(columnNames);
                result.Add(columnTypes);
                
                foreach (var row in data)
                {
                    
                    var val = new List<string?>();
                    foreach (var columnName in columnNames)
                    {
                        var property = row.GetType().GetProperty(columnName);
                        
                        if (property != null)
                        {
                            var value = row.GetType().GetProperty(columnName)?.GetValue(row);
                            
                                Console.WriteLine( columnName + "  " + value);
                                val.Add(value != null ? value.ToString() : string.Empty);
                            
                           
                            
                        }
                        else
                        {
                            // Console.WriteLine($"Column '{columnName}' not found.");
                            val.Add(string.Empty); 
                        }
                
                    }
                    
                    result.Add(val!);
                }
            }
        } catch (Exception e) {
            Console.WriteLine(e);
            return new Response(e.ToString(), StatusCode.BadRequest);
        }
        
        return new Response("Ok", StatusCode.Ok, result);
    }
    public abstract Response GetData(int from, int quantity, string queryCondition, string sortQuery);

    protected int Count(string queryCondition, string table) {
        var query = $"SELECT COUNT(*) FROM {table}";
        
        try {
           
            if (!string.IsNullOrEmpty(queryCondition))
            {
                query = query + " WHERE " + queryCondition;
            }
            var data = _db.Aspnetusers.FromSqlRaw(query).ToList();

            return data.Count;
           
        } catch (Exception e) {
            Console.WriteLine(e);
        }
        return 0;
    }
    public abstract int CountData(string queryCondition);
    public List<string> NormColumnNames(List<string> columnNames, string tableName) {
        for (var i=0;i<columnNames.Count;++i) {
            columnNames[i] = $"{tableName[..tableName.Length]}_{columnNames[i]}";

        }
        return columnNames;
    }
}


   