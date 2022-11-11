using Lesson4;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var connectionString = "Data Source=91.219.6.251\\SQLEXPRESS; Initial Catalog=SimpleLogst; User Id=silog; Password=1234";

var conn = new SqlConnection(connectionString);
conn.Open();

using (AppDBContext context = new AppDBContext(connectionString))
{
    context.clients.Add(new Clients()
        {
            id = 1,
            firstName = "Ivanov"
        });

    context.clients.Add(new Clients()
        {
            id = 2,
            firstName = "Petrov"
        });

    context.clients.Add(new Clients()
        {
            id = 3,
            firstName = "Belov"
        });

    context.clients.Add(new Clients()
        {
            id = 4,
            firstName = "Smirnov"
        });


}