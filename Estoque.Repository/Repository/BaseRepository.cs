using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repository;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Estoque.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public virtual string TableName { get; set; }

        #region context
        private SqlConnection cn;

        private void Conexao()
        {
            cn = new("Server=DESKTOP-R9JFMSC\\SQLEXPRESS;Database=MVCEstoque;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public async Task<SqlConnection> AbrirConexaoAsync()
        {
            try
            {
                Conexao();
                await cn.OpenAsync();
                return cn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task FecharConexaoAsync()
        {
            try
            {
                await cn.CloseAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        #endregion

        public virtual async Task<T> Alterar(T entity)
        {
            try
            {
                string json = JsonConvert.SerializeObject(entity);
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                string query = "";

                foreach (var objeto in values)
                {
                    if (values.Last().Equals(objeto))
                    {
                        query += objeto.Key + " = ";
                        query += "'" + objeto.Value + "'";
                    }
                    else
                    {
                        query += objeto.Key + " = ";
                        query += "'" + objeto.Value + "', ";
                    }
                }

                await AbrirConexaoAsync();
                SqlCommand command = new($"update {TableName} set {query} where Id like '{entity.Id}'", cn);
                await command.ExecuteNonQueryAsync();
                return entity;
            }
            catch(Exception e)
            {
                throw new Exception();
            }
            finally
            {
                await FecharConexaoAsync();
            }
        }

        public async Task<T> Incluir(T entity)
        {
            try
            {
                string json = JsonConvert.SerializeObject(entity);
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                string atributos = "";
                string valores = "";

                foreach (var objeto in values)
                {
                    if (values.Last().Equals(objeto))
                    {
                        atributos += objeto.Key;
                        valores += "'" +objeto.Value + "'";
                    }
                    else
                    {
                        atributos += objeto.Key + ", ";
                        valores += "'"+objeto.Value + "', ";
                    }
                }

                SqlConnection cn = await AbrirConexaoAsync();
                SqlCommand command = new($"insert into {TableName}({atributos}) values({valores})", cn);
                await command.ExecuteNonQueryAsync();      

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                await FecharConexaoAsync();
            }
        }

        public async Task<T> SelecionarPorId(Guid id)
        {
            try
            {
                SqlConnection cn = await AbrirConexaoAsync();
                SqlCommand command = new($"select * from {TableName} where id like '{id}'", cn);
                SqlDataReader rdr = await command.ExecuteReaderAsync();
                string json = "";
                
                while (rdr.Read())
                {
                    IEnumerable<Dictionary<string, object>> objetos = SerializarDataReader(rdr);
                    json = JsonConvert.SerializeObject(objetos.ToList()[0]);
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                await FecharConexaoAsync();
            }
        }

        public async Task<List<T>> SelecionarTudo()
        {
            try
            {
                SqlConnection cn = await AbrirConexaoAsync();
                SqlCommand command = new($"select * from {TableName}", cn);
                SqlDataReader rdr = await command.ExecuteReaderAsync();
                List<T> lista = new();

                while (rdr.Read())
                {
                    IEnumerable<Dictionary<string, object>> x = SerializarDataReader(rdr);

                    foreach (var ob in x)
                    {
                        string json = JsonConvert.SerializeObject(ob);
                        lista.Add(JsonConvert.DeserializeObject<T>(json));
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                await FecharConexaoAsync();
            }
        }

        public IEnumerable<Dictionary<string, object>> SerializarDataReader(SqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            do
                results.Add(SerializarDados(cols, reader));
            while (reader.Read());

            return results;
        }

        private Dictionary<string, object> SerializarDados(IEnumerable<string> cols,
                                                SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }
    }
}