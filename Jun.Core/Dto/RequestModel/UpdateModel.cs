using Jun.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Core.Dto.RequestModel
{
    public class UpdateModel<T> where T : BaseEntity, new()
    {
        public T Entity { get; set; }

        public string[] Modified { get; set; }
    }
}
