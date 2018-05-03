using Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.Lista;
using Data.Interface;
using Data;

namespace Business
{
    public class ListaBusiness : IListaBusiness
    {
        public Retorno Delete(int id)
        {
            Retorno retorno = new Retorno();

            try
            {
                using (var uow = new UnitOfWork())
                {
                    var IdsTarefaLista = uow.ListaTarefaRepository.GetAll(x => x.IdLista == id).Select(z => z.IdTarefa).ToList();


                    uow.ListaTarefaRepository.Delete(x => IdsTarefaLista.Contains(x.IdTarefa));
                    uow.TarefaRepository.Delete(x => IdsTarefaLista.Contains(x.Id));
                    uow.ListaRepository.Delete(x => x.Id == id);

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

        public Retorno Find(int id)
        {
            Retorno retorno = new Retorno();

            ListaEntity lista = new ListaEntity();

            try
            {
                TblLista entity;

                using (var uow = new UnitOfWork())
                {
                    entity = uow.ListaRepository.Find(id);
                }

                if (entity != null)
                {
                    lista = new ListaEntity
                    {
                        Id = entity.Id,
                        Nome = entity.Nome,
                        Ativo = entity.Ativo,
                        DataAlteracao = entity.DataAlteracao
                    };

                    retorno.Objeto = lista;
                }
                else
                {
                    retorno.Objeto = null;
                    retorno.Mensagem = Mensagens.MSG_004;
                }
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = Mensagens.MSG_006;
            }

            return retorno;
        }

        public Retorno Insert(ListaEntity entity)
        {
            Retorno retorno = new Retorno();

            try
            {
                TblLista lista = new TblLista
                {
                    Nome = entity.Nome,
                    Ativo = entity.Ativo,
                    DataAlteracao = DateTime.Now
                };

                using (var uow = new UnitOfWork())
                {
                    uow.ListaRepository.Insert(lista);
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

        public List<ListaEntity> Lista()
        {
            List<TblLista> retorno = new List<TblLista>();
            List<ListaEntity> lista = new List<ListaEntity>();

            using (var uow = new UnitOfWork())
            {
                retorno = uow.ListaRepository.GetAll().ToList();
            }

            foreach (var item in retorno)
            {
                lista.Add(new ListaEntity
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Ativo = item.Ativo,
                    DataAlteracao = item.DataAlteracao
                });
            }

            return lista.OrderByDescending(x => x.DataAlteracao).ToList();
        }

        public Retorno PesquisarLista(ListaFilterEntity filterEntity)
        {
            Retorno retorno = new Retorno();

            try
            {
                using (var uow = new UnitOfWork())
                {
                    retorno.Objeto = uow.ListaRepository.PesquisarLista(filterEntity);
                    retorno.Sucesso = true;
                }
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = ex.Message;
            }

            return retorno;
        }

        public Retorno Update(ListaEntity entity)
        {
            Retorno retorno = new Retorno();

            try
            {
                using (var uow = new UnitOfWork())
                {
                    var dado = uow.ListaRepository.Get(x => x.Id == entity.Id);

                    if (dado != null)
                    {
                        dado.Nome = entity.Nome;
                        dado.Ativo = entity.Ativo;
                        dado.DataAlteracao = DateTime.Now;

                        uow.ListaRepository.Update(dado);
                        uow.SavaChanges();

                        retorno.Sucesso = true;
                        retorno.Mensagem = Mensagens.MSG_005;
                    }
                    else
                    {
                        retorno.Sucesso = false;
                        retorno.Mensagem = Mensagens.MSG_004;
                    }
                }
            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.Mensagem = Mensagens.MSG_006;
            }

            return retorno;
        }
    }
}