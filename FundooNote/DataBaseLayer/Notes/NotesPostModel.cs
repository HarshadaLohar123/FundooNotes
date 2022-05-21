﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Notes
{
    public class NotesPostModel
    {
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Color { get; set; }
    }
}
