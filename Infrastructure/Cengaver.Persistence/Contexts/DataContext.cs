using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Cengaver.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;



namespace Cengaver.Persistence
{
    public class DataContext : IdentityDbContext<User> 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CommunicationType> CommunicationTypes { get; set; }
        public DbSet<GuardDuty> GuardDuties { get; set; }
        public DbSet<GuardDutyBreak> GuardDutyBreaks { get; set; }
        public DbSet<GuardDutyBreakType> GuardDutyBreakTypes { get; set; }
        public DbSet<GuardDutyNote> GuardDutyNotes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamTransactionLog> TeamTransactionLogs { get; set; }
        public DbSet<UserCommunication> UserCommunications { get; set; }
        public DbSet<UserIsInTeamRelation> UserIsInTeamRelations { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserTransactionLog> UserTransactionLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("YourConnectionString", b => b.MigrationsAssembly("CengaverAPI"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User 
            modelBuilder.Entity<User>()
                .Property(u => u.SicilNo)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd(); 

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired(false);

            // User relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserIsInTeamRelations)
                .WithOne(uitr => uitr.User)
                .HasForeignKey(uitr => uitr.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.GuardDuties)
                .WithOne(gd => gd.WardenUser)
                .HasForeignKey(gd => gd.WardenUserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.GuardDutyBreaks)
                .WithOne(gdb => gdb.User)
                .HasForeignKey(gdb => gdb.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserTransactionLogs)
                .WithOne(utl => utl.User)
                .HasForeignKey(utl => utl.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserCommunications)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<GuardDuty>()
                .HasKey(gd => gd.Id);

            modelBuilder.Entity<GuardDuty>()
                .HasMany(gd => gd.GuardDutyNotes)
                .WithOne(gdn => gdn.GuardDuty)
                .HasForeignKey(gdn => gdn.GuardDutyId);

            // GuardDutyNote
            modelBuilder.Entity<GuardDutyNote>()
                .HasKey(gdn => gdn.Id);

            modelBuilder.Entity<GuardDutyNote>()
                .HasOne(gdn => gdn.GuardDuty)
                .WithMany(gd => gd.GuardDutyNotes)
                .HasForeignKey(gdn => gdn.GuardDutyId);

            modelBuilder.Entity<GuardDutyNote>()
                .HasOne(gdn => gdn.NoteType)
                .WithMany(gdnt => gdnt.GuardDutyNotes)
                .HasForeignKey(gdn => gdn.NoteTypeId);

            // GuardDutyNoteType 
            modelBuilder.Entity<GuardDutyNoteType>()
                .HasKey(gdnt => gdnt.NoteTypeId);

            modelBuilder.Entity<GuardDutyNoteType>()
                .HasMany(gdnt => gdnt.GuardDutyNotes)
                .WithOne(gdn => gdn.NoteType)
                .HasForeignKey(gdn => gdn.NoteTypeId);

            // GuardDutyBreak
            modelBuilder.Entity<GuardDutyBreak>()
                .HasKey(gdb => gdb.Id);

            modelBuilder.Entity<GuardDutyBreak>()
                .HasOne(gdb => gdb.User)
                .WithMany(u => u.GuardDutyBreaks)
                .HasForeignKey(gdb => gdb.UserId);

            modelBuilder.Entity<GuardDutyBreak>()
                .HasOne(gdb => gdb.GuardDutyBreakType)
                .WithMany(gdbt => gdbt.GuardDutyBreaks)
                .HasForeignKey(gdb => gdb.TypeId);

            // GuardDutyBreakType
            modelBuilder.Entity<GuardDutyBreakType>()
                .HasKey(gdbt => gdbt.TypeId);

            modelBuilder.Entity<GuardDutyBreakType>()
                .HasMany(gdbt => gdbt.GuardDutyBreaks)
                .WithOne(gdb => gdb.GuardDutyBreakType)
                .HasForeignKey(gdb => gdb.TypeId);

            // UserRole 
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);


            // Role
            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);

            // Permission
            modelBuilder.Entity<Permission>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Permission>()
                .HasOne(p => p.Role)
                .WithMany(r => r.Permissions)
                .HasForeignKey(p => p.RoleId);

            // UserTransactionLog
            modelBuilder.Entity<UserTransactionLog>()
                .HasKey(utl => utl.Id);

            modelBuilder.Entity<UserTransactionLog>()
                .HasOne(utl => utl.User)
                .WithMany(u => u.UserTransactionLogs)
                .HasForeignKey(utl => utl.UserId);

            // UserCommunication
            modelBuilder.Entity<UserCommunication>()
                .HasKey(uc => new { uc.UserId, uc.CommunicationTypeId });

            modelBuilder.Entity<UserCommunication>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCommunications)
                .HasForeignKey(uc => uc.UserId)
                .HasPrincipalKey(u => u.Id);

            modelBuilder.Entity<UserCommunication>()
                .HasOne(uc => uc.CommunicationType)
                .WithMany(ct => ct.UserCommunications)
                .HasForeignKey(uc => uc.CommunicationTypeId);

            // CommunicationType
            modelBuilder.Entity<CommunicationType>()
                .HasKey(ct => ct.Id);

            modelBuilder.Entity<CommunicationType>()
                .HasMany(ct => ct.UserCommunications)
                .WithOne(uc => uc.CommunicationType)
                .HasForeignKey(uc => uc.CommunicationTypeId);

            // UserIsInTeamRelation
            modelBuilder.Entity<UserIsInTeamRelation>()
                .HasKey(ut => new { ut.UserId, ut.TeamId });

            modelBuilder.Entity<UserIsInTeamRelation>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserIsInTeamRelations)
                .HasForeignKey(ut => ut.UserId);

            modelBuilder.Entity<UserIsInTeamRelation>()
                .HasOne(ut => ut.Team)
                .WithMany(t => t.UserIsInTeamRelations)
                .HasForeignKey(ut => ut.TeamId);

            // Team
            modelBuilder.Entity<Team>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Team>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.TeamTransactionLogs)
                .WithOne(ttl => ttl.Team)
                .HasForeignKey(ttl => ttl.TeamId);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.UserIsInTeamRelations)
                .WithOne(uitr => uitr.Team)
                .HasForeignKey(uitr => uitr.TeamId);

            // TeamTransactionLog
            modelBuilder.Entity<TeamTransactionLog>()
                .HasKey(ttl => ttl.Id);

            modelBuilder.Entity<TeamTransactionLog>()
                .HasOne(ttl => ttl.Team)
                .WithMany(t => t.TeamTransactionLogs)
                .HasForeignKey(ttl => ttl.TeamId);
        }
    }
}

