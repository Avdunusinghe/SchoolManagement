﻿using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Configurations;
using SchoolManagement.Data.Configurations.Account;
using SchoolManagement.Data.Configurations.Master;
using SchoolManagement.Model;
using SchoolManagement.Util.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SchoolManagement.Data.Data
{
    public class SchoolManagementContext : DbContext
    {
        private TenantSchool tenantSchool;
        public SchoolManagementContext()
        {



        }



        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options, ITenantProvider tenantProvider) : base(options)
        {
            GetTenant(tenantProvider).Wait();
        }
        private async Task GetTenant(ITenantProvider tenantProvider)
        {
            tenantSchool = await tenantProvider.GetTenant();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {  
            if (tenantSchool != null)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(tenantSchool.ConnectionString);
            }



            else if (tenantSchool == null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=itp-2021.database.windows.net;Database=SchoolManagement;User Id=itp;Password=Pass@1231qaz;");
            }

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Account Database Entities Configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());



            //Master Database Entities Configurations
            // modelBuilder.ApplyConfiguration(new AcademicLevelAssessmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicLevelConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicYearConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new ClassNameConfiguration());
            modelBuilder.ApplyConfiguration(new ClassSubjectTeacherConfiguration());
            modelBuilder.ApplyConfiguration(new ClassTeacherConfiguration());
            modelBuilder.ApplyConfiguration(new HeadOfDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentClassConfiguration());
            modelBuilder.ApplyConfiguration(new StudentClassSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectStreamConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectTeacherConfiguration());



            //Lesson Database Entities Configurations
            modelBuilder.ApplyConfiguration(new EssayQuestionAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new EssayStudentAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new LessonAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new LessonAssignmentSubmissionConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new MCQQuestionAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new MCQQuestionStudentAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new StudentLessonConfiguration());
            modelBuilder.ApplyConfiguration(new StudentLessonTopicConfiguration());
            modelBuilder.ApplyConfiguration(new StudentLessonTopicContentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentMCQQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectAcademicLevelConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new TopicContentConfiguration());
        }



        //Account Database Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



        //Master Database Entities
        public DbSet<AcademicLevel> AcademicLevels { get; set; }
        // public DbSet<AcademicLevelAssessmentType> AcademicLevelAssessmentTypes { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassName> ClassNames { get; set; }
        public DbSet<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<HeadOfDepartment> HeadOfDepartments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<StudentClassSubject> StudentClassSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectStream> SubjectStreams { get; set; }
        public DbSet<SubjectAcademicLevel> SubjectAcademicLevels { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }




        //Lesson Database Entities



        public DbSet<EssayQuestionAnswer> EssayQuestionAnswers { get; set; }
        public DbSet<EssayStudentAnswer> EssayStudentAnswers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonAssignment> LessonAssignments { get; set; }
        public DbSet<LessonAssignmentSubmission> LessonAssignmentSubmissions { get; set; }
        public DbSet<MCQQuestionAnswer> MCQQuestionAnswers { get; set; }
        public DbSet<MCQQuestionStudentAnswer> MCQQuestionStudentAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<StudentLessonTopic> StudentLessonTopics { get; set; }
        public DbSet<StudentLessonTopicContent> StudentLessonTopicContent { get; set; }
        public DbSet<StudentMCQQuestion> StudentMCQQuestions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicContent> TopicContents { get; set; }
        
    }
}