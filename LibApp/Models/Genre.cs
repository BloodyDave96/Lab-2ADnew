﻿using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }
    }
}
