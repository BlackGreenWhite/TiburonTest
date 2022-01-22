using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICRUD<T, TModel>
    {
        Task<IReadOnlyCollection<TModel>> GetAll();
        Task<TModel> GetById(long id);
        Task<TModel> Create(T bdModelName);
        Task<TModel> Update(T bdModelName);
        Task<TModel> Delete(T bdModelName);
    }
}
