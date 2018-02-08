using Jun.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Core.Dto.RequestModel
{
    public class SingleModel
    {
        public int Id { get; set; }

        public string[] Include { get; set; }
    }
}
