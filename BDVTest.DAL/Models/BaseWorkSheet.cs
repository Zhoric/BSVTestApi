using System;
using System.ComponentModel.DataAnnotations;

namespace BDVTest.DAL.Models
{
    public abstract class BaseWorkSheet
    {
        [Key]
        public Int64 Id { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public String Col1 { get; set; }
        
        public String Col2 { get; set; }
        
        public String Col3 { get; set; }
        
        public String Col4 { get; set; }
        
        public String Col5 { get; set; }
        
        public String Col6 { get; set; }
        
        public String Col7 { get; set; }
        
        public String Col8 { get; set; }
        
        public String Col9 { get; set; }
        
        public String Col10 { get; set; }
        
        public String Col11 { get; set; }
        
        public String Col12 { get; set; }
        
        public String Col13 { get; set; }
        
        public String Col14 { get; set; }
        
        public String Col15 { get; set; }
        
        public String Col16 { get; set; }
        
        public String Col17 { get; set; }
        
        public String Col18 { get; set; }
        
        public String Col19 { get; set; }
        
        public String Col20 { get; set; }
    } 
}