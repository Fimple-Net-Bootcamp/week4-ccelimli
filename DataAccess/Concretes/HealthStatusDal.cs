using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class HealthStatusDal : EntityRepositoryBase<HealthStatus, PetCareContext>, IHealthStatusDal
    {
        public List<GetHealthStatusDetail> getHealthStatusDetails()
        {
            using (PetCareContext context=new PetCareContext())
            {
                var GetHealthStatusDetail = from pet in context.Pets
                                       join user in context.Users
                                       on pet.UserId equals user.Id
                                       join healthStatus in context.HealthStatuses
                                       on pet.Id equals healthStatus.PetId
                                       select new GetHealthStatusDetail
                                       {
                                           PetName=pet.PetName,
                                           PetBreed=pet.PetBreed,
                                           PetAge=pet.PetAge,
                                           Gender=pet.Gender,
                                           FirstName=user.FirstName,
                                           LastName=user.LastName,
                                           Weight=healthStatus.Weight,
                                           Vaccinated=healthStatus.Vaccinated,
                                           Sterilize=healthStatus.Sterilize,
                                       };
                return GetHealthStatusDetail.ToList();
            }
        }
    }
}
