﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IRatingTypeRepository
    {
        IEnumerable<Domain.Entities.RatingType> GetAllRatingType();
        Domain.Entities.RatingType GetRatingType(int id);
        void Edit(Domain.Entities.RatingType ratingType);
        void Delete(int id);
        Domain.Entities.RatingType GetRatingTypeByNameAndProjectId(string name, int projectId);
        Domain.Entities.RatingType Create(Domain.Entities.RatingType ratingType);
    }
}
