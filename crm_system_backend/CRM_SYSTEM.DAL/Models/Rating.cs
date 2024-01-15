using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_SYSTEM.DAL.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int Grade { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
