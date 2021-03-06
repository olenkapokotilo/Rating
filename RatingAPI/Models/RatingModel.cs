﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingAPI.Models
{
    public class RatingModel
    {
        public RatingModel(string name, int score, int ratingTypeId, int projectUserId) 
        {
            this.Name = name;
            this.Score = score;
            this.RatingTypeId = ratingTypeId;
            this.ProjectUserId = projectUserId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int RatingTypeId { get; set; }
        public int? ProjectUserId { get; set; }
        public ProjectUserModel ProjectUser { get; set; }
        public static RatingModel FromDomainModel(Domain.Entities.Rating domainRating)
        {
            return Mapper.Map<RatingModel>(domainRating);
        }

        public Domain.Entities.Rating ToDomainModel()
        {
            return Mapper.Map<Domain.Entities.Rating>(this);
        }
    }
}