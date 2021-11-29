﻿using Ivaga.Persistence.Data;
using IVaga.Persistence.Contratos;
using System.Threading.Tasks;

namespace Ivaga.Persistence
{
    public class GeralPersistence : IGeralPersist
    {

        private readonly IVagaContext _context;

        public GeralPersistence(IVagaContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
