using System;

namespace Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void SavaChanges();
    }
}
