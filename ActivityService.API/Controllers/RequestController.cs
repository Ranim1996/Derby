﻿using ActivityService.DataLibrary.DataAccess.Interfaces;
using ActivityService.DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ActivityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestData _requestData;
        public RequestController(IRequestData requestData)
        {
            _requestData = requestData;
        }

        [HttpGet]
        [Route("getrequests")]
        public List<RequestModel> GetRequests()
        {
            return _requestData.GetRequests();
        }

        [HttpGet]
        [Route("getrequestbyId")]
        public List<RequestModel> GetRequestById(string id)
        {
            List<RequestModel> requests = _requestData.GetRequestById(id);
            return requests;
        }

        [HttpPut]
        [Route("updaterequest")]
        public void UpdateRequest(RequestModel requestModel)
        {
            _requestData.UpdateRequest(requestModel);
        }

        [HttpPost]
        [Route("addrequest")]
        public void AddRequest(RequestModel requestModel)
        {
            _requestData.AddRequest(requestModel);
        }

        [HttpDelete]
        [Route("deleterequest")]
        public void DeleteRequest(string id)
        {
            _requestData.DeleteRequest(id);
        }
    }
}
