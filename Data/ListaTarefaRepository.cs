using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ListaTarefaRepository : BaseRepository<TblListaTarefa>, IListaTarefaRepository
    {
        public ListaTarefaRepository(minhasTarefasContext context) : base(context)
        {
        }
    }
}
