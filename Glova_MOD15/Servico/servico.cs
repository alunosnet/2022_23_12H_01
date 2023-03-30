using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glova_MOD15.Servico
{
    class servico
    {

        public int nservico;
        public int ncliente;
        public int nprestador;
        public string tipo;
        public DateTime data_prestado;
        public decimal preco;
        public bool estado;

        public servico()
        {

        }

        public servico(int ncliente, int nprestador, DateTime data_prestado, string tipo, decimal preco)
        {
            this.nprestador = nprestador;
            this.ncliente = ncliente;
            this.data_prestado = data_prestado;
            this.tipo = tipo;
            this.preco = preco;
        }

        public void Adicionar(BaseDados bd)
        {
            
            string sql = @"insert into servico(ncliente, nprestador,
                            data_prestado, tipo, preco, estado) values 
                            (@ncliente, @nprestador, @data_prestado, @tipo,
                                @preco, 0)";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@ncliente",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ncliente
                },
                new SqlParameter()
                {
                    ParameterName="@nprestador",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nprestador
                },
                new SqlParameter()
                {
                    ParameterName="@data_prestado",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_prestado
                },
                new SqlParameter()
                {
                    ParameterName="@tipo",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.tipo
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.preco
                }
            };
           
            bd.executaSQL(sql, parametros);
            
            sql = "UPDATE prestador SET estado=1 WHERE nprestador=" + nprestador;
            bd.executaSQL(sql);
        }

        internal static object PesquisaPorCliente(BaseDados bd)
        {
            string sql = @"SELECT ncliente, COUNT(*) as [Nº de Vezes Pedidas] FROM servico GROUP BY ncliente";
            return bd.devolveSQL(sql);
        }
        internal static object PesquisaTodos(BaseDados bd)
        {
            string sql = @"SELECT * FROM servico WHERE estado = 0";
            return bd.devolveSQL(sql);
        }

        internal void Atualizar(BaseDados bd)
        {
            try
            {

                string sql = @"UPDATE servico SET nprestador=@nprestador, ncliente=@ncliente, tipo=@tipo, data_prestado=@data_prestado, estado=@estado WHERE nservico=@nservico";

                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName="@nservico",
                        SqlDbType=SqlDbType.Int,
                        Value=this.nservico
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@tipo",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.tipo
                    },
                    new SqlParameter()
                    {
                        ParameterName="@data_prestado",
                        SqlDbType=System.Data.SqlDbType.Date,
                        Value=this.data_prestado
                    },
                     new SqlParameter()
                    {
                        ParameterName="@ncliente",
                        SqlDbType=SqlDbType.Int,
                        Value=this.ncliente
                    },
                     new SqlParameter()
                    {
                        ParameterName="@estado",
                        SqlDbType=SqlDbType.Int,
                        Value=this.estado
                    },
                    new SqlParameter()
                    {
                        ParameterName="@nprestador",
                        SqlDbType=SqlDbType.Int,
                        Value=this.nprestador
                    }
                };

                bd.executaSQL(sql, parametros);
            }

            catch (SqlException ex) when (ex.Number == 2601)
            {
                MessageBox.Show("Email ou Telemovel já existente");
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Email ou Telemovel já existente");
            }
        }

        internal static object ListarTodos(BaseDados bd)
        {
            string sql = @"SELECT * FROM servico WHERE estado = 0";
            return bd.devolveSQL(sql);
        }

        internal void ProcurarPorNrServico(BaseDados bd, int nservico)
        {
            string sql = "SELECT * FROM servico WHERE nservico=" + nservico;
            DataTable dados = bd.devolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.nservico = int.Parse(dados.Rows[0]["nservico"].ToString());
                this.ncliente = int.Parse(dados.Rows[0]["ncliente"].ToString());
                this.nprestador = int.Parse(dados.Rows[0]["nprestador"].ToString());
                this.tipo = dados.Rows[0]["tipo"].ToString();
                this.data_prestado = DateTime.Parse(dados.Rows[0]["data_prestado"].ToString());
                this.estado = bool.Parse(dados.Rows[0]["estado"].ToString());
            }
        }

        internal static object PesquisaRealizados(BaseDados bd)
        {
            string sql = @"SELECT * FROM servico WHERE estado = 1";
            return bd.devolveSQL(sql);
        }

        internal static object PesquisaRealizadosPrestador(BaseDados bd)
        {
            string sql = @"SELECT nome, ncliente, COUNT(*) as [Vezes que Prestador Trabalhou para um CLiente] FROM prestador INNER JOIN servico ON prestador.nprestador = servico.nprestador GROUP BY nome, ncliente";
            return bd.devolveSQL(sql);
        }
    }
}
