﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Dtos
{
    public record LoginRequest(
      string? Email,
      string? Password)
    {
        public LoginRequest() : this(default, default)
        {

        }
    }
}
