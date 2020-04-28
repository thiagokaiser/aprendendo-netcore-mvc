using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepositoryDespesa
    {
        IEnumerable<Despesa> List();
        void Remove(int id);
        Despesa SelectById(int id);
        Despesa New(Despesa despesa);
        Despesa Update(Despesa despesa);        
    }
}
