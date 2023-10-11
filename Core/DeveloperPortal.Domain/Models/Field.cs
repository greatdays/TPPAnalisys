using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess;

public partial class Field
{
    public int FieldId { get; set; }

    public int? FormId { get; set; }

    public int? ParentId { get; set; }

    public int? ReferenceId { get; set; }

    public string? UniqueId { get; set; }

    public string FieldName { get; set; } = null!;

    public string FieldLabel { get; set; } = null!;

    public string FieldType { get; set; } = null!;

    public string? TableName { get; set; }

    public string? DataTextField { get; set; }

    public string? DataValueField { get; set; }

    public string? FieldHtml { get; set; }

    public string? HelpText { get; set; }

    public bool? IsPredefined { get; set; }

    public bool? IsCustom { get; set; }

    public int? FieldOrder { get; set; }

    public string? FieldJson { get; set; }

    public int? MaxLength { get; set; }

    public int? MinValue { get; set; }

    public int? MaxValue { get; set; }

    public string? DefaultValue { get; set; }

    public string? Calculation { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsConditionalRequired { get; set; }

    public bool? IsRequired { get; set; }

    public int? Cols { get; set; }

    public int? Rows { get; set; }

    public string? InputDirection { get; set; }

    public bool? ComputeTotal { get; set; }

    public bool? ShowTotal { get; set; }

    public string? ParentStyle { get; set; }

    public string? PatternType { get; set; }

    public string? Pattern { get; set; }

    public string? ConditionOnField { get; set; }

    public string? ConditionalOperator { get; set; }

    public string? ConditionalValue { get; set; }

    public string? FooterType { get; set; }

    public bool IsMultipleFile { get; set; }

    public bool ShowDate { get; set; }

    public bool ShowTime { get; set; }

    public string? Placeholder { get; set; }

    public bool IsDependent { get; set; }

    public string? DependentSource { get; set; }

    public string? LookupTable { get; set; }

    public string? LookupColumn { get; set; }

    public string? MatchColumn { get; set; }

    public string? DependentOn { get; set; }

    public bool IsAllowFutureDate { get; set; }

    public bool IsAllowPastDate { get; set; }

    public bool IsWeekendDisabled { get; set; }

    public string? FormSectionType { get; set; }

    public bool ShowInSearch { get; set; }

    public bool IsReadOnly { get; set; }

    public bool IsAllowAutocomplete { get; set; }

    public bool IsAllowConditionalHideShow { get; set; }

    public bool IsConditionalHideShow { get; set; }

    public string? ConditionalHideShowField { get; set; }

    public string? ConditionalHideShowValue { get; set; }

    public string? ConditionalHideShowOperator { get; set; }

    public bool? ShowSessionValue { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? RowId { get; set; }

    public string? MappingColumn { get; set; }

    public string? MappingTable { get; set; }

    public bool? IsAssigneeDropdown { get; set; }

    public bool? IsJson { get; set; }

    public virtual Form? Form { get; set; }

    public virtual ICollection<Field> InverseParent { get; set; } = new List<Field>();

    public virtual ICollection<Field> InverseReference { get; set; } = new List<Field>();

    public virtual Field? Parent { get; set; }

    public virtual Field? Reference { get; set; }
}
