using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

public partial class WF_Action
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public WF_Action()
    {
        this.AssnActionSchemaTemplates = new HashSet<AssnActionSchemaTemplate>();
        this.WF_State2 = new HashSet<WF_State>();
        this.RoleMasters = new HashSet<RoleMaster>();
        this.RoleMasters1 = new HashSet<RoleMaster>();
    }

    public int Id { get; set; }
    public int DefinitionID { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public Nullable<int> SourceStateID { get; set; }
    public Nullable<int> DestinationStateID { get; set; }
    public Nullable<int> ActionViewID { get; set; }
    public bool IsVisible { get; set; }
    public bool IsDeleted { get; set; }
    public Nullable<int> ViewOrder { get; set; }
    public Nullable<int> CaseConditionID { get; set; }
    public string CaseConditionParam { get; set; }
    public Nullable<bool> IsBulk { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<AssnActionSchemaTemplate> AssnActionSchemaTemplates { get; set; }
    public virtual WF_ActionView WF_ActionView { get; set; }
    public virtual WF_CaseCondition WF_CaseCondition { get; set; }
    public virtual WF_Definition WF_Definition { get; set; }
    public virtual WF_State WF_State { get; set; }
    public virtual WF_State WF_State1 { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<WF_State> WF_State2 { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<RoleMaster> RoleMasters { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<RoleMaster> RoleMasters1 { get; set; }
}
