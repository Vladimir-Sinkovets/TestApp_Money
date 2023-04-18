﻿namespace TestApp_Money.Web.Models
{
    public class AddRecordViewModel
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
        public IList<string> AllCategories { get; set; }
    }
}
