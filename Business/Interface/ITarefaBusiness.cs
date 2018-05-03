using Entity;
using Entity.Tarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ITarefaBusiness
    {        
        List<TarefaEntity> Lista();
        List<TarefaGridEntity> TarefasPorLista(int IdLista);
        Retorno Insert(TarefaEntity entity);
        Retorno Update(TarefaEntity entity);
        Retorno Delete(int id, int IdLista);
        Retorno Find(int id, int IdLista);
    }
}
