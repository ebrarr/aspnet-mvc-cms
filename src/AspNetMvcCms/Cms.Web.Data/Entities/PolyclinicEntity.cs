using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Web.Data.Entities
{
    public class PolyclinicEntity : EntityBase
    {
        public int DoctorId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

    }
}
