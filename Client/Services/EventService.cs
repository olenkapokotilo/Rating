using Client.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Client.Services;
using System.Configuration;


namespace Client.Services
{
    public class EventService
    {
        public void Comment(string userName, string path) 
        {
            var service = new JsonRequestService<ApiAction>(path);
            service.Post(new ApiAction() { 
                projectUserName  = userName,
                projectId = RatingProjectId,
                actionTypeName = EventConstants.ActiveRatingType.ActionTypeNames.Comment,
                ratingTypeName = EventConstants.ActiveRatingType.Name
            });
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
                public const string Comment = "Question";
                public const string Comment = "OpenPage";
            }
        }
    }

}