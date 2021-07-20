﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Common;
using SchoolManagement.Model.Account;
using SchoolManagement.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Configurations.Master
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student", Schema.MASTER);

            builder.HasKey(x => x.Id);

            //to be implement foriegn key
            /*builder.HasOne(st => st.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(fk => fk.ID);
            */
            builder.HasOne<User>(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(fk => fk.Id);

            builder.HasOne<User>(x => x.CreatedBy)
                 .WithMany(u => u.CreatedStudents)
                 .HasForeignKey(f => f.CreatedById)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired(false);

            builder.HasOne<User>(x => x.UpdatedBy)
                .WithMany(u => u.UpdatedStudents)
                .HasForeignKey(f => f.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

        }
    }
}