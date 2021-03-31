using Dapper;
using DapperLesson.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace DapperLesson.Data
{
    public class TeamDataAccess : DbDataAccess<Team>
    {
        public override ICollection<Team> Select()
        {
            using (var sqlConnection = new SqlConnection())
            {
                //sqlConnection.Open(); - In dapper that is not required
                var sql = "Select * from Teams";
                //Creating of SqlCommand() is not Required in DAPPER
                return sqlConnection.Query<Team>(sql).ToList();
            }
        }
        public override void Insert(Team team)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.Execute("Insert into Teams (Id, Name) values (@Id, @Name)", team);
            }
        }
        public override void Update(Team entity)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.Execute("Update Teams set Id = @Id, Name =  @Name", entity);
            }
        }

        public override void Delete(Team entity)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.Execute("Delete from Teams where Id = @Id, Name = @Name", entity);
            }
        }
    }
}