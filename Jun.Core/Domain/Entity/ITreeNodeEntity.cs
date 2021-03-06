﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Jun.Core.Domain.Entity
{
    /// <summary>
    /// 树节点实例接口
    /// </summary>
    public interface ITreeNodeEntity
    {
        /// <summary>
        /// 是否末节点
        /// </summary>
        bool Leaf { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// 图标资源
        /// </summary>
        string IconCls { get; set; }

        /// <summary>
        /// 节点是否已经勾选
        /// </summary>
        bool Checked { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        bool Expanded { get; set; }

    }
}
