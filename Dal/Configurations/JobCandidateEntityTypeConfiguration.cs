using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class JobCandidateEntityTypeConfiguration : IEntityTypeConfiguration<JobCandidate>
    {
        public void Configure(EntityTypeBuilder<JobCandidate> builder)
        {
            builder
                .HasKey(x => x.JobCandidateId);

            builder
                .HasOne(x => x.BusinessEntity)
                .WithMany(x => x.JobCandidates)
                .HasForeignKey(x => x.BusinessEntityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.JobCandidateId)
                .HasColumnName("JobCandidateID")
                .HasPrecision(10, 0)
                .HasComment("Primary key for JobCandidate records.");

            builder
                .Property(x => x.Resume)
                .HasColumnName("Resume")
                .HasColumnType("xml")
                .HasComment("Résumé in XML format.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("JobCandidate", "HumanResources");
        }
    }
}
