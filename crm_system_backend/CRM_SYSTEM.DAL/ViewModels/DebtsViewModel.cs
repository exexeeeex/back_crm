﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_SYSTEM.DAL.ViewModels
{
    public class DebtsViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Lesson { get; set; }
        public string Date { get; set; }
    }
}
