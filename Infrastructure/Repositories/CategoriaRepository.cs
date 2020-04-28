using Core.Interfaces;
using Core.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CategoriaRepository : IRepositoryCategoria
    {
        private readonly DataContext context;

        public CategoriaRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Categoria> List()
        {
            var categorias = context.Categoria.AsNoTracking().ToList();
            return categorias;
        }

        public void Remove(int id)
        {
            try
            {
                var categoria = context.Categoria.Single(p => p.Id == id);
                context.Remove(categoria);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categoria SelectById(int id)
        {
            var categoria = context.Categoria.FirstOrDefault(p => p.Id == id);
            return categoria;
        }

        public Categoria New(Categoria categoria)
        {
            context.Add(categoria);
            context.SaveChanges();
            return categoria;
        }

        public Categoria Update(Categoria categoria)
        {
            context.Update(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}
