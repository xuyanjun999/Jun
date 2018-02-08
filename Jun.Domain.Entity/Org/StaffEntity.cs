using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using Jun.Core.Domain.Entity;

namespace Jun.Domain.Entity.Org
{
    /// <summary>
    /// 员工表映射类
    /// </summary>
    public class StaffEntity : BaseAcsRecTreeNodeEntity
    {

        /// <summary>
        /// 员工工号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        public string EnName { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string CnName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 头像路径
        /// </summary>
        public string PortraitPath { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public long? DeptID { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        [AjaxNonSerializable]
        public virtual DepartmentEntity Department { get; set; }

        /// <summary>
        /// 登录用户
        /// </summary>
        [AjaxNonSerializable]
        public virtual UserEntity User { get; set; }
        /// <summary>
        /// 管理的合同
        /// </summary>
        [AjaxNonSerializable]
        public virtual List<Contract.ContractEntity> Contracts { get; set; }
        /// <summary>
        /// SO释放
        /// </summary>
        [AjaxNonSerializable]
        public virtual List<SOFormulaEntity> SOFormulas { get; set; }

        /// <summary>
        /// SO 释放 副本
        /// </summary>
        [AjaxNonSerializable]
        public virtual List<SOFormulaDuplicateEntity> SOFormulaDuplicate { get; set; }


        [NotMapped]
        public override string Text
        {
            get
            {
                return CnName;
            }
        }

        /// <summary>
        /// 员工编号(西尼要求增加)
        /// </summary>
        public string StaffCode { get; set; }


        /// <summary>
        /// 上级领导ID
        /// </summary>
        public long? LeaderStaffID { get; set; }

        /// <summary>
        /// 上级领导
        /// </summary>
        [AjaxNonSerializable]
        public StaffEntity LeaderStaff { get; set; }
    }
}
