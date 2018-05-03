using Entity;
using Entity.Lista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IListaBusiness
    {
        Retorno PesquisarLista(ListaFilterEntity filterEntity);
        List<ListaEntity> Lista();
        Retorno Insert(ListaEntity entity);
        Retorno Update(ListaEntity entity);
        Retorno Delete(int id);
        Retorno Find(int id);
    }
}
