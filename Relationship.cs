using System;
using System.Collections.Generic;
using System.Text;

namespace DataEase
{
    public enum RelationshipSecurityLevel
    {
        High = 1,
        Medium1 = 2,
        Medium2 = 3,
        Medium3 = 4,
        Low1 = 5,
        Low2 = 6,
        Low3 = 7,
        Hide = 8
    }

    public enum RelationshipFormModifyType
    {
        /// <summary>
        /// Not set.
        /// </summary>
        None = 0,

        /// <summary>
        /// Cascade - update.
        /// </summary>
        Cascade = 1,
        
        /// <summary>
        /// Null (Black).
        /// </summary>
        Null = 2,
        
        /// <summary>
        /// Restrict - do not update.
        /// </summary>
        Restrict = 3
    }

    public class FieldSet
    {
        /// <summary>
        /// Primary table filter field name.
        /// </summary>
        public string PrimaryFieldName { get; set; }
        
        /// <summary>
        /// Foreign table filter field name.
        /// </summary>
        public string ForeignFieldName { get; set; } 
    }

    public class Relationship
    {
        /// <summary>
        /// Primary table name (Form1 in DataEase).
        /// </summary>
        public string PrimaryTableName { get; set; }

        /// <summary>
        /// Foreign table name (Form2 in DataEase).
        /// </summary>
        public string ForeignTableName { get; set; }

        /// <summary>
        /// First set of field filters - Required.
        /// </summary>
        public FieldSet FirstFieldFilter { get; set; } = new FieldSet();

        /// <summary>
        /// Second set of field filters - Optional.
        /// </summary>
        public FieldSet SecondFieldFilter { get; set; } = new FieldSet();

        /// <summary>
        /// Third set of field filters - Optional.
        /// </summary>
        public FieldSet ThridFieldFilter { get; set; } = new FieldSet();

        /// <summary>
        /// Primary table modification type on change.
        /// </summary>
        public RelationshipFormModifyType PrimaryTableModifyType { get; set; }

        /// <summary>
        /// Foreign table modification type on change.
        /// </summary>
        public RelationshipFormModifyType ForeignTableModifyType { get; set; }

        /// <summary>
        /// Primary relationship name.
        /// </summary>
        public string PrimaryRelationshipName { get; set; }

        /// <summary>
        /// Foreign relationship name.
        /// </summary>
        public string ForeignRelationshipName { get; set; }

        /// <summary>
        /// Primary table security level.
        /// </summary>
        public RelationshipSecurityLevel PrimaryTableSecurity { get; set; }

        /// <summary>
        /// Foreign table security level.
        /// </summary>
        public RelationshipSecurityLevel ForeignTableSecurity { get; set; }
    }
}
