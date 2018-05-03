using Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Entity.Tarefa;
using Data;

namespace Business
{
    public class TarefaBusiness : ITarefaBusiness
    {
        public Retorno Delete(int id, int IdLista)
        {
            Retorno retorno = new Retorno();

            try
            {
                using (var uow = new UnitOfWork())
                {
                    var ids = uow.ListaTarefaRepository.GetAll(x => x.IdTarefa == id && x.IdLista == IdLista).Select(z => z.Id).ToList();

                    uow.ListaTarefaRepository.Delete(x => ids.Contains(x.Id));
                    uow.TarefaRepository.Delete(x => x.Id == id);   

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

        public Retorno Find(int id, int IdLista)
        {
            Retorno retorno = new Retorno();

            TarefaEntity tarefa = new TarefaEntity();

            try
            {
                TblTarefa entity;

                using (var uow = new UnitOfWork())
                {
                    entity = uow.TarefaRepository.Find(id);
                }

                if (entity != null)
                {
                    tarefa = new TarefaEntity
                    {
                        Id = entity.Id, 
                        IdLista = IdLista,
                        Nome = entity.Nome,
                        Importante = entity.Importante,
                        Prioridade = entity.Prioridade,
                        Ativo = entity.Ativo,
                        DataAlteracao = entity.DataAlteracao
                    };

                    retorno.Objeto = tarefa;
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

        public Retorno Insert(TarefaEntity entity)
        {
            Retorno retorno = new Retorno();

            try
            {
                TblTarefa tarefa = new TblTarefa
                {
                    Id = entity.Id,
                    Nome = entity.Nome,
                    Importante = entity.Importante,
                    Prioridade = entity.Prioridade,
                    Ativo = entity.Ativo,
                    DataAlteracao = DateTime.Now
                };

                using (var uow = new UnitOfWork())
                {
                    uow.TarefaRepository.Insert(tarefa);
                    uow.SavaChanges();

                    var idTarefa = tarefa.Id;

                    TblListaTarefa listaTarefa = new TblListaTarefa
                    {
                        IdLista = entity.IdLista,
                        IdTarefa = idTarefa,
                        DataAlteracao = DateTime.Now
                    };

                    uow.ListaTarefaRepository.Insert(listaTarefa);
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

        public List<TarefaEntity> Lista()
        {
            throw new NotImplementedException();
        }

        public List<TarefaGridEntity> TarefasPorLista(int IdLista)
        {
            List<TarefaGridEntity> lista = new List<TarefaGridEntity>();          

            using (var uow = new UnitOfWork())
            {
                lista = uow.TarefaRepository.TarefasPorLista(IdLista);
            }

            return lista.OrderBy(x => x.Prioridade).ToList();
        }

        public Retorno Update(TarefaEntity entity)
        {
            Retorno retorno = new Retorno();

            try
            {
                using (var uow = new UnitOfWork())
                {
                    var dado = uow.TarefaRepository.Get(x => x.Id == entity.Id);

                    if (dado != null)
                    {
                        dado.Nome = entity.Nome;
                        dado.Ativo = entity.Ativo;
                        dado.Importante = entity.Importante;
                        dado.Prioridade = entity.Prioridade;
                        dado.DataAlteracao = DateTime.Now;

                        uow.TarefaRepository.Update(dado);
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