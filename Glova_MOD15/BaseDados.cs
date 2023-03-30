using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace M15_TrabalhoModelo_2022_23
{
    public class BaseDados
    {
        string ligaBD;
        SqlConnection sqlConnection;
        string nomeBD;
        string caminhoBD;

        // CONSTRUTOR
        public BaseDados(string nomeBD)
        {
            ligaBD = ConfigurationManager.ConnectionStrings["servidor"].ToString();
            this.nomeBD = nomeBD;
            string caminhoBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            caminhoBD += "\\M15_Glova\\";
            this.caminhoBD = caminhoBD + nomeBD + ".mdf";
            
            if(System.IO.Directory.Exists(caminhoBD) == false)
            {
                System.IO.Directory.CreateDirectory(caminhoBD);
            }

            if(System.IO.File.Exists(this.caminhoBD) == false)
            {
                criarBD();
            }

            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();
            sqlConnection.ChangeDatabase(nomeBD);

        }

        // DESTRUTOR
        ~BaseDados()
        {

            try
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            catch 
            {
                
                // Pode ocorrer erros

            }

        }

        private void criarBD()
        {
            // Ligar ao servidor BD
            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();
            
            // Criar a BD
            string sql = $"CREATE DATABASE {nomeBD} ON PRIMARY (NAME={nomeBD}, FILENAME='{caminhoBD}')";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.ChangeDatabase(nomeBD);

            // Criar as tabelas
            sql = @"create table cliente(
	                    ncliente int identity primary key,
	                    nome varchar(40) not null check(len(nome) >= 3),
	                    codigo_postal varchar(8) check(codigo_postal like '____-___'),
	                    localidade varchar(100) not null check(localidade in ('Armamar', 'Carregal Do Sal', 'Castro Daire', 'Cinfães', 'Cinfaes', 'Lamego', 'Mangualde', 'Moimenta Da Beira', 'Mortágua', 'Mortagua', 'Nelas', 'Oliveira De Frades', 'Penalva Do Castelo', 'Penedono', 'Resende', 'Santa Comba Dão', 'Santa Comba Dao', 'São João Da Pesqueira', 'Sao Joao Da Pesqueira', 'São Pedro Do Sul', 'Sao Pedro Do Sul', 'Sátão', 'Satao', 'Sernancelhe', 'Tabuaço', 'Tabuaco', 'Tarouca', 'Tondela', 'Vila Nova De Paiva', 'Viseu', 'Vouzela')),
	                    telefone varchar(9) unique check(len(telefone) = 9),
	                    email varchar(100) unique check(email like '%@%.%')
                    );

                    create table prestador(
	                    nprestador int identity primary key,
	                    data_contratado date DEFAULT(getdate()),
	                    nome varchar(40) not null,
	                    fotografia varbinary(max) not null,
	                    tipo varchar(100) check(tipo in ('Entrega de Comida', 'Manutenção', 'Taxi')),
                        telefone varchar(9) unique check(len(telefone) = 9),
	                    estado bit DEFAULT(0)
                    );

                    create table servico(
	                    nservico int identity primary key,
	                    ncliente int references cliente(ncliente),
	                    nprestador int references prestador(nprestador),
	                    tipo varchar(100) check(tipo in ('Entrega de Comida', 'Manutenção', 'Taxi')),
	                    data_prestado date DEFAULT(getdate()),
	                    preco decimal check(preco > 0),
	                    estado bit DEFAULT(0)
                    );

                    CREATE INDEX i_prestador_nome ON prestador(nome);
                    CREATE INDEX i_prestador_tipo ON prestador(tipo);

                    CREATE INDEX i_cliente_nome ON cliente(nome);
                    CREATE INDEX i_cliente_email ON cliente(email);";

            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            // Fechar a ligação ao servidor BD

            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();

        }

        // Vai executar um SQL que altera os dados (ex. insert; delete; update)
        public void executaSQL(string sql, List<SqlParameter> parametros = null)
        {
            //ToDo : Adicionar Transações

           SqlCommand comando = new SqlCommand(sql, sqlConnection);  
            if(parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }

            comando.ExecuteNonQuery();
            comando.Dispose();
            comando = null;
            
        }

        // Executa uma consulta e devolve os dados da BD
        public DataTable devolveSQL(string sql, List<SqlParameter> parametros = null)
        {
            // ToDo : Adicionar Transações

            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }

            DataTable dados = new DataTable();

            SqlDataReader registos = comando.ExecuteReader();
            dados.Load(registos);

            registos.Close();
            comando.Dispose();
            registos = null;
            comando = null;

            return dados;

        }
    }
}
