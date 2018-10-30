using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx.Model
{
    public class Person
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string BirthDate { get; set; }
        public string FIN { get; set; }
        public string Address { get; set; }
        public string GivenDate { get; set; }
        public string ExireDate { get; set; }
        public string SerialNo { get; set; }
        public string Gender { get; set; }

        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
