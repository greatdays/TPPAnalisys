using System;
using System.Collections.Generic;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated;

/// <summary>
/// Config table to control number generation in system.
/// </summary>
public partial class CfgNextRun
{
    /// <summary>
    /// Primary Key Identity column for the CfgNextRun table
    /// </summary>
    public int CfgNextRunId { get; set; }

    /// <summary>
    /// Description for this record
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Generate Number prefix
    /// </summary>
    public string? Prefix { get; set; }

    /// <summary>
    /// use for program logic the length for the pass in paramater
    /// </summary>
    public string? PrefixSubString { get; set; }

    /// <summary>
    /// Generate Number suffix
    /// </summary>
    public string? Suffix { get; set; }

    /// <summary>
    /// Type of how generate seq number
    /// </summary>
    public int? SeqType { get; set; }

    /// <summary>
    /// The name of the sequence number set being use
    /// </summary>
    public string? SeqName { get; set; }

    /// <summary>
    /// The date that the sequence reset
    /// </summary>
    public string? LastResetYymmdd { get; set; }

    /// <summary>
    /// formula use for computer logic
    /// </summary>
    public string? MatchSubString { get; set; }

    /// <summary>
    /// if reset sequence, what will be the starting number
    /// </summary>
    public bool? ResetSeq { get; set; }

    /// <summary>
    /// Start range for the seq number start
    /// </summary>
    public int? StartNum { get; set; }

    /// <summary>
    /// End range for the seq number end
    /// </summary>
    public int? EndNum { get; set; }

    /// <summary>
    /// last generate number the sequence
    /// </summary>
    public int? LastNum { get; set; }

    /// <summary>
    /// len for the number, use for put leading Zero
    /// </summary>
    public int? NumLen { get; set; }

    /// <summary>
    /// the number before resent the sequence
    /// </summary>
    public int? LastNumBeforeReset { get; set; }

    /// <summary>
    /// formula for the generate result
    /// </summary>
    public string? ConcatString { get; set; }

    /// <summary>
    /// Unique ID in system
    /// </summary>
    public Guid RowId { get; set; }

    public string? SeqTable { get; set; }

    public string? SeqUid { get; set; }

    public string? SeqField { get; set; }

    public string? ResetCycle { get; set; }

    public string? TargetField { get; set; }
}
