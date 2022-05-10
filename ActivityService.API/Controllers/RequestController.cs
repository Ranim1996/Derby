using ActivityService.DataLibrary.DataAccess.Interfaces;
using ActivityService.DataLibrary.Models;
using ActivityService.DataLibrary.Models.DTO;
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
        [Route("getrequestsbyUserId")]
        public List<RequestModel> GetRequestByUserId(string id)
        {
            List<RequestModel> requests = _requestData.GetRequestsByUserId(id);
            return requests;
        }

        [HttpGet]
        [Route("getrequestsbyId")]
        public List<RequestModel> GetRequestById(int id)
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
        public void DeleteRequest(int requestId, string userId)
        {
            _requestData.DeleteRequest(requestId, userId);
        }

        [HttpPost]
        [Route("offerhelp")]
        public void JoinEvent(UserRequestModel userRequestModel)
        {
            _requestData.OfferHelp(userRequestModel);
        }

        [HttpGet]
        [Route("getresponses")]
        public List<UserRequestDTO> GetRequestResponses(int requestId)
        {
            List<UserRequestDTO> userRequestDTOs = _requestData.GetRequestResponses(requestId);
            return userRequestDTOs;
        }
    }
}
