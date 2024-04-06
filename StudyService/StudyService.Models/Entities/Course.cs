using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyService.Models.Entities
{
    public class Course
    {
        public Guid Id { get; set; }

        public Guid InitiatorId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("InitiatorId")]
        public Employee Initiator { get; set; }

        public ICollection<Competence> Сompetences { get; set; }

        public List<EmployeeCompetence> EmployeeCompetences { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
