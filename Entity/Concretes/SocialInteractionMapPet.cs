using Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes
{
    public class SocialInteractionMapPet:IEntity
    {

        public int Id { get; set; }
        public int PetId { get; set; }
        public int DestinationPetId { get; set; }
        public int SocialInteractionId { get; set; }
    }
}
