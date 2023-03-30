using Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Tipo
    {
        public int nTipo;
        public string nome;

        BaseDados bd;

        public Tipo()
        {
            bd = new BaseDados();
        }

        public DataTable listaTipo()
        {
            string sql = "SELECT nTipo, nome FROM tipo";
            return bd.devolveSQL(sql);
        }

        public DataTable devolveNome(int nTipo)
        {
            string sql = "SELECT * FROM tipo WHERE nTipo=@nTipo";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nTipo",SqlDbType=SqlDbType.Int,Value=nTipo }
            };
            return bd.devolveSQL(sql, parametros);
        }
        public DataTable devolveTipo()
        {
            string sql = "SELECT nTipo, nome FROM tipo";
            return bd.devolveSQL(sql);
        }

        internal void Adicionar(string nome)
        {
            try
            {
                string sql = @"INSERT INTO tipo(nome)
                            VALUES (@nome)";
                List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
            };
                bd.executaSQL(sql, parametros);
            }
            catch (SqlException ex) when (ex.Number == 2601)
            {
                throw new Exception("Serviço já existente");
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new Exception("Serviço já existente");
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao Adicionar. Tente novamente mais tarde.");
            }
        }

        internal DataTable VerNtipo()
        {
            string sql = "SELECT Top(1) * FROM tipo ORDER BY 1 DESC";
            return bd.devolveSQL(sql);
        }
    }
}