using Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes
{
    public class TrainingMapPet:IEntity
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public Pet Pets { get; set; }
        public int TrainingId { get; set; }
        public Training Trainings { get; set; }
    }
}
