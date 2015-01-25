﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Library
{
    /// <summary>Title</summary>
    /// <remarks></remarks>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_Title", true, "id")]
    [BindIndex("IX_Title_Guid", false, "Guid")]
    [BindRelation("Guid", false, "Mesh", "TitleGuid")]
    [BindTable("Title", Description = "", ConnName = "PubMed", DbType = DatabaseType.SqlServer)]
    public partial class Title : ITitle
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

        private String _TI;
        /// <summary></summary>
        [DisplayName("TI")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(2, "TI", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String TI
        {
            get { return _TI; }
            set { if (OnPropertyChanging(__.TI, value)) { _TI = value; OnPropertyChanged(__.TI); } }
        }

        private Int32 _DP;
        /// <summary></summary>
        [DisplayName("DP")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "DP", "", null, "int", 10, 0, false)]
        public virtual Int32 DP
        {
            get { return _DP; }
            set { if (OnPropertyChanging(__.DP, value)) { _DP = value; OnPropertyChanged(__.DP); } }
        }

        private Int32 _VI;
        /// <summary></summary>
        [DisplayName("VI")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "VI", "", null, "int", 10, 0, false)]
        public virtual Int32 VI
        {
            get { return _VI; }
            set { if (OnPropertyChanging(__.VI, value)) { _VI = value; OnPropertyChanged(__.VI); } }
        }

        private Int32 _PG;
        /// <summary></summary>
        [DisplayName("PG")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "PG", "", null, "int", 10, 0, false)]
        public virtual Int32 PG
        {
            get { return _PG; }
            set { if (OnPropertyChanging(__.PG, value)) { _PG = value; OnPropertyChanged(__.PG); } }
        }

        private Guid _Guid;
        /// <summary></summary>
        [DisplayName("Guid")]
        [Description("")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn(6, "Guid", "", null, "uniqueidentifier", 0, 0, false)]
        public virtual Guid Guid
        {
            get { return _Guid; }
            set { if (OnPropertyChanging(__.Guid, value)) { _Guid = value; OnPropertyChanged(__.Guid); } }
        }

        private Int32 _PMID;
        /// <summary></summary>
        [DisplayName("Pmid")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "PMID", "", null, "int", 10, 0, false)]
        public virtual Int32 PMID
        {
            get { return _PMID; }
            set { if (OnPropertyChanging(__.PMID, value)) { _PMID = value; OnPropertyChanged(__.PMID); } }
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
                    case __.TI : return _TI;
                    case __.DP : return _DP;
                    case __.VI : return _VI;
                    case __.PG : return _PG;
                    case __.Guid : return _Guid;
                    case __.PMID : return _PMID;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.id : _id = Convert.ToInt32(value); break;
                    case __.TI : _TI = Convert.ToString(value); break;
                    case __.DP : _DP = Convert.ToInt32(value); break;
                    case __.VI : _VI = Convert.ToInt32(value); break;
                    case __.PG : _PG = Convert.ToInt32(value); break;
                    case __.Guid : _Guid = (Guid)value; break;
                    case __.PMID : _PMID = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Title字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field id = FindByName(__.id);

            ///<summary></summary>
            public static readonly Field TI = FindByName(__.TI);

            ///<summary></summary>
            public static readonly Field DP = FindByName(__.DP);

            ///<summary></summary>
            public static readonly Field VI = FindByName(__.VI);

            ///<summary></summary>
            public static readonly Field PG = FindByName(__.PG);

            ///<summary></summary>
            public static readonly Field Guid = FindByName(__.Guid);

            ///<summary></summary>
            public static readonly Field PMID = FindByName(__.PMID);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得Title字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String id = "id";

            ///<summary></summary>
            public const String TI = "TI";

            ///<summary></summary>
            public const String DP = "DP";

            ///<summary></summary>
            public const String VI = "VI";

            ///<summary></summary>
            public const String PG = "PG";

            ///<summary></summary>
            public const String Guid = "Guid";

            ///<summary></summary>
            public const String PMID = "PMID";

        }
        #endregion
    }

    /// <summary>Title接口</summary>
    /// <remarks></remarks>
    public partial interface ITitle
    {
        #region 属性
        /// <summary></summary>
        Int32 id { get; set; }

        /// <summary></summary>
        String TI { get; set; }

        /// <summary></summary>
        Int32 DP { get; set; }

        /// <summary></summary>
        Int32 VI { get; set; }

        /// <summary></summary>
        Int32 PG { get; set; }

        /// <summary></summary>
        Guid Guid { get; set; }

        /// <summary></summary>
        Int32 PMID { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}