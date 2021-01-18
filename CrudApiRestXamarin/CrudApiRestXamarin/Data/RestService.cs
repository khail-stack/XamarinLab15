using CrudApiRestXamarin.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrudApiRestXamarin.Data
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public List<PersonModel> Persons { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<PersonModel>> RefreshDataAsync()
        {
            Persons = new List<PersonModel>();

            var url_list = new Uri(Constants.PersonUrl);
            try
            {
                var response = await _client.GetAsync(url_list);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.Write("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAVES:V",content);
                    Persons = JsonConvert.DeserializeObject<List<PersonModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Persons;
        }

        public async Task SavePersonAsync(PersonModel person, bool isNewPerson)
        {
            var url_create = new Uri("https://xamarinrestapi.herokuapp.com/person/create/");

            try
            {
                var json = JsonConvert.SerializeObject(person);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                if (isNewPerson)

                {
                    response = await _client.PostAsync(url_create, content);
                }
                else
                {
                    var url_edit = new Uri(string.Concat("https://xamarinrestapi.herokuapp.com/person/update/", person._id));
                    response = await _client.PutAsync(url_edit, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeletePersonAsync(string id)
        {
            var url_delete = new Uri(string.Concat("https://xamarinrestapi.herokuapp.com/person/delete/", id));

            try
            {
                var response = await _client.DeleteAsync(url_delete);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

    }
}
