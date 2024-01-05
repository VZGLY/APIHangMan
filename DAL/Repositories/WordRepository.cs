using DAL.Models;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories;

public class WordRepository
{

    private readonly string _connectionString;
    public WordRepository(string cs)
    {
        _connectionString = cs;
    }

    public bool Add(WordEntity entity)
    {

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Words VALUES (@word, DEFAULT)";

                cmd.Parameters.AddWithValue("word", entity.Word);
                
                conn.Open();

                int result = cmd.ExecuteNonQuery();
                
                conn.Close();

                return result == 1;
            }
        }
    }


    public List<WordEntity> GetAll()
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Words";

                List<WordEntity> words = new List<WordEntity>();
                
                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    WordEntity word = new WordEntity()
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Word = Convert.ToString(rdr["Word"])!,
                        Date = Convert.ToDateTime(rdr["date"])
                    };
                    
                    words.Add(word);
                }
                
                conn.Close();

                return words;
            }
        }
    }

    public bool Delete(WordEntity entity)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Words WHERE id = @id";

                cmd.Parameters.AddWithValue("id", entity.Id);
                
                conn.Open();

                int result = cmd.ExecuteNonQuery();
                
                conn.Close();

                return result == 1;
            }
        }
    }


    public WordEntity? GetById(int id)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Words WHERE id = @id";

                cmd.Parameters.AddWithValue("id", id);
                
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                WordEntity? entity = null;

                while (reader.Read())
                {
                    entity = new WordEntity()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Word = Convert.ToString(reader["word"]),
                        Date = Convert.ToDateTime(reader["date"])
                    };
                }
                
                conn.Close();

                return entity;
            }
        }
    }

    public WordEntity GetRandom()
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP 1 * FROM Words ORDER BY NEWID()";
                
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                WordEntity? entity = null;

                while (reader.Read())
                {
                    entity = new WordEntity()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Word = Convert.ToString(reader["word"]),
                        Date = Convert.ToDateTime(reader["date"])
                    };
                }
                
                conn.Close();

                return entity;
            }
        }
    }
}