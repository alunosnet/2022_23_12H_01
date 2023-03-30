using Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Utilizador
    {
        public int id;
        public string nome;
        public string email;
        public string morada;
        public string nif;
        public string password;
        public int tipo;
        public int perfil;
        public int sal;

        BaseDados bd;

        public Utilizador()
        {
            bd = new BaseDados();
        }

        //adicionar
        public void Adicionar(int tipos)
        {
            try
            {

                string sql = @"INSERT INTO utilizadores(email,nome,morada,nif,password,perfil,tipo, sal)
                            VALUES (@email,@nome,@morada,@nif,HASHBYTES('SHA2_512', concat(@password, @sal)),@perfil,@tipo, @sal)";
                List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.email
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@morada",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.morada
                },
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@password",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.password
                },
                new SqlParameter()
                {
                    ParameterName="@perfil",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.perfil
                },
                new SqlParameter()
                {
                    ParameterName="@tipo",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=tipos
                },
                new SqlParameter()
                {
                    ParameterName="@sal",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.sal
                }
            };
                bd.executaSQL(sql, parametros);
            }
            catch (SqlException ex) when (ex.Number == 2601)
            {
                throw new Exception("Email ou Nif já existente");
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new Exception("Email ou Nif já existente");
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao Registar. Tente novamente mais tarde.");
            }
        }

        internal DataTable ListaTodosUtilizadores()
        {
            return bd.devolveSQL("SELECT * FROM Utilizadores");
        }
        public DataTable devolveDadosUtilizador(int id)
        {
            string sql = "SELECT * FROM utilizadores WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            if (dados.Rows.Count == 0)
            {
                return null;
            }
            return dados;
        }
        public void recuperarPassword(string email, string guid)
        {
            string sql = "UPDATE utilizadores set lnkRecuperar=@lnk WHERE email=@email";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
        public DataTable devolveDadosUtilizadorRecuperar(string email)
        {
            string sql = "SELECT * FROM utilizadores WHERE email=@email";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return dados;
        }
        public void removerUtilizador(int id)
        {
            string sql = "DELETE FROM Utilizadores WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value= id},
            };
            bd.executaSQL(sql, parametros);
        }
        public void atualizarUtilizador()
        {
            string sql = @"UPDATE utilizadores SET nome=@nome,morada=@morada,nif=@nif 
                            WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@morada",SqlDbType=SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id },
            };
            bd.executaSQL(sql, parametros);
        }

        internal DataTable VerTipo(int id)
        {
            string sql = "SELECT tipo FROM utilizadores WHERE id = @id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            return bd.devolveSQL(sql, parametros);
        }

        internal void atualizarPassword(string guid, string password)
        {
            string sql = "UPDATE utilizadores set password=HASHBYTES('SHA2_512',concat(@password, sal)),lnkRecuperar=null WHERE lnkRecuperar=@lnk";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password},
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }

        internal DataTable ListaTodosUtilizadoresNome(string pesq)
        {
            string sql = "SELECT * FROM utilizadores WHERE nome like @pesq OR email like @pesq";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@pesq",SqlDbType=SqlDbType.VarChar,Value="%" + pesq + "%" }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return dados;
        }
    }
}