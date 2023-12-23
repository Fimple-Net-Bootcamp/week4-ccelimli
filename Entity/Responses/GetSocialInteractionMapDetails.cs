using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Responses
{
    public class GetSocialInteractionMapDetails
    {
        public string PetName { get; set; }
        public string PetBreed { get; set; }
        public short PetAge { get; set; }
        public char Gender { get; set; }

        public string DestinationPetName { get; set; }
        public string DestinationPetBreed { get; set; }
        public short DestinationPetAge { get; set; }
        public char DestinationGender { get; set; }
        public string SocialInteractionName { get; set; }

    }
}
