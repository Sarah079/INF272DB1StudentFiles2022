using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF272DB1StudentFiles2022.Models
{
    public class DestinationModel
    {
        //create data properties and constructors

        public string Website { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }

        public List<DestinationModel> Destinations { get; set; }
    }
}