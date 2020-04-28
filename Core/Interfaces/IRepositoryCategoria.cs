using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepositoryCategoria
    {
        IEnumerable<Categoria> List();
        void Remove(int id);
        Categoria SelectById(int id);
        Categoria New(Categoria categoria);
        Categoria Update(Categoria categoria);        
    }
}
