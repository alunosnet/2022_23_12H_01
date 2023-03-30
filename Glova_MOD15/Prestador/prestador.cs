using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glova_MOD15.Prestador
{
    internal class prestador
    {
        public int nprestador { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public byte[] fotografia { get; set; }
        public DateTime data_contratado { get; set; }
        public string telefone { get; set; }
        public bool estado { get; set; }

        public prestador()
        { }
        public prestador(int Nprestador, string Nome, string Tipo,DateTime Data_contrato, byte[] Fotografia, string Telefone, bool Estado)
        {
            nprestador = Nprestador;
            nome = Nome;
            tipo = Tipo;
            data_contratado = Data_contrato;
            fotografia = Fotografia;
            telefone = Telefone;
            estado = Estado;
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = @"SELECT * FROM prestador";
            return bd.devolveSQL(sql);
        }
        public static DataTable ListarTodos(BaseDados bd, int primeiroregisto, int ultimoregisto)
        {
            string sql = $@"SELECT nprestador,nome, tipo, data_contratado, fotografia, telefone,estado FROM
                        (SELECT row_number() over (order by nprestador) as Num,* FROM prestador) as T
                        WHERE Num>={primeiroregisto} AND Num<={ultimoregisto}";
            return bd.devolveSQL(sql);
        }

        public void Guardar(BaseDados bd)
        {
            try
            {
                string sql = @"INSERT INTO prestador(nome, tipo, data_contratado, fotografia, telefone, estado) VALUES 
                                (@nome, @tipo, @data_contrato, @fotografia, @telefone, 0)"; // se estado for 0 o prestador estará disponivel

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
                        ParameterName = "@tipo",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.tipo
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@data_contrato",
                        SqlDbType = System.Data.SqlDbType.Date,
                        Value = this.data_contratado
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@telefone",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.telefone
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@fotografia",
                        SqlDbType = System.Data.SqlDbType.VarBinary,
                        Value = this.fotografia
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

        public void ProcurarPorNrPrestador(BaseDados bd, int nprestador)
        {
            string sql = "SELECT * FROM prestador WHERE nprestador=" + nprestador;
            DataTable dados = bd.devolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.nprestador = int.Parse(dados.Rows[0]["nprestador"].ToString());
                this.nome = dados.Rows[0]["nome"].ToString();
                this.tipo = dados.Rows[0]["tipo"].ToString();
                this.data_contratado = DateTime.Parse(dados.Rows[0]["data_contratado"].ToString());
                this.fotografia = (byte[])dados.Rows[0]["fotografia"];
                this.telefone = dados.Rows[0]["telefone"].ToString();
                this.estado = bool.Parse(dados.Rows[0]["estado"].ToString());
            }
        }

        internal void Atualizar(BaseDados bd)
        {
            try
            {
                
                string sql = @"UPDATE prestador SET nome=@nome, tipo=@tipo, data_contratado=@data_contratado, telefone=@telefone";
                if (this.fotografia != null)
                    sql += ",fotografia=@fotografia";
                sql += " WHERE nprestador=@nprestador";

                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName="@nome",
                        SqlDbType=System.Data.SqlDbType.VarChar,
                        Value=this.nome
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@tipo",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.tipo
                    },
                    new SqlParameter()
                    {
                        ParameterName="@data_contratado",
                        SqlDbType=System.Data.SqlDbType.Date,
                        Value=this.data_contratado
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@telefone",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = this.telefone
                    },
                    new SqlParameter()
                    {
                        ParameterName="@nprestador",
                        SqlDbType=SqlDbType.Int,
                        Value=this.nprestador
                    }
                };
                if (this.fotografia != null)
                    parametros.Add(
                        new SqlParameter()
                        {
                            ParameterName = "@fotografia",
                            SqlDbType = System.Data.SqlDbType.VarBinary,
                            Value = this.fotografia
                        }
                    );

                bd.executaSQL(sql, parametros);
        }

            catch (SqlException ex) when(ex.Number == 2601)
        {
            MessageBox.Show("Email ou Telemovel já existente");
        }
            catch (SqlException ex) when(ex.Number == 2627)
        {
            MessageBox.Show("Email ou Telemovel já existente");
        }
    }

        public static void ApagarCliente(int nprestador, BaseDados bd)
        {
            string sql = "DELETE FROM prestador WHERE nprestador =" + nprestador;
            bd.executaSQL(sql);
        }

        internal static int NrRegistos(BaseDados bd)
        {
            string sql = "SELECT count(*) as NrRegistos from prestador";
            DataTable dados = bd.devolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }

        public static DataTable PesquisaPorNome(BaseDados bd, string nome)
        {
            string sql = @"SELECT * FROM prestador WHERE nome LIKE @nome";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value="%"+nome+"%"
                }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public static DataTable PesquisaPorTipo(BaseDados bd, string tipo)
        {
            string sql = @"SELECT * FROM prestador WHERE tipo LIKE @tipo AND estado <> 1";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@tipo",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value = tipo
                }
            };
            return bd.devolveSQL(sql, parametros);
        }
        public override string ToString()
        {
            return this.nome;
        }

        internal void AtualizarEstado(BaseDados bd)
        {
            string sql = @"UPDATE prestador SET estado = 0 WHERE nprestador = @nprestador";
            List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName="@nprestador",
                        SqlDbType=SqlDbType.Int,
                        Value=this.nprestador
                    }
            };
            bd.executaSQL(sql, parametros);
        }
    }
}
