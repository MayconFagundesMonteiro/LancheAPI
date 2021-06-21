using LancheAPI.Model.Base;
using LancheAPI.Model.Context;
using LancheAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LancheAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> dataSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public T Atualizar(T item)
        {
            var result = dataSet.SingleOrDefault(x => x.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public T Criar(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(int id)
        {
            var item = dataSet.SingleOrDefault(x => x.Id.Equals(id));
            if(item != null)
            {
                try
                {
                    dataSet.Remove(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public T EncontrarPorId(int id)
        {
            return dataSet.SingleOrDefault(x => x.Id.Equals(id));
        }

        public List<T> ListarTodos()
        {
            return dataSet.ToList();
        }
    }
}
