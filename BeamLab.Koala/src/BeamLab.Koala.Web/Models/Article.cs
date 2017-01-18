using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeamLab.Koala.Web.Models
{
    public class Article
    {
        public int ID { get; set; }

        public DateTime PublishDate { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }

        public bool Draft { get; set; }
    }
}
