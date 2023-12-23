using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concretes;

namespace Entity.Responses
{
    public class GetFoodResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public short AgeAppropriateness { get; set; }
        public bool SterlieFood { get; set; }

        public virtual GetFoodPetResponse Pet { get; set; }
    }
}
