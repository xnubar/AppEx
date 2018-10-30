﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public virtual ICollection<Person> People { get; set; }

    }
}
