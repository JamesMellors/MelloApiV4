
using MelloApiV4.Data;
using MelloApiV4.Data.Entities.Translation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Repository
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, RoleIdentity, int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TranslationEntity>()
                .ToTable("Translation")
                .Property(o => o.Id)
                .HasColumnName("Id");
        }

    }
}