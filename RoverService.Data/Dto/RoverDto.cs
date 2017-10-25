using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverService.Data.Dto
{
    public class RoverDto
    {
        public string RoverId { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public int Direction { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

