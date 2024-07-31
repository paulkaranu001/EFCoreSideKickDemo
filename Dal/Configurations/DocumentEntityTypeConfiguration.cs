using EFCoreSideKickDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EFCoreSideKickDemo
{
    public class DocumentEntityTypeConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder
                .HasKey(x => x.DocumentNode);

            builder
                .HasIndex(x => new { x.DocumentLevel, x.DocumentNode })
                .IsUnique()
                .HasDatabaseName("AK_Document_DocumentLevel_DocumentNode");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("AK_Document_rowguid");

            builder
                .HasIndex(x => new { x.FileName, x.Revision })
                .HasDatabaseName("IX_Document_FileName_Revision");

            builder
                .HasIndex(x => x.Rowguid)
                .IsUnique()
                .HasDatabaseName("UQ__Document__F73921F7C81C642F");

            builder
                .HasOne(x => x.DocumentEmployeeOwner)
                .WithMany(x => x.DocumentEmployeeOwners)
                .HasForeignKey(x => x.Owner)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.DocumentNode)
                .HasColumnName("DocumentNode")
                .HasComment("Primary key for Document records.");

            builder
                .Property(x => x.DocumentLevel)
                .HasColumnName("DocumentLevel")
                .HasComputedColumnSql("([DocumentNode].[GetLevel]())")
                .HasComment("Depth in the document hierarchy.");

            builder
                .Property(x => x.Title)
                .HasColumnName("Title")
                .IsUnicode(true)
                .HasComment("Title of the document.");

            builder
                .Property(x => x.FolderFlag)
                .HasColumnName("FolderFlag")
                .HasDefaultValueSql("((0))")
                .HasComment("0 = This is a folder, 1 = This is a document.");

            builder
                .Property(x => x.FileName)
                .HasColumnName("FileName")
                .IsUnicode(true)
                .HasComment("File name of the document");

            builder
                .Property(x => x.FileExtension)
                .HasColumnName("FileExtension")
                .IsUnicode(true)
                .HasComment("File extension indicating the document type. For example, .doc or .txt.");

            builder
                .Property(x => x.Revision)
                .HasColumnName("Revision")
                .HasColumnType("nchar")
                .IsUnicode(true)
                .IsFixedLength()
                .HasComment("Revision number of the document. ");

            builder
                .Property(x => x.ChangeNumber)
                .HasColumnName("ChangeNumber")
                .HasPrecision(10, 0)
                .HasDefaultValueSql("((0))")
                .HasComment("Engineering change approval number.");

            builder
                .Property(x => x.Status)
                .HasColumnName("Status")
                .HasPrecision(3, 0)
                .HasComment("1 = Pending approval, 2 = Approved, 3 = Obsolete");

            builder
                .Property(x => x.DocumentSummary)
                .HasColumnName("DocumentSummary")
                .IsUnicode(true)
                .HasComment("Document abstract.");

            builder
                .Property(x => x.Document1)
                .HasColumnName("Document")
                .HasComment("Complete document.");

            builder
                .Property(x => x.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Required for FileStream.");

            builder
                .Property(x => x.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder
                .ToTable("Document", "Production");

            builder
                .ToTable(c => c.HasCheckConstraint("CK_Document_Status", "([Status]>=(1) AND [Status]<=(3))"));
        }
    }
}
