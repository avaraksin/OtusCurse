using Lesson4;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var connectionString = "Data Source=91.219.6.251\\SQLEXPRESS; Initial Catalog=Otus; User Id=otuslogin; Password=1234";

InitialDbSet initialDbSet = new InitialDbSet(connectionString);

await initialDbSet.CreateTables();
await initialDbSet.InitialFillTables();



