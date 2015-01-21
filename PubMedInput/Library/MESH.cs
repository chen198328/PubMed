﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Library
{
    /// <summary>Mesh</summary>
    /// <remarks></remarks>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_MESH", true, "id")]
    [BindIndex("IX_MESH_TitleGuid", false, "TitleGuid")]
    [BindRelation("TitleGuid", false, "Title", "Guid")]
    [BindTable("MESH", Description = "", ConnName = "PubMed", DbType = DatabaseType.SqlServer)]
    public partial class MESH : IMESH
    {
        #region 属性
        private Int32 _id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "id", "", null, "int", 10, 0, false)]
        public virtual Int32 id
        {
            get { return _id; }
            set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
        }

        private String _TitleGuid;
        /// <summary></summary>
        [DisplayName("TitleGuid")]
        [Description("")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn(2, "TitleGuid", "", null, "varchar(32)", 0, 0, false)]
        public virtual String TitleGuid
        {
            get { return _TitleGuid; }
            set { if (OnPropertyChanging(__.TitleGuid, value)) { _TitleGuid = value; OnPropertyChanged(__.TitleGuid); } }
        }

        private Int32 _PMID;
        /// <summary></summary>
        [DisplayName("Pmid")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "PMID", "", null, "int", 10, 0, false)]
        public virtual Int32 PMID
        {
            get { return _PMID; }
            set { if (OnPropertyChanging(__.PMID, value)) { _PMID = value; OnPropertyChanged(__.PMID); } }
        }

        private String _MH;
        /// <summary></summary>
        [DisplayName("MH")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "MH", "", null, "nchar(10)", 0, 0, true)]
        public virtual String MH
        {
            get { return _MH; }
            set { if (OnPropertyChanging(__.MH, value)) { _MH = value; OnPropertyChanged(__.MH); } }
        }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.id : return _id;
                    case __.TitleGuid : return _TitleGuid;
                    case __.PMID : return _PMID;
                    case __.MH : return _MH;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.id : _id = Convert.ToInt32(value); break;
                    case __.TitleGuid : _TitleGuid = Convert.ToString(value); break;
                    case __.PMID : _PMID = Convert.ToInt32(value); break;
                    case __.MH : _MH = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Mesh字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary></summary>
            public static readonly Field TitleGuid = FindByName(__.TitleGuid);

            ///<summary></summary>
            public static readonly Field PMID = FindByName(__.PMID);

            ///<summary></summary>
            public static readonly Field MH = FindByName(__.MH);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得Mesh字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String id = "id";

            ///<summary></summary>
            public const String TitleGuid = "TitleGuid";

            ///<summary></summary>
            public const String PMID = "PMID";

            ///<summary></summary>
            public const String MH = "MH";

        }
        #endregion
    }

    /// <summary>Mesh接口</summary>
    /// <remarks></remarks>
    public partial interface IMESH
    {
        #region 属性
        /// <summary></summary>
        Int32 id { get; set; }

        /// <summary></summary>
        String TitleGuid { get; set; }

        /// <summary></summary>
        Int32 PMID { get; set; }

        /// <summary></summary>
        String MH { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}