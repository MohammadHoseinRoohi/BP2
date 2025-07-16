using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice2.Enums;

namespace Practice2.DTOs.Members
{
    public class MemberAddDto
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public Gender? Gender { get; set; } //Question
        public double PhoneNumber { get; set; }
        public double Password { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
    }
}