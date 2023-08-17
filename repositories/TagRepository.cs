using System.Data;
using Gallotube.Interfaces;
using Gallotube.Models;
using MySql.Data.MySqlClient;

namespace Gallotube.Repositories;

public class TagRepository : ITagRepository
{
    readonly string connectionString = "server=localhost;port=3306;database=Gallotubedb;uid=root;pwd=''";

    public void Create(Genre model)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "insert into Tag(Name) values (@Name)";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Name", model.Name);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void Delete(int? id)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "delete from Tag where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", id);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Genre> ReadAll()
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from Tag";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        
        List<Tag> tag = new();
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Tag tag = new()
            {
                Id = reader.GetByte("id"),
                Name = reader.GetString("name")
            };
            tag.Add(tag);
        }
        connection.Close();
        return tag;
    }

    public Tag ReadById(int? id)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from Genre where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", id);
        
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        reader.Read();
        if (reader.HasRows)
        {
            Tag tag = new()
            {
                Id = reader.GetByte("id"),
                Name = reader.GetString("name")
            };
            connection.Close();
            return tag;
        }
        connection.Close();
        return null;
    }

    public void Update(Tag model)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "update Tag set Name = @Name where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", model.Id);
        command.Parameters.AddWithValue("@Name", model.Name);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}
