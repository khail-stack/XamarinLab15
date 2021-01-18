using CrudApiRestXamarin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrudApiRestXamarin.Data
{
    public class PersonManager
    {
        IRestService restService;

        public PersonManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<PersonModel>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(PersonModel person, bool isNewPerson = false)
        {
            return restService.SavePersonAsync(person, isNewPerson);
        }

        public Task DeleteTaskAsync(PersonModel item)
        {
            return restService.DeletePersonAsync(item._id.ToString());
        }
    }
}
