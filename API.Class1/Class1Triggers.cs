using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using API.Class1.v1.Models;
using API.Class1.v1.Services;

namespace API.Class1
{
    public class Class1Triggers
    {
        private readonly IClass1Service _Class1Service;

        public Class1Triggers(IClass1Service Class1Service)
        {
            _Class1Service = Class1Service;
        }

        [FunctionName("PostAsync")]
        public async Task<IActionResult> PostAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Class1")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var addModel = JsonConvert.DeserializeObject<Class1AddModel>(requestBody);
            var responseModel = await _Class1Service.AddAsync(addModel);
            return new OkObjectResult(responseModel);
        }

        [FunctionName("GetByIDAsync")]
        public async Task<IActionResult> GetByIDAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Class1/{id:Guid}")]
            HttpRequest req, Guid id, ILogger log)
        {
            var response = await _Class1Service.GetByIDAsync(id);
            return new OkObjectResult(response);
        }

        [FunctionName("GetByExternalIDAsync")]
        public async Task<IActionResult> GetByExternalIDAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Class1/externalId/{externalId}")]
            HttpRequest req, string externalId, ILogger log)
        {
            var response = await _Class1Service.GetByExternalIDAsync(externalId);
            return new OkObjectResult(response);
        }

        [FunctionName("PutAsync")]
        public async Task<IActionResult> PutAsync(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "Class1/{id:Guid}")] HttpRequest req, Guid id, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateModel = JsonConvert.DeserializeObject<Class1UpdateModel>(requestBody);
            updateModel.ID = id;
            var responseModel = await _Class1Service.UpdateAsync(updateModel);
            return new OkObjectResult(responseModel);
        }

        [FunctionName("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Class1/{id:Guid}")] HttpRequest req, Guid id, ILogger log)
        {
            await _Class1Service.DeleteAsync(id);
            return new NoContentResult();
        }
    }
}
