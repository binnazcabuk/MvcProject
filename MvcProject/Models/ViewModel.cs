using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    

    public class ViewModel
    {
        public IEnumerable<Heading> Headings { get; set; }
        public IEnumerable<Content> Contents{ get; set; }
    }

}