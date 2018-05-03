using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Tarefa;

namespace Data
{
    public class TarefaRepository : BaseRepository<TblTarefa>, ITarefaRepository
    {
        public TarefaRepository(minhasTarefasContext context) : base(context)
        {
        }

        public List<TarefaGridEntity> TarefasPorLista(int IdLista)
        {
            List<TarefaGridEntity> lista = new List<TarefaGridEntity>();

            try
            {
                var query = (from t in _context.TblTarefas
                             join lt in _context.TblListaTarefas on t.Id equals lt.IdTarefa
                             join l in _context.TblListas on lt.IdLista equals l.Id
                             where lt.IdLista == IdLista
                             select new
                             {
                                 IdTarefa = t.Id,                                 
                                 NomeTarefa = t.Nome,
                                 Importante = t.Importante,
                                 Prioridade = t.Prioridade,
                                 DataAlteracao = t.DataAlteracao,
                                 Ativo = t.Ativo,
                                 IdLista = l.Id,
                                 NomeLista = l.Nome
                             }).ToList();

                foreach (var item in query)
                {
                    TarefaGridEntity grid = new TarefaGridEntity
                    {
                        Id = item.IdTarefa,
                        IdLista = item.IdLista,
                        NomeTarefa = item.NomeTarefa,
                        NomeLista = item.NomeLista,
                        Importante = item.Importante ? "Sim" : "Não",
                        Prioridade = item.Prioridade,
                        DataAlteracao = item.DataAlteracao,
                        Ativo = item.Ativo,
                    };

                    lista.Add(grid);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }
    }
}
