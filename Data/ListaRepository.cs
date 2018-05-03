using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Lista;

namespace Data
{
    public class ListaRepository : BaseRepository<TblLista>, IListaRepository
    {
        public ListaRepository(minhasTarefasContext context) : base(context)
        {
        }

        public List<ListaEntity> PesquisarLista(ListaFilterEntity filterEntity)
        {
            throw new NotImplementedException();
        }
    }
}
