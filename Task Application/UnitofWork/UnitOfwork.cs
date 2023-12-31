﻿using Microsoft.EntityFrameworkCore;
using Task_Application.Data;

namespace Task_Application.UnitofWork
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly taskappdbContext _context;
        private bool _disposed = false;

        public UnitOfwork(taskappdbContext context)
        {
            _context = context;
        }
        public DbContext Context => _context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }


}
