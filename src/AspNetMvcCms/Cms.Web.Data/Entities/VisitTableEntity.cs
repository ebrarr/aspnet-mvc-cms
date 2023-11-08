using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Web.Data.Entities
{
    public class VisitTableEntity : EntityBase
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string Reasons { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
    }
}
