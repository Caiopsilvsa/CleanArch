using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Sql.Queries;

public static class ContactQueries
{
    public static string AllContact => "SELECT * FROM [Contact] (NOLOCK)";
    public static string ContactById => "SELECT * FROM [Contact] (NOLOCK) WHERE [ContactID] = @ContactID";
    public static string AddContact => @"INSERT INTO Contact (ContactID, FirstName, LastName, Email, PhoneNumber)
                                          VALUES (@ContactID, @FirstName, @LastName, @Email, @PhoneNumber)";
    public static string DeleteContact => @"DELETE FROM [Contact] WHERE [ContactID] = @ContactId";

    public static string UpdateContact =>
      @"UPDATE [Contact] 
        SET [FirstName] = @FirstName, 
            [LastName] = @LastName, 
            [Email] = @Email, 
            [PhoneNumber] = @PhoneNumber
        WHERE [ContactId] = @ContactId";
}
