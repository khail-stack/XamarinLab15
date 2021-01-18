using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApiRestXamarin.Model
{
    public class PersonModel
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string fecha_nacimiento { get; set; }
        public string edad { get; set; }
    }
}
