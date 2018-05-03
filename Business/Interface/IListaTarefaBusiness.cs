using Entity;
using Entity.ListaTarefa;
using System.Collections.Generic;

namespace Business.Interface
{
    public interface IListaTarefaBusiness
    {        
        List<ListaTarefaEntity> Lista();
        Retorno Insert(ListaTarefaEntity entity);
        Retorno Update(ListaTarefaEntity entity);
        Retorno Delete(int id);
        Retorno Find(int id);
    }
}
