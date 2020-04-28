using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class CategoriaService
    {
        private readonly IRepositoryCategoria repository;

        public CategoriaService(IRepositoryCategoria repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Categoria> List()
        {
            var categorias = repository.List();
            return categorias;
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public Categoria SelectById(int id)
        {
            var categoria = repository.SelectById(id);
            return categoria;
        }

        public Categoria New(Categoria categoria)
        {
            var categ = repository.New(categoria);
            return categ;
        }

        public Categoria Update(Categoria categoria)
        {
            var categ = repository.Update(categoria);
            return categ;
        }
    }
}
