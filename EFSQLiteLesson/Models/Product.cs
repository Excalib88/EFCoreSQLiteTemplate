﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFSQLiteLesson
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
