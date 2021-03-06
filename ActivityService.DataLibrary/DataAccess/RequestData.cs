using ActivityService.DataLibrary.DataAccess.Interfaces;
using ActivityService.DataLibrary.Internal.DataAccess;
using ActivityService.DataLibrary.Models;
using ActivityService.DataLibrary.Models.DTO;
using System;
using System.Collections.Generic;

namespace ActivityService.DataLibrary.DataAccess
{
    public class RequestData : IRequestData
    {
        private readonly ISqlDataAccess _sql;

        public RequestData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public void AddRequest(RequestModel requestModel)
        {
            var p = new
            {
                userId = requestModel.UserId,
                requestTitle = requestModel.Title,
                requestDescription = requestModel.Description,
            };

            _sql.SaveData("dbo.AddRequest", p, "ActivityDB");
        }

        public void DeleteRequest(int requestId, string userId)
        {
            _sql.SaveData("dbo.DeleteRequest", new { requestId = requestId, userId = userId }, "ActivityDB");
        }

        public List<RequestModel> GetRequestsByUserId(string userId)
        {
            var output = _sql.LoadData<RequestModel, dynamic>("dbo.GetRequestsByUserId", new { userId = userId }, "ActivityDB");

            return output;
        }

        public List<RequestModel> GetRequests()
        {
            var output = _sql.LoadData<RequestModel, dynamic>("dbo.GetRequests", new { }, "ActivityDB");

            return output;
        }

        public void UpdateRequest(RequestModel requestModel)
        {
            var p = new
            {
                requestId =requestModel.Id,
                requestTitle = requestModel.Title,
                requestDescription = requestModel.Description,
            };

            _sql.SaveData("dbo.UpdateRequest", p, "ActivityDB");
        }

        public List<RequestModel> GetRequestById(int id)
        {
            var output = _sql.LoadData<RequestModel, dynamic>("dbo.GetRequestById", new { requestId = id }, "ActivityDB");

            return output;
        }

        public void OfferHelp(UserRequestModel userRequestModel)
        {
            var p = new
            {
                requestId = userRequestModel.RequestId,
                userId = userRequestModel.UserId
            };

            _sql.SaveData("dbo.OfferHelp", p, "ActivityDB");
        }

        public List<UserRequestDTO> GetRequestResponses(int requestId)
        {
            var output = _sql.LoadData<UserRequestDTO, dynamic>("dbo.GetResponses", new { requestId = requestId }, "ActivityDB");

            return output;
        }
    }
}
