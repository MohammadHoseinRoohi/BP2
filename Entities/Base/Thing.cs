using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2.Entities.Base
{
    public class Thing
    {
        public int Id { get; set; }
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
    }
}