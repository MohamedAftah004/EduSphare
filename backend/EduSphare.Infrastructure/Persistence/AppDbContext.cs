using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Application.Abstractions.Persistence;
using EduSphare.Domain.Users;
using EduSphare.Domain.Users.Sessions;
using EduSphare.Domain.Verifications;

namespace EduSphare.Infrastructure.Persistence
{
    public sealed class AppDbContext : DbContext , IUnitOfWork
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


        #region DbSets

        public DbSet<User> Users => Set<User>();
        public DbSet<Verification> Verifications => Set<Verification>();
        public DbSet<UserSession> UserSessions => Set<UserSession>();

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
