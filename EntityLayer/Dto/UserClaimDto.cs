﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dto
{
    public class UserClaimDto
    {
        public ulong UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
    }
}
