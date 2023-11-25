using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.Dtos
{
    public class PermissionDto
    {
        public string EmployeeForename { get; set; } = string.Empty;
        public string EmployeeSurname { get; set; } = string.Empty;
        public DateTime PermissionDate { get; set; }

        public PermissionTypeDto PermissionType { get; set; } = new();
    }
}
