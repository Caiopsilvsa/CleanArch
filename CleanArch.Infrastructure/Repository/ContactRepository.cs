using CleanArch.Application.Repositories;
using CleanArch.Core.Entities;
using CleanArch.Sql.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CleanArch.Infrastructure.Repository;

public class ContactRepository : IContactRepository
{
    private readonly IConfiguration _configuration;

    public ContactRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> AddAsync(Contact entity)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultCollection")))
        {
            connection.Open();

             var result = await connection.QueryAsync<Contact>(ContactQueries.AddContact,entity);

            return result.ToString();
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultCollection")))
        {
            connection.Open();

            var result = await connection.QueryAsync(ContactQueries.DeleteContact, new { ContactId = id });

        }
    }

    public async Task<IReadOnlyList<Contact>> GetAllAsync()
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultCollection")))
        {
            connection.Open();

            var result = await connection.QueryAsync<Contact>(ContactQueries.AllContact);

            return result.ToList();
        }
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultCollection")))
        {
            connection.Open();

            var result = await connection.QueryFirstAsync<Contact>(ContactQueries.ContactById, new {ContactId = id});

            return result;

        }
    }

    public async Task<string> UpdateAsync(Contact contact)
    {
        using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultCollection")))
        {
            connection.Open();

            var result = await connection.QueryAsync<Contact>(ContactQueries.UpdateContact, contact);

            return result.ToString();

        }
    }
}
