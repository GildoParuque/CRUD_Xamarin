using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Xamarin.Models
{
    public class PayStatement
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public List<WorkItem> WorkItems { get; set; }
    }
}
