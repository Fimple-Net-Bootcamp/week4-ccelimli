using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Responses
{
    public class GetActivityResponse
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public virtual GetActivityPetResponse Pet { get; set; }
    }
}
