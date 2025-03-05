using DataAccess.RiraModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class GetAllPersonsResponse:ResponseMessage
    {
        public List<Person> Persons {  get; set; }
    }
}
