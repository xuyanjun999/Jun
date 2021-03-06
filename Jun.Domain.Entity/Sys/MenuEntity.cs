﻿using Jun.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jun.Domain.Entity.Sys
{
    [Table("SGEAP_Sys_Menu")]
    public class MenuEntity : BaseAcsRecTreeNodeEntity
    {
        /// <summary>
        /// 菜单名字
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// 图标资源
        /// </summary>
        public string IconResource { get; set; }
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// 菜单描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 菜单次序
        /// </summary>
        public int SequenceIndex { get; set; }
        /// <summary>
        /// 菜单标识码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 菜单模块相对位置
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 父菜单对象
        /// </summary>
        public MenuEntity Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public override string IconCls
        {
            get
            {
                return this.IconResource;
            }
        }

        [NotMapped]
        public override string Text
        {
            get
            {
                return this.Name;
            }
        }

    }

    public class MenuMap : EntityConfigurationBase<MenuEntity>
    {
        public override void Configure(EntityTypeBuilder<MenuEntity> builder)
        {
            builder.ToTable("SGEAP_Sys_Menu");
            builder.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId);
            base.Configure(builder);
        }
    }
}
