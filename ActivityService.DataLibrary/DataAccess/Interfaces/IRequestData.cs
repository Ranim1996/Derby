using ActivityService.DataLibrary.Models;
using ActivityService.DataLibrary.Models.DTO;
using System.Collections.Generic;

namespace ActivityService.DataLibrary.DataAccess.Interfaces
{
    public interface IRequestData
    {
        List<RequestModel> GetRequests();
        void AddRequest(RequestModel requestModel);
        void UpdateRequest(RequestModel requestModel);
        List<RequestModel> GetRequestById(int id);
        List<RequestModel> GetRequestsByUserId(string id);
        void DeleteRequest(int requestId, string userId);
        void OfferHelp(UserRequestModel userRequestModel);
        List<UserRequestDTO> GetRequestResponses(int requestId);
    }
}
