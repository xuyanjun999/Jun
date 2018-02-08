using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Jun.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jun.Domain.Entity.Org
{
    /// <summary>
    /// 公司表映射实例
    /// </summary>
    [Table("SGEAP_Org_Company")]
    public class CompanyEntity : BaseAcsRecTreeNodeEntity
    {

        /// <summary>
        /// 英文名
        /// </summary>
        public string EnName { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string CnName { get; set; }
        /// <summary>
        /// 公司简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        public string Code { get; set; }



        public BaseCompType CompType { get; set; }


        /// <summary>
        /// Logo路径
        /// </summary>
        public string LogoPath { get; set; }

        /// <summary>
        /// 公司主页
        /// </summary>
        public string Homepage { get; set; }
        /// <summary>
        /// 公司邮编
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string Bank { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 单位税号
        /// </summary>
        public string Tax { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPerson { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactTelephone { get; set; }

        /// <summary>
        /// 公司描述
        /// </summary>
        public string Remark { get; set; }


        /*###  以上为补充字段 Add 2014-09-30 by JFW  End ###*/
        [NotMapped]
        public override string Text
        {
            get
            {
                return CnName;
            }
        }
    }

    public class CompanyMap : EntityConfigurationBase<CompanyEntity>
    {
        public override void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.ToTable("SGEAP_Org_Company");
            base.Configure(builder);
        }
    }

    /// <summary>
    /// 公司类型
    /// </summary>
    public enum BaseCompType
    {
        /// <summary>
        /// 本公司
        /// </summary>
        [DescriptionAttribute("本公司")]
        Owner = 1,
        /// <summary>
        /// 供应商
        /// </summary>
        [DescriptionAttribute("供应商")]
        Supplier = 2,
        /// <summary>
        /// 客户
        /// </summary>
        [DescriptionAttribute("客户")]
        Client = 4,
        /// <summary>
        /// 代理商
        /// </summary>
        [DescriptionAttribute("代理商")]
        Agent = 8,
        /// <summary>
        ///子公司 
        /// </summary>
        [DescriptionAttribute("子公司")]
        SubCompany = 16,
        /// <summary>
        /// 其他类型
        /// </summary>
        [DescriptionAttribute("其他类型")]
        Other = 32
    }
}
