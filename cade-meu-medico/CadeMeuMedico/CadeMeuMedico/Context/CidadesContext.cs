using CadeMeuMedico.Models;

namespace CadeMeuMedico.Context
{
    public class CidadesContext : ContextoDB
    {
        public List<Cidades>? GetList()
        {
            string selectCidades = "SELECT * FROM CIDADES";
            List<Cidades> listaCidades = [];

            try
            {
                ExecuteReader(selectCidades);

                while (Reader.Read())
                {
                    Cidades cidade = new();
                    cidade.Id = Reader.GetInt32(0);
                    cidade.IdEstado = Reader.GetInt32(1);
                    cidade.Cidade = Reader.GetString(2);
                    listaCidades.Add(cidade);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro \n" + ex);
                return null;
            }
            finally
            {
                CloseConnection();
            }
            return listaCidades;
        }

        public Cidades GetByID(int id)
        {
            string query = $"SELECT * FROM CIDADES WHERE ID={id}";
            Cidades cidade = new();

            try
            {
                ExecuteReader(query);
                while (Reader.Read())
                {
                    cidade.Id= Reader.GetInt32(0);
                    cidade.IdEstado= Reader.GetInt32(1);
                    cidade.Cidade= Reader.GetString(2);
                }
                return cidade;
            }
            catch (Exception)
            {
                throw;
            }
            finally { CloseConnection(); }

        }

    }
}
