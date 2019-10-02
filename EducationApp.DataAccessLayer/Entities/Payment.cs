using EducationApp.DataAccessLayer.Entities.Base;
using System;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Payment : Basic
    {
        public string TransactionId { get; set; }
    }
}