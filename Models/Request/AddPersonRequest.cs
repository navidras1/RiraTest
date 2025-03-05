using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class AddPersonRequest
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string NationalCode { get; set; }
        
        public long? BirthDate { get; set; }
    }
}
