﻿namespace BeerOverflow.Models
{
    public class BeerQueryParameters
    {
        public string Name { get; set; }
        public double? MinAbv { get; set; }
        public double? MaxAbv { get; set; }
        public int? StyleId { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

    }
}
