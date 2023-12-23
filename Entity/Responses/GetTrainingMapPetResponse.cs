using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Responses
{
    public class GetTrainingMapPetResponse
    {
        public string PetName { get; set; }
        public string PetBreed { get; set; }
        public short PetAge { get; set; }
        public char Gender { get; set; }
        public string TrainingName { get; set; }
    }
}
