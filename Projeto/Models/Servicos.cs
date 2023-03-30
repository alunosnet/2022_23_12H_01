using Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto.Models
{

    public class Servicos
    {

        BaseDados bd;

        public Servicos()
        {
            this.bd = new BaseDados();
        }

        internal void adicionarServico(int idpedido, int idutilizador)
        {
            string sql = @"INSERT INTO servicos(idut, idped) 
                        VALUES (@idut, @idped)";
            List<SqlParameter> parametrosInsert = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idut",SqlDbType=SqlDbType.Int,Value=idutilizador },
                new SqlParameter() {ParameterName="@idped",SqlDbType=SqlDbType.Int,Value=idpedido },

            };
            bd.executaSQL(sql, parametrosInsert);
        }
        internal void atualizarPedido(int idpedido)
        {
            string sql = @"UPDATE pedidos 
                        SET estado = 1
                        WHERE npedido = @idped";
            List<SqlParameter> parametrosInsert = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idped",SqlDbType=SqlDbType.Int,Value=idpedido },
            };
            bd.executaSQL(sql, parametrosInsert);
        }

        internal DataTable listaServicosID(int id)
        {
            string sql = @"SELECT avaliacao, comentarios, utilizadores.nome as Cliente, utilizadores.morada as Morada,pedidos.data_ped as [Data do Pedido],servicos.data_serv as [Data do Servico],
                        case
                            when estado=1 then 'Pendente'
                            when estado=2 then 'Concluido'
                        end as estado
                        FROM servicos inner join pedidos on idped=npedido
                        inner join utilizadores on pedidos.idut=id Where servicos.idut=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=id},
            };
            return bd.devolveSQL(sql, parametros);
        }
        internal void AvaliarPedido(int npedido, int avaliacao, string comentario)
        {
            string sql = @"UPDATE servicos 
                        SET avaliacao = @avaliacao,
                        comentarios = @comentario
                        WHERE idped = @idserv";
            List<SqlParameter> parametrosInsert = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idserv",SqlDbType=SqlDbType.Int,Value=npedido },
                new SqlParameter() {ParameterName="@avaliacao",SqlDbType=SqlDbType.Int,Value=avaliacao },
                new SqlParameter() {ParameterName="@comentario",SqlDbType=SqlDbType.VarChar,Value=comentario },
            };
            bd.executaSQL(sql, parametrosInsert);
        }

        internal DataTable listaTodosPedidosClieFiltro(int idutilizador)
        {
            string sql = @"SELECT pedidos.npedido, pedidos.tipo, servicos.idut, data_serv, avaliacao, comentarios FROM servicos inner join pedidos on idped = npedido inner join utilizadores on pedidos.idut=id Where pedidos.idut=@idutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@idutilizador",SqlDbType=SqlDbType.Int,Value=idutilizador },
            };
            return bd.devolveSQL(sql, parametros);
        }

        internal DataTable ListaAval(string tipo)
        {
            string sql = @"SELECT utilizadores.nome, pedidos.npedido, avaliacao, comentarios FROM servicos inner join pedidos on idped = npedido inner join utilizadores on pedidos.idut=id Where pedidos.tipo=@tipo ORDER BY avaliacao DESC";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@tipo",SqlDbType=SqlDbType.Int,Value=tipo },
            };
            return bd.devolveSQL(sql, parametros);
        }
    }
}