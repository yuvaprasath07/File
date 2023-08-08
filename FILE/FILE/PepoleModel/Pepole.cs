using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FILE.PepoleModel
{
    public class Pepole
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class sample
    {
        public int AgencyId { get; set; }
        public string? AgencyName { get; set; }
        public string? AgencyCode { get; set; }
        public string? RegistrationKey { get; set; }
        public string? IsExternalAgency { get; set; }
        public string? IsActive { get; set; }
        public object? SalesForceID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public object? LastModifiedBy { get; set; }
        public object? LastModifyDate { get; set; }
    }
}
