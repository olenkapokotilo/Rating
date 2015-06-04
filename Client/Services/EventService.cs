using Client.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Client.Services;
using System.Configuration;
using Newtonsoft.Json;


namespace Client.Services
{
    public class EventService
    {
        public void Comment(string userId, string path) 
        {
            var service = new JsonRequestService<ApiAction>(path);
            service.Post(new ApiAction() {
                ProjectUserExternalId = userId,
                ProjectId = RatingProjectId,
                ActionTypeName = EventConstants.ActiveRatingType.ActionTypeNames.Comment,
                RatingTypeName = EventConstants.ActiveRatingType.Name
            });
        }
        public string GetRatingList()
        {
            var pathGetList = "http://localhost:2250/api/User/GetRatingList?projectId=" + RatingProjectId + "&ratingTypeName=" + EventConstants.ActiveRatingType.Name;
            var service = new JsonRequestService<ApiAction>(pathGetList);
            var ratings = service.Get();
            return ratings;
        }

        private static int RatingProjectId
        {
            get { return int.Parse(ConfigurationManager.AppSettings["RatingProjectId"]); }
        }
    }

    public static class EventConstants
    {
        public static class ActiveRatingType
        {
            public const string Name = "Active";

            public static class ActionTypeNames
            {
                public const string Comment = "Comment";
                public const string Like = "Like";
            }
        }

        public static class CuriousRatingType
        {
            public const string Name = "Curious";

            public static class ActionTypeNames
            {
                public const string Question = "Question";
                public const string OpenPage = "OpenPage";
            }
        }
    }

}