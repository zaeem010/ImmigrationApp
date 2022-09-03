using ImmigrationApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImmigrationApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<Country> Country { get; set; }
        //Jobs Meta Data
        public DbSet<JobMainCategory> JobMainCategory { get; set; }
        public DbSet<JobSubCategory> JobSubCategory { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<JobSchedule> JobSchedule { get; set; }
        public DbSet<SupplementalPay> SupplementalPay { get; set; }
        public DbSet<BenefitOffered> BenefitOffered { get; set; }
        //Jobs
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobTypeChild> JobTypeChild { get; set; }
        public DbSet<JobScheduleChild> JobScheduleChild { get; set; }
        public DbSet<SupplementalPayChild> SupplementalPayChild { get; set; }
        public DbSet<BenefitOfferedChild> BenefitOfferedChild { get; set; }
        public DbSet<JobEmailChild> JobEmailChild { get; set; }
        //Resume
        public DbSet<CustomResume> CustomResume { get; set; }
        public DbSet<ResumeSkillChild> ResumeSkillChild { get; set; }
        public DbSet<ResumeLanguageChild> ResumeLanguageChild { get; set; }
        public DbSet<ResumeLinkChild> ResumeLinkChild { get; set; }
        public DbSet<ResumeEducation> ResumeEducation { get; set; }
        public DbSet<ResumeExperience> ResumeExperience { get; set; }
        //Resume MetaData
        public DbSet<Skill> Skill { get; set; }
    }
}
