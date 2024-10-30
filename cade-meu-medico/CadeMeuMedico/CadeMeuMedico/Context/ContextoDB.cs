using CadeMeuMedico.Models;
using CadeMeuMedico.Shared;
using FirebirdSql.Data.FirebirdClient;
using System.Runtime.CompilerServices;

namespace CadeMeuMedico.Context
{
    public class ContextoDB
    {
        public string StrConexao { get; set; }
        public FbConnection Conexao{ get; set;}
        public FbCommand Comando { get; set;}
        public FbDataReader? Reader{ get; set; }

        public ContextoDB()
        {
            this.StrConexao = Tools.StrConexao;
            this.Conexao = new FbConnection(this.StrConexao);
            this.Comando = new FbCommand();
            this.Comando.Connection = Conexao;
        }

        public String? GetNewGenerator(string nomeGeneratorFirebird)
        {
            string query = $"SELECT GEN_ID({nomeGeneratorFirebird}, 1) FROM RDB$DATABASE;";

            try
            {
                string id="";
                ExecuteReader(query);
                if (Reader != null) while (Reader.Read()) id = Reader.GetString(0);
                return id;
            }
            catch (Exception)
            {
                throw;
            }
            finally {CloseConnection();}

        }

        public void ExecuteReader(string query)
        {
            Conexao.Open();
            Comando.CommandText = query;
            Reader = Comando.ExecuteReader();
        }

        public void CloseConnection()
        {
            Conexao.Close();
        }

        public void ExecuteNonQuery(string query)
        {
            Conexao.Open();
            Comando.CommandText = query;
            Comando.Prepare();
            Comando.ExecuteNonQuery();
        }

    }
}
