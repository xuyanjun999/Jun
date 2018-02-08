using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Jun.Core.Domain.Entity;

namespace SJun.Domain.Entity.Org
{
    /// <summary>
    /// 公司部门
    /// </summary>
    public class DepartmentEntity : BaseAcsRecTreeNodeEntity
    {
        /// <summary>
        /// 部门英文名
        /// </summary>
        public string EnName { get; set; }
        /// <summary>
        /// 部门中文名
        /// </summary>
        public string CnName { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 部门描述
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 部门电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 部门邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 父部门ID
        /// </summary>
        public long? ParentID { get; set; }
        /// <summary>
        /// 父部门
        /// </summary>
        [AjaxNonSerializable]
        public virtual DepartmentEntity Parent { get; set; }
        /// <summary>
        /// 子部门
        /// </summary>
        [AjaxNonSerializable]
        public virtual List<DepartmentEntity> Departments { get; set; }

        [NotMapped]
        public override string Text
        {
            get
            {
                return CnName;
            }
        }
        /// <summary>
        /// 公司ID
        /// </summary>
        public long? CompyID { get; set; }
        /// <summary>
        /// 所属公司对象
        /// </summary>
        [AjaxNonSerializable]
        public virtual CompanyEntity Company { get; set; }
        /// <summary>
        /// 部门员工
        /// </summary>
        [AjaxNonSerializable]
        public virtual List<StaffEntity> Staffs { get; set; }
    }
}
