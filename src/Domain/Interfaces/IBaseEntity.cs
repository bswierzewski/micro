using System;

namespace micro_api.Domain.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        DateTime Created { get; set; }

        string CreatedBy { get; set; }

        DateTime? LastModified { get; set; }

        string LastModifiedBy { get; set; }
    }
}