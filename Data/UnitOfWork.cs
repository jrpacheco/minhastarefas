using Data.Interface;
using System;

namespace Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private minhasTarefasContext _context = null;        

        private IListaRepository _listaRepository = null;
        private ITarefaRepository _tarefaRepository = null;
        private IListaTarefaRepository _listaTarefaRepository = null;

        public UnitOfWork()
        {
            _context = new minhasTarefasContext();
        }

        public IListaRepository ListaRepository
        {
            get
            {
                if (_listaRepository == null)
                    _listaRepository = new ListaRepository(_context);

                return _listaRepository;
            }
        }

        public ITarefaRepository TarefaRepository
        {
            get
            {
                if (_tarefaRepository == null)
                    _tarefaRepository = new TarefaRepository(_context);

                return _tarefaRepository;
            }
        }

        public IListaTarefaRepository ListaTarefaRepository
        {
            get
            {
                if (_listaTarefaRepository == null)
                    _listaTarefaRepository = new ListaTarefaRepository(_context);

                return _listaTarefaRepository;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SavaChanges()
        {
            _context.SaveChanges();
        }
    }
}