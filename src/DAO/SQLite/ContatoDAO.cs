using DTO;
using Dapper;
using System.Linq;
using System.Data.SQLite;
using System.Collections.Generic;

namespace DAO.SQLite
{    
    public class ContatoDAO : BaseDAO, IContatoDAO
    {
        
        public ContatoDAO() : base()
        {
            
        }

        
        public void Criar(ContatoDTO contato)
        {
            using(var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Contato
                    (Nome, Sobrenome, Email) VALUES
                    (@Nome, @Sobrenome, @Email);", contato);
            }
        }

        public List<ContatoDTO> Consultar()        
        {
            using(var con = Connection)
            {
                con.Open();
                var result = con.Query<ContatoDTO>(
                    @"SELECT Id, Nome, Sobrenome, Email
                    FROM Contato"
                ).ToList();
                return result;
            }
        }

        public ContatoDTO Consultar(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                ContatoDTO result = con.Query<ContatoDTO>(
                    @"SELECT Id, Nome, Sobrenome, Email
                    FROM Contato
                    WHERE Id = @id", new { id }).FirstOrDefault();
                return result;
            }
        }

        public void Atualizar(ContatoDTO contato)
        {
            using(var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"UPDATE Contato SET
                    Nome = @Nome, Sobrenome = @Sobrenome, Email = @Email
                    WHERE Id = @id;", contato);
            }
        }

        public void Excluir(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"DELETE FROM Contato
                    WHERE Id = @Id;", new { id }
                );
            }
        }
    }
}