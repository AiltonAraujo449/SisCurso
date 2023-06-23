using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;


namespace DAO
{
    public interface IContatoDAO
    {
        void Atualizar(ContatoDTO contato);
        List<ContatoDTO> Consultar();
        ContatoDTO Consultar(int id);
        void Criar(ContatoDTO contato);
        void Excluir(int id);
    }
}