﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Models.Entities
{
    public class Country
    {
        [Key]
        public int ISOCode { get; set; }

        public string Name { get; set; }

        public string UrlPng { get; set; }

        public string UrlSvg { get; set; }
    }
}
