using Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Pedidos
    {
        public int npedido;
        public int idUtilizador;
        public decimal preco;
        public string tipo;
        public DateTime data_ped;
        public string descricao;
        public int estado;


        BaseDados bd;

        public Pedidos()
        {
            this.bd = new BaseDados();
        }
        public DataTable listaTodosPedidos(int idUtilizador)
        {
            string sql = @"SELECT nPedido, utilizadores.nome, data_ped,
                        case
                            when pedidos.estado=1 then 'Pendente'
                            when pedidos.estado=2 then 'Concluida'
                        end as estado
                        FROM pedidos inner join utilizadores on idut=id Where idut=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idUtilizador }
            };
            return bd.devolveSQL(sql, parametros);
        }
        public DataTable listaTodosPedidosClie(int idUtilizador)
        {
            string sql = @"SELECT nPedido, utilizadores.nome, data_ped,
                        case
                            when pedidos.estado=1 then 'Pendente'
                        end as estado
                        FROM pedidos inner join utilizadores on idut=id Where idut=@idutilizador AND estado=1";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idUtilizador },
            };
            return bd.devolveSQL(sql, parametros);
        }

        internal void adicionarReserva(int tipos, int idutilizador, string descri, decimal prec)
        {
            string sql = @"INSERT INTO pedidos(idut,tipo,preco,data_ped,descricao,estado) 
                        VALUES (@idut,@tipo,@preco,@data_ped,@descricao,@estado)";
            List<SqlParameter> parametrosInsert = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idut",SqlDbType=SqlDbType.Int,Value=idutilizador },
                new SqlParameter() {ParameterName="@tipo",SqlDbType=SqlDbType.Int,Value=tipos },
                new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value=prec },
                new SqlParameter() {ParameterName="@data_ped",SqlDbType=SqlDbType.Date,Value=DateTime.Now.Date},
                new SqlParameter() {ParameterName="@descricao",SqlDbType=SqlDbType.VarChar,Value=descri },
                new SqlParameter() {ParameterName="@estado",SqlDbType=SqlDbType.Int,Value=0 },

            };
            bd.executaSQL(sql, parametrosInsert);
        }

        internal DataTable InfoPed(int npedidos)
        {
            string sql = @"SELECT utilizadores.nome, email, morada, preco, pedidos.tipo, descricao, data_ped 
                        FROM pedidos inner join utilizadores on idut=id
                        Where npedido = @npedido";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@npedido",SqlDbType=SqlDbType.Int,Value=npedidos }
            };
            return bd.devolveSQL(sql, parametros);
        }

        internal DataTable ListaTodosPedidos()
        {
            return bd.devolveSQL("SELECT * FROM pedidos WHERE estado = 0");
        }
        internal DataTable ListaTodosPedidosPorTipo(int tipo)
        {
            string sql = "SELECT * FROM pedidos WHERE estado = 0 AND tipo = @tipo";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@tipo",SqlDbType=SqlDbType.Int,Value=tipo }
            };
            return bd.devolveSQL(sql, parametros);
        }
        internal void atualizarPedido(int idpedido)
        {
            string sql = @"UPDATE pedidos 
                        SET estado = 2
                        WHERE npedido = @idped";
            List<SqlParameter> parametrosInsert = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idped",SqlDbType=SqlDbType.Int,Value=idpedido },
            };
            bd.executaSQL(sql, parametrosInsert);
        }
    }
}