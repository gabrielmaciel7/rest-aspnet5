﻿using RestWithASPNET5.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Models
{
    [Table("books")]
    public class Book : Base
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }

        [Column("price")]
        public float Price { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
