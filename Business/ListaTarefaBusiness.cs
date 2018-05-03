using Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.ListaTarefa;
using Data;

namespace Business
{
    public class ListaTarefaBusiness : IListaTarefaBusiness
    {
        public Retorno Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Retorno Find(int id)
        {
            throw new NotImplementedException();
        }

        public Retorno Insert(ListaTarefaEntity entity)
        {
            Retorno retorno = new Retorno();

            try
            {
                TblListaTarefa lista = new TblListaTarefa
                {
                    IdLista = entity.IdLista,
                    IdTarefa = entity.IdTarefa,
                    DataAlteracao = DateTime.Now
                };

                using (var uow = new UnitOfWork())
                {
                    uow.ListaTarefaRepository.Insert(lista);
                    uow.SavaChanges();

                    retorno.Sucesso = true;
                    retorno.Mensagem = Mensagens.MSG_005;
                }
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = Mensagens.MSG_006;
            }

            return retorno;
        }

        public List<ListaTarefaEntity> Lista()
        {
            throw new NotImplementedException();
        }

        public Retorno Update(ListaTarefaEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
