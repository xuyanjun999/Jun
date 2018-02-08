using Jun.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Core.Dto.RequestModel
{
    public class BatchModel<T> where T : BaseEntity, new()
    {
        public T[] Entitys { get; set; }
    }
}
