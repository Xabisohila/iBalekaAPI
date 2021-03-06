﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iBalekaAPI.Models
{
    public partial class Checkpoint
    {
        public Checkpoint() { }
        public Checkpoint(double lat, double lng)
        {
            Latitude = lat;
            Longitude = lng;
            Deleted = false;
        }
        [Key]
        public int CheckpointId { get; set; }
        public bool Deleted { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int RouteId { get; set; }
        [JsonIgnore]
        public virtual Route Route { get; set; }
    }
}
