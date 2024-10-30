using CadeMeuMedico.Models;

namespace CadeMeuMedico.Context
{
    public class EspecialidadesContext : ContextoDB
    {
        public List<Especialidades>? GetList()
        {
            string selectEspecialidades = "SELECT * FROM ESPECIALIDADES;";
            List<Especialidades> listaEspecialidades = [];

            try
            {
                ExecuteReader(selectEspecialidades);

                while (Reader.Read())
                {
                    Especialidades especialidade = new();
                    especialidade.Id = Reader.GetInt32(0);
                    especialidade.Especialidade = Reader.GetString(1);
                    listaEspecialidades.Add(especialidade);
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
            return listaEspecialidades;
        }

    }
}
