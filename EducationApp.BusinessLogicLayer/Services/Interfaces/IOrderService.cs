using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        int Id();
        string Description();
        string UserId();
        string Date();
        string PaymentId();
        string Status();
    }
}
