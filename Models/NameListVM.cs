using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDAssignment.Models
{
    public class NameListVM
    {
        public int SeqID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public virtual Users Users { get; set; }
        public List<NameListVM> gridList { get; set; }

    }
}