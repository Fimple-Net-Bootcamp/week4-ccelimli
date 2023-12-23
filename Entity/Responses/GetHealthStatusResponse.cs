using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Responses
{
    public class GetHealthStatusResponse
    {
        public int Id { get; set; }
        public bool Vaccinated { get; set; }
        public short Weight { get; set; }
        public bool Sterilize { get; set; }

        public virtual GetHealthStatusPetResponse Pet { get; set; }
    }
}
