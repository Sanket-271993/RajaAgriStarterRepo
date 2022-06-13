﻿using RajaAgriApp.Models;
using System.Threading.Tasks;

namespace RajaAgriApp.Services
{
    public interface IServiceRequestService
    {
        Task<ServiceRequestResponseModel> GetServiceRequest();
    }
}
