using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martian_Robots.Dtos
{
    public class StringDto
    {
        public string result { get; set; }
        public StringDto() { }
        public StringDto(string result) { this.result = result; }
    }
}
