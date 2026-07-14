using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Domain.Users;

namespace EduSphare.Infrastructure.Persistence
{
    public sealed class AppDbContext : DbContext , IUnitOfWork
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


        #region DbSets

        public DbSet<User> Users => Set<User>();

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
