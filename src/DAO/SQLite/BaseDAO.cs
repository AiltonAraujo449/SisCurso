using Dapper;
using System;
using System.IO;
using System.Data.SQLite;

namespace DAO.SQLite
{
    public class BaseDAO
    {
        protected string DataSourceFile => Environment.CurrentDirectory + "\\SisCursoDB.sqlite";
        protected SQLiteConnection Connection => new SQLiteConnection("Data source=" + DataSourceFile + ";foreign keys=true;");

        public BaseDAO()
        {
            if(!File.Exists(DataSourceFile))
            {
                CreateDataBase();
            }
        }

        private void CreateDataBase()
        {
            using(var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"create table Contato
                    (
                        Id          integer primary key autoincrement,
                        Nome        varchar(100) not null,
                        Sobrenome   varchar(100)not null,
                        Email       varchar(100) not null
                    );
                    create table Telefone
                    (
                        Id          integer primary key autoincrement,
                        ContatoId   integer,
                        Numero      varchar(100) not null,
                        FOREIGN KEY (ContatoId) REFERENCES Contato(Id)
                    );"
                );
            }
        }
    }
}