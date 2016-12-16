#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModel.GenericRepository;
using Auth.Entities.Models;
using Auth.Data;

#endregion

namespace Auth.Core.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...

        private readonly AuthContext _context = null;
        #endregion

        public UnitOfWork()
        {
            _context = new AuthContext();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}