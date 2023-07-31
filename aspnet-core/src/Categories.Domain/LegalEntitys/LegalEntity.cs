
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Categories.LegalEntitys;

public class LegalEntity : AuditedAggregateRoot<Guid>
{
    public string Code { get; set; }
    public string Description { get; set; }
    public string ImportBy { get; set; }
}
