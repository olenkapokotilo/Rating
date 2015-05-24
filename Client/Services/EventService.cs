using Client.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Client.Services;


namespace Client.Services
{
    public class EventService
    {
       // string[] listRatingTypes = new string[]{"Active", ""};
        Dictionary<string, string[]> actions = new Dictionary<string, string[]>();
        //actions.Add("Active", new string[]{"Comment","Like"});//???
        public void Comment(int userId, string path) 
        {
           // var request = new JsonRequestService(path);
            //request.Post("{actionType:'comment', raitntgType:'Active'}");
            
        }
    }
}