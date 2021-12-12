using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HRM.Models
{
    public partial class HRMContext : DbContext
    {

        public HRMContext(DbContextOptions<HRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Assessment> Assessments { get; set; }
        public virtual DbSet<AssessmentType> AssessmentTypes { get; set; }
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<CalendarDetail> CalendarDetails { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LeaveApplication> LeaveApplications { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Recruitment> Recruitments { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<SalaryDetail> SalaryDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HRM;Username=postgres;Password=sang1411");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_Vietnam.1258");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Account1)
                    .HasName("pk_account");

                entity.ToTable("account");

                entity.Property(e => e.Account1).HasColumnName("account");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_employee");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasColumnType("timestamp with time zone");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.CreateAt })
                    .HasName("pk_assessment");

                entity.ToTable("assessment");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.AssessmentType).HasColumnName("assessment_type");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.SrcFile)
                    .HasColumnType("json")
                    .HasColumnName("src_file");

                entity.HasOne(d => d.AssessmentTypeNavigation)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.AssessmentType)
                    .HasConstraintName("fk_assessment_type_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee");
            });

            modelBuilder.Entity<AssessmentType>(entity =>
            {
                entity.ToTable("assessment_type");

                entity.Property(e => e.AssessmentTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("assessment_type_id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.ToTable("calendar");

                entity.Property(e => e.CalendarId).HasColumnName("calendar_id");

                entity.Property(e => e.EndAt)
                    .HasColumnType("date")
                    .HasColumnName("end_at");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.StartAt)
                    .HasColumnType("date")
                    .HasColumnName("start_at");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<CalendarDetail>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.CalendarId, e.Shift, e.Day })
                    .HasName("pk_calendar_detail");

                entity.ToTable("calendar_detail");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.CalendarId).HasColumnName("calendar_id");

                entity.Property(e => e.Shift).HasColumnName("shift");

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.ActualEnd)
                    .HasColumnType("time without time zone")
                    .HasColumnName("actual_end");

                entity.Property(e => e.ActualStart)
                    .HasColumnType("time without time zone")
                    .HasColumnName("actual_start");

                entity.Property(e => e.End)
                    .HasColumnType("time without time zone")
                    .HasColumnName("end");

                entity.Property(e => e.IsAttendance).HasColumnName("is_attendance");

                entity.Property(e => e.IsLeavePermission).HasColumnName("is_leave_permission");

                entity.Property(e => e.IsOvertime).HasColumnName("is_overtime");

                entity.Property(e => e.IsWork).HasColumnName("is_work");

                entity.Property(e => e.Start)
                    .HasColumnType("time without time zone")
                    .HasColumnName("start");

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.CalendarDetails)
                    .HasForeignKey(d => d.CalendarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_calendar_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CalendarDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_id");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 100000L, null, null);

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 100000L, null, null);

                entity.Property(e => e.ApproverInternship).HasColumnName("approver_internship");

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.Birth)
                    .HasColumnType("date")
                    .HasColumnName("birth");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsInternship).HasColumnName("is_internship");

                entity.Property(e => e.JoinDate)
                    .HasColumnType("date")
                    .HasColumnName("join_date");

                entity.Property(e => e.JoinInternshipDate)
                    .HasColumnType("date")
                    .HasColumnName("join_internship_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.StateInternship).HasColumnName("state_internship");

                entity.Property(e => e.Wage)
                    .HasColumnType("money")
                    .HasColumnName("wage");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_department");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("fk_position");
            });

            modelBuilder.Entity<LeaveApplication>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.CreateAt })
                    .HasName("pk_leave_application");

                entity.ToTable("leave_application");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.ApprovedAt).HasColumnName("approved_at");

                entity.Property(e => e.Approver).HasColumnName("approver");

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.IsApproved).HasColumnName("is_approved");

                entity.Property(e => e.Reason).HasColumnName("reason");

                entity.Property(e => e.Shift).HasColumnName("shift");

                entity.HasOne(d => d.ApproverNavigation)
                    .WithMany(p => p.LeaveApplicationApproverNavigations)
                    .HasForeignKey(d => d.Approver)
                    .HasConstraintName("fk_approver");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveApplicationEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("notification_pkey");

                entity.ToTable("notification");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("department_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.Department)
                    .WithOne(p => p.Notification)
                    .HasForeignKey<Notification>(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_department");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.PositionId)
                    .HasColumnName("position_id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 100000L, null, null);

                entity.Property(e => e.AverageWage)
                    .HasColumnType("money")
                    .HasColumnName("average_wage");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Recruitment>(entity =>
            {
                entity.ToTable("recruitment");

                entity.Property(e => e.RecruitmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("recruitment_id");

                entity.Property(e => e.AppliedPosition).HasColumnName("applied_position");

                entity.Property(e => e.ApprovedDate)
                    .HasColumnType("date")
                    .HasColumnName("approved_date");

                entity.Property(e => e.Approver).HasColumnName("approver");

                entity.Property(e => e.IsApproved).HasColumnName("is_approved");

                entity.Property(e => e.SrcFile)
                    .HasColumnType("json")
                    .HasColumnName("src_file");

                entity.Property(e => e.SubmissionAt).HasColumnName("submission_at");

                entity.HasOne(d => d.AppliedPositionNavigation)
                    .WithMany(p => p.Recruitments)
                    .HasForeignKey(d => d.AppliedPosition)
                    .HasConstraintName("fk_applied_position");

                entity.HasOne(d => d.ApproverNavigation)
                    .WithMany(p => p.Recruitments)
                    .HasForeignKey(d => d.Approver)
                    .HasConstraintName("fk_approver");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("salary");

                entity.Property(e => e.SalaryId).HasColumnName("salary_id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("create_at");

                entity.Property(e => e.IsPaid).HasColumnName("is_paid");

                entity.Property(e => e.PaidDate).HasColumnName("paid_date");

                entity.Property(e => e.TotalSalary)
                    .HasColumnType("money")
                    .HasColumnName("total_salary");
            });

            modelBuilder.Entity<SalaryDetail>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.SalaryId, e.CreateAt })
                    .HasName("salary_detail_pkey");

                entity.ToTable("salary_detail");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.SalaryId).HasColumnName("salary_id");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Salary)
                    .HasColumnType("money")
                    .HasColumnName("salary");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SalaryDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee");

                entity.HasOne(d => d.SalaryNavigation)
                    .WithMany(p => p.SalaryDetails)
                    .HasForeignKey(d => d.SalaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
