using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Data.EntityFramework.Repositories;

namespace Yoyyin.Data.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ObjectContext _context;
        // TODO : add all repositories, that needs saving
        private IUserRepository _userRepository;

        public EFUnitOfWork(ObjectContext context)
        {
            _context = context;
        }

        // all repositories should share the same context instance
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new EFUserRepository(_context);
                }
                return _userRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
