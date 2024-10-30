using CadeMeuMedico.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.PortableExecutable;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CadeMeuMedico.Context
{
    public class MedicosContext : ContextoDB
    {
        public List<Medicos>? GetList()
        {
            string selectMedicos = "SELECT M.*,E.ESPECIALIDADE,C.CIDADE FROM MEDICOS M\r\nINNER " +
                "JOIN ESPECIALIDADES E\r\nON M.IDESPECIALIDADE = E.ID \r\nINNER JOIN CIDADES C\r\n" +
                "ON M.IDCIDADE = C.ID";

            List<Medicos> listaMedicos = [];

            try
            {
                ExecuteReader(selectMedicos);

                while (Reader.Read())
                {
                    Medicos medico = new();
                    medico.Id = Reader.GetInt32(0);
                    medico.IdEspecialidade = Reader.GetInt32(1);
                    medico.Crm = Reader.GetString(2);
                    medico.Nome = Reader.GetString(3);
                    medico.Endereco = Reader.GetString(4);
                    medico.Bairro = Reader.GetString(5);
                    medico.IdCidade = Reader.GetInt32(6);
                    medico.Email = Reader.GetString(7);
                    medico.AtendePorConvenio = Reader.GetBoolean(8);
                    medico.TemClinica = Reader.GetBoolean(9);
                    medico.WebSiteBlog = Reader.GetString(10);

                    medico.Especialidade = new();
                    medico.Especialidade.Id = medico.IdEspecialidade;
                    medico.Especialidade.Especialidade = Reader.GetString(11);

                    medico.Cidade = new();
                    medico.Cidade.Id = medico.IdCidade;
                    medico.Cidade.Cidade = Reader.GetString(12);

                    listaMedicos.Add(medico);
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
            return listaMedicos;
        }

        public bool Insert(Medicos medico)
        {
            try
            {
                string? NewId = GetNewGenerator("GEN_MEDICOS");

                string query = $"INSERT INTO MEDICOS VALUES({NewId},{medico.IdEspecialidade},'{medico.Crm}','{medico.Nome}'," +
                    $"'{medico.Endereco}','{medico.Bairro}',{medico.IdCidade},'{medico.Email}',{medico.AtendePorConvenio},{medico.TemClinica},'{medico.WebSiteBlog}');";
                
                ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro \n" + ex);
                return false;
            }
            finally { CloseConnection();}
            return true;

        }

        public Medicos? GetById(int id){ return GetList().FirstOrDefault(m => m.Id == id); }

        public bool Update(Medicos medico)
        {
            try
            {
                string query = $"UPDATE MEDICOS SET IDESPECIALIDADE={medico.IdEspecialidade},CRM='{medico.Crm}',NOME='{medico.Nome}'," +
                    $"ENDERECO='{medico.Endereco}',BAIRRO='{medico.Bairro}',IDCIDADE={medico.IdCidade},EMAIL='{medico.Email}',ATENDEPORCONVENIO={medico.AtendePorConvenio},TEMCLINICA={medico.TemClinica},WEBSITEBLOG='{medico.WebSiteBlog}' " +
                    $"WHERE IDMEDICO={medico.Id}";

                ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro \n" + ex);
                return false;
            }
            finally { CloseConnection(); }
            return true;
        }

        public bool Delete(Medicos medico)
        {
            try
            {
                ExecuteNonQuery($"DELETE FROM MEDICOS WHERE IDMEDICO={medico.Id}");
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally { CloseConnection(); }

        }

    }

}
