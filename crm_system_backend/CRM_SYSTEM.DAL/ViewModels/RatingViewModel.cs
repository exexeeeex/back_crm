using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_SYSTEM.DAL.ViewModels
{
    public class RatingViewModel
    {
        public int NumberOfTwos { get; set; }
        public int NumberOfTriplets { get; set; }
        public int NumberOfFours { get; set; }
        public int NumberOfFives { get; set; }
    }
}
