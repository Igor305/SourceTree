using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        List<Payment> GetAll();
    }
}
