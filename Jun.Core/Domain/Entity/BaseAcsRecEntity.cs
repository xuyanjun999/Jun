using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jun.Core.Domain.Entity
{
    /// <summary>
    /// 表操作记录基类
    /// </summary>
    public class BaseAcsRecEntity : BaseEntity,IAccessRecordEntity<int>
    {

        /// <summary>
        /// 创建相关时间
        /// </summary>
        public DateTime CreateOn { get; set; }
        /// <summary>
        /// 更新相关时间
        /// </summary>
        public DateTime UpdateOn { get; set; }


        public int CreateUserId { get; set; }

        public string CreateStaffName { get; set; } 

        public int UpdateUserId { get; set; } 

        public string UpdateStaffName { get; set; }
    }
}
