﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Categories
{
    public class CreateCategoryDto : CategoryBaseDto
    {
        public required string Name { get; set; }
    }
}