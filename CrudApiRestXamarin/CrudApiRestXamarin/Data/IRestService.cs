using CrudApiRestXamarin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrudApiRestXamarin.Data
{
    public interface IRestService
    {
        Task<List<PersonModel>> RefreshDataAsync();

        Task SavePersonAsync(PersonModel person, bool isNewPerson);

        Task DeletePersonAsync(string id);
    }
}
