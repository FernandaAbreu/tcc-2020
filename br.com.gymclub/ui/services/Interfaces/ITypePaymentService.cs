using System;
using System.Collections.Generic;
using api.models;

namespace api.services.Interfaces
{
    public interface ITypePaymentService
    {
        List<TypePayment> GetAll();
        
    }
}
