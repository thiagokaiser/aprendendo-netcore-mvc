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
    public class DespesaRepository : IRepositoryDespesa
    {
        private readonly DataContext context;

        public DespesaRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Despesa> List()
        {
            var despesas = context.Despesa.Include(i => i.Categoria).AsNoTracking().ToList();
            return despesas;
        }

        public void Remove(int id)
        {
            try
            {
                var despesa = context.Despesa.Single(p => p.Id == id);
                context.Remove(despesa);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Despesa SelectById(int id)
        {
            var despesa = context.Despesa.FirstOrDefault(p => p.Id == id);
            return despesa;
        }

        public Despesa New(Despesa despesa)
        {
            context.Add(despesa);
            context.SaveChanges();

            return despesa;
        }

        public Despesa Update(Despesa despesa)
        {
            context.Update(despesa);
            context.SaveChanges();

            return despesa;
        }
    }
}
