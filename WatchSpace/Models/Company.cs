﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WatchSpace.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}