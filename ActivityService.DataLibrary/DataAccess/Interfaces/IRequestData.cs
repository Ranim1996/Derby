using ActivityService.DataLibrary.Models;
using System.Collections.Generic;

namespace ActivityService.DataLibrary.DataAccess.Interfaces
{
    public interface IRequestData
    {
        List<RequestModel> GetRequests();
        void AddRequest(RequestModel requestModel);
        void UpdateRequest(RequestModel requestModel);
        List<RequestModel> GetRequestById(string id);
        void DeleteRequest(string id);
    }
}
