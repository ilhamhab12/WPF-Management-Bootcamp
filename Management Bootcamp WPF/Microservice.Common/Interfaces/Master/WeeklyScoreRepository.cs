﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Context;
using System.Windows.Forms;

namespace Microservice.Common.Interfaces.Master
{
    public class WeeklyScoreRepository : IWeeklyScoreRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        WeeklyScore weeklyScore = new WeeklyScore();
        public bool Delete(int? id)
        {
            var result = 0;
            var weeklyScore = Get(id);
            weeklyScore.IsDelete = true;
            weeklyScore.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<WeeklyScore> Get()
        {
            return _context.WeeklyScores.Where(x => x.IsDelete == false).ToList();
        }

        public WeeklyScore Get(int? id)
        {
            return _context.WeeklyScores.Find(id);
        }

        public bool Insert(WeeklyScoreParam WeeklyScoreParam)
        {
            var result = 0;
            weeklyScore.Name = WeeklyScoreParam.Name;
            weeklyScore.Date = DateTimeOffset.Now.LocalDateTime;
            weeklyScore.Score1 = WeeklyScoreParam.Score1;
            weeklyScore.Score2 = WeeklyScoreParam.Score2;
            weeklyScore.Score3 = WeeklyScoreParam.Score3;
            weeklyScore.Score4 = WeeklyScoreParam.Score4;
            weeklyScore.Score5 = WeeklyScoreParam.Score5;
            weeklyScore.students = _context.Students.Find(Convert.ToInt16(WeeklyScoreParam.students));
            weeklyScore.employees = _context.Employees.Find(Convert.ToInt16(WeeklyScoreParam.employees));
            weeklyScore.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.WeeklyScores.Add(weeklyScore);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Insert Successfully");
            }
            else
            {
                MessageBox.Show("Insert Failed");
            }
            return status;
        }

        public List<WeeklyScore> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                return _context.WeeklyScores.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Name")
            {
                return _context.WeeklyScores.Where(x => (x.IsDelete == false) && (x.Name.Contains(keyword))).ToList();
            }
            else if (category == "Student Name")
            {
                return _context.WeeklyScores.Where(x => (x.IsDelete == false) && (x.students.FirstName.Contains(keyword))).ToList();
            }
            else if (category == "Employee")
            {
                return _context.WeeklyScores.Where(x => (x.IsDelete == false) && (x.employees.FirstName.Contains(keyword))).ToList();
            }
            else
            {
                return _context.WeeklyScores.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, WeeklyScoreParam WeeklyScoreParam)
        {
            var result = 0;
            var weeklyScore = Get(id);
            weeklyScore.Name = WeeklyScoreParam.Name;
            weeklyScore.Date = DateTimeOffset.Now.LocalDateTime;
            weeklyScore.Score1 = WeeklyScoreParam.Score1;
            weeklyScore.Score2 = WeeklyScoreParam.Score2;
            weeklyScore.Score3 = WeeklyScoreParam.Score3;
            weeklyScore.Score4 = WeeklyScoreParam.Score4;
            weeklyScore.Score5 = WeeklyScoreParam.Score5;
            weeklyScore.students = _context.Students.Find(Convert.ToInt16(WeeklyScoreParam.students));
            weeklyScore.employees = _context.Employees.Find(Convert.ToInt16(WeeklyScoreParam.employees));
            weeklyScore.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Update Failed");
            }
            return status;
        }

        public List<WeeklyScore> GetStudent(int? id)
        {
            return _context.WeeklyScores.Where(x => x.IsDelete == false && x.students.Id == id).ToList();
        }
    }
}
