using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice2.Enums;

namespace Practice2.DTOs.Members
{
    public class MemberListDto
    {
        public string? Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public Gender Gender { get; set; }
    }
}