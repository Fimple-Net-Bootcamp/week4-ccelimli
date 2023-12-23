using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests
{
    public class AddTrainingMapPetRequest
    {
        public int PetId { get; set; }
        public int TrainingId { get; set; }
    }
}
