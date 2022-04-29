using ActivityService.DataLibrary.DataAccess.Interfaces;
using ActivityService.DataLibrary.Internal.DataAccess;
using ActivityService.DataLibrary.Models;
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
                requestId = requestModel.Id,
                requestTitle = requestModel.Title,
                requestDescription = requestModel.Description,
            };

            _sql.SaveData("dbo.AddRequest", p, "ActivityDB");
        }

        public void DeleteRequest(string id)
        {
            _sql.SaveData("dbo.DeleteRequest", new { requestId = id }, "ActivityDB");
        }

        public List<RequestModel> GetRequestById(string id)
        {
            var output = _sql.LoadData<RequestModel, dynamic>("dbo.GetRequestById", new { requestId = id }, "ActivityDB");

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
                requestId = requestModel.Id,
                requestTitle = requestModel.Title,
                requestDescription = requestModel.Description,
            };

            _sql.SaveData("dbo.UpdateRequest", p, "ActivityDB");
        }
    }
}
