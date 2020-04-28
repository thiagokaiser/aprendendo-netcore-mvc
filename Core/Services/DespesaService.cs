using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class DespesaService
    {
        private readonly IRepositoryDespesa repository;

        public DespesaService(IRepositoryDespesa repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Despesa> List()
        {
            var despesas = repository.List();
            return despesas;
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public Despesa SelectById(int id)
        {
            var despesa = repository.SelectById(id);
            return despesa;
        }

        public Despesa New(Despesa despesa)
        {
            var desp = repository.New(despesa);
            return desp;
        }

        public Despesa Update(Despesa despesa)
        {
            var desp = repository.Update(despesa);
            return desp;
        }
    }
}
