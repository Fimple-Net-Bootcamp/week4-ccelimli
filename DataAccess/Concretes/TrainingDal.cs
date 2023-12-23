﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class TrainingDal : EntityRepositoryBase<Training, PetCareContext>, ITrainingDal
    {
    }
}
