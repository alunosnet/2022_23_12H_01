using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glova_MOD15.Cliente
{
    internal class cliente
    {
        public int ncliente { get; set; }
        public string nome { get; set; }
        public string cod_postal { get; set; }
        public string localidade { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = @"SELECT * FROM cliente";
            return bd.devolveSQL(sql);
        }
        public static DataTable ListarTodos(BaseDados bd, int primeiroregisto, int ultimoregisto)
        {
            string sql = $@"SELECT ncliente,nome,codigo_postal,localidade,telefone,email FROM
                        (SELECT row_number() over (order by ncliente) as Num,* FROM cliente) as T
                        WHERE Num>={primeiroregisto} AND Num<={ultimoregisto}";
            return bd.devolveSQL(sql);
        }

        internal static int NrRegistos(BaseDados bd)
        {
            string sql = "SELECT count(*) as NrRegistos from cliente";
            DataTable dados = bd.devolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }

        public void ProcurarPorNrCliente(BaseDados bd, int ncliente)
        {
            string sql = "SELECT * FROM cliente WHERE ncliente=" + ncliente;
            DataTable dados = bd.devolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.ncliente = int.Parse(dados.Rows[0]["ncliente"].ToString());
                this.nome = dados.Rows[0]["nome"].ToString();
                this.localidade = dados.Rows[0]["localidade"].ToString();
                this.cod_postal = dados.Rows[0]["codigo_postal"].ToString();
                this.telefone = dados.Rows[0]["telefone"].ToString();
                this.email = dados.Rows[0]["email"].ToString();
            }
        }

        public void Guardar(BaseDados bd)
        {
            try
            {
                // Insert record
                string sql = @"INSERT INTO cliente(nome, codigo_postal, localidade, telefone, email) VALUES 
                            (@nome, @cod_postal, @localidade, @telefone, @email)";

                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.nome
                },

                new SqlParameter()
                {
                    ParameterName = "@cod_postal",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.cod_postal
                },

                new SqlParameter()
                {
                    ParameterName = "@localidade",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.localidade
                },

                new SqlParameter()
                {
                    ParameterName = "@telefone",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.telefone
                },

                new SqlParameter()
                {
                    ParameterName = "@email",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.email
                }
                };

                bd.executaSQL(sql, parametros);
                }
            catch (SqlException ex) when (ex.Number == 2601)
            {
                MessageBox.Show("Telemovel já existente");
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Telemovel já existente");
            }
            
        }

        public static void ApagarCliente(int ncliente, BaseDados bd)
        {
            string sql = "DELETE FROM cliente WHERE ncliente =" + ncliente;
            bd.executaSQL(sql);
        }

        internal void Atualizar(BaseDados bd)
        {
            try
            {

                string sql = @"UPDATE cliente set nome = @nome, codigo_postal = @cod_postal, localidade = @localidade, telefone = @telefone, email = @email WHERE ncliente = @ncliente";

                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = "@nome",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.nome
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@cod_postal",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.cod_postal
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@localidade",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.localidade
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@telefone",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.telefone
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@email",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.email
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@ncliente",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Value = this.ncliente
                    }
                };

                bd.executaSQL(sql, parametros);
            }

            catch (SqlException ex) when (ex.Number == 2601)
            {
                MessageBox.Show("Telemovel já existente");
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Telemovel já existente");
            }
        }

        public static DataTable PesquisaPorNome(BaseDados bd, string nome)
        {
            string sql = @"SELECT * FROM cliente WHERE nome LIKE @nome";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value="%"+nome+"%"
                },
            };
            return bd.devolveSQL(sql, parametros);
        }

        public static DataTable PesquisaPorEmail(BaseDados bd, string email)
        {
            string sql = @"SELECT * FROM cliente WHERE email LIKE @email";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value= email
                },
            };
            return bd.devolveSQL(sql, parametros);
        }

        public override string ToString()
        {
            return this.nome;
        }
    }
}
