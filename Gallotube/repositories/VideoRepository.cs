using System.Data;
using Gallotube.Interfaces;
using Gallotube.Models;
using MySql.Data.MySqlClient;

namespace Gallotube.Repositories;

public class VideoRepository : IVideoRepository
{
    readonly string connectionString = "server=localhost;port=3306;database=Gallotubedb;uid=root;pwd=''";

    public void Create(Video model)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "insert into Video (Título, TítuloOriginal, Descrição, Year, Duração, ClassificaçãoEtária, Foto) "
              + "values (@Título, @TítuloOriginal, @Descrição, @Year, @Duração, @ClassificaçãoEtária, @Foto)";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Título", model.Title);
        command.Parameters.AddWithValue("@TítuloOriginal", model.OriginalTitle);
        command.Parameters.AddWithValue("@Sinopse", model.Synopsis);
        command.Parameters.AddWithValue("@Year", model.Year);
        command.Parameters.AddWithValue("@Descrição", model.descricao);
        command.Parameters.AddWithValue("@Duração", model.Duracao);
        command.Parameters.AddWithValue("@Foto", model.Image);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void Delete(int? id)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "delete from Video where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", id);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Video> ReadAll()
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from Video";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        
        List<Video> videos= new();
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
             Video videos = new()
            {
                Id = reader.GetInt32("id"),
                Title = reader.GetString("título"),
                OriginalTitle = reader.GetString("TítuloOriginal"),
                Synopsis = reader.GetString("Sinopse"),
                VideoYear = reader.GetInt16("Year"),
                Description = reader.GetInt16("Descrição"),
                Duration = reader.GetByte("Descrição"),
                Image = reader.GetString("Foto")
            };
            videos.Add(Video);
        }
        connection.Close();
        return videos;
    }

    public Video ReadById(int? id)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from Video where Id = @Id";
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
            Video video = new();
            
                Id = reader.GetInt32("id");
                Title = reader.GetString("título");
                OriginalTitle = reader.GetString("TítuloOriginal");
                Synopsis = reader.GetString("Sinopse");
                VideoYear = reader.GetInt16("Year");
                Description = reader.GetInt16("Descrição");
                Duration = reader.GetByte("Descrição");
                Image = reader.GetString("imagem");
            };
            connection.Close();
            return  video ;
        }
        connection.Close();
        return null;
    

    public void Update(Video model)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "update Movie set "
                        + "Title = @Title, "
                        + "OriginalTitle = @OriginalTitle, "
                        + "Synopsis = @Synopsis, "
                        + "MovieYear = @MovieYear, "
                        + "Duration = @Duration, "
                        + "AgeRating = @AgeRating, "
                        + "Image = @Image "
                    + "where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Título", model.Title);
        command.Parameters.AddWithValue("@TítuloOriginal", model.OriginalTitle);
        command.Parameters.AddWithValue("@Sinopse", model.Synopsis);
        command.Parameters.AddWithValue("@Year", model.Year);
        command.Parameters.AddWithValue("@Descrição", model.Description);
        command.Parameters.AddWithValue("@Duração", model.Duration);
        command.Parameters.AddWithValue("@Foto", model.image);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}
