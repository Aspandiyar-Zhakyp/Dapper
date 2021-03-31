using Dapper;
using DapperLesson.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DapperLesson.Data
{
    public class PlayerDataAccess : DbDataAccess<Player>
    {
        public override void Delete(Player entity)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.Execute("Delete from Players where Id = @Id, FullName = @FullName, Number = @Number, TeamId =  @TeamId", entity);
            }
        }

        public override void Insert(Player entity)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.Execute("Insert into Players (Id, FullName, Number, TeamId) values (@Id, @FullName, @Number, @TeamId)", entity);
            }
        }

        public override ICollection<Player> Select()
        {
            using (var sqlConnection = new SqlConnection())
            {
                return sqlConnection.Query<Player>("Select * from Players").ToList();
            }
        }

        public override void Update(Player entity)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.Execute("Update Players set Id = @Id, FullName = @FullName, Number = @Number, TeamId =  @TeamId", entity);
            }
        }
    }
}