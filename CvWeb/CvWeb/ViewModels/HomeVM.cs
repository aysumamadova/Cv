using CvWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvWeb.ViewModels
{
    public class HomeVM
    {
        public List<Awards> Awards { get; set; }
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Interests> Interests { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Skills2> Skills2 { get; set; }

    }
}
