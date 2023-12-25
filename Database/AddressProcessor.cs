using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Utils;

using System.Security.Claims;

using Microsoft.EntityFrameworkCore;
namespace IS220_WebApplication.Database;

public class AddressProcessor : Processor<Address>
{
    private readonly MyDbContext _db;
    public AddressProcessor(MyDbContext db) : base(db)
    {
        _db = db;
        SetDefaultDatabaseTable("Address");
    }
    // public override IEnumerable<Address> GetData(int start, int length, string sortColumn, string sortDirection)
    // {

    //     return _db.Addresses.Skip(start).Take(length).ToList();
    // }
    public Address? GetDefaultAddress(uint userId)
    {
        var defaultAddress = _db.Addresses
            .FirstOrDefault(a => a.Userid == userId && a.Isdefault == true);
        return defaultAddress;
    }
    public List<Address> GetNonDefaultAddresses(uint userId)
    {
        var nonDefaultAddress = _db.Addresses
            .Where(a => a.Userid == userId && a.Isdefault == false)
            .ToList();
        return nonDefaultAddress;
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
    // public override Response GetData(int start, int length, string sortColumn, string sortDirection)
    // {
    //     // Implement the method based on your requirements.
    //     // This is just a placeholder implementation.
    //     var data = _db.Addresses.Skip(start).Take(length).ToList();
    //     var response = new Response
    //     {
    //         Data = data,
    //         // Set other properties of the Response object as needed.
    //     };
    //     return response;
    // }
    public Response CreateAddress(Address address)
    {
        var response = new Response();
        try
        {

            var existingAddresses = _db.Addresses.Where(a => a.Userid == address.Userid).ToList();

            address.Isdefault = existingAddresses.Any();

            _db.Addresses.Add(address);
            _db.SaveChanges();
            response.SetStatusCode(StatusCode.Ok);
            response.SetMessage("Address created successfully");
        }
        catch (Exception e)
        {
            response.SetStatusCode(StatusCode.InternalServerError);
            response.SetMessage(e.Message);
        }
        return response;
    }
}