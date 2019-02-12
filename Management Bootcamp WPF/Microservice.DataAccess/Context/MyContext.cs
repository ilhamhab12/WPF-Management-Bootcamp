﻿using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("bootcampManagement2") {}

        public DbSet<Placement> Placements { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ErrorBank> ErrorBanks { get; set; }
        public DbSet<WeeklyScore> WeeklyScores { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<DailyScore> DailyScores { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<SkillStudent> SkillStudents { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<University> Universitys { get; set; }
        public DbSet<HistoryPlacement> HistoryPlacements { get; set; }
        public DbSet<HistoryEducation> HistoryEducations { get; set; }
        public DbSet<Locker> Lockers { get; set; }
        public DbSet<Level> Levels { get; set; }


    }
}
