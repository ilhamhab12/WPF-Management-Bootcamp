using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Context;
using System.Windows.Forms;

namespace Microservice.Common.Interfaces.Master
{
    public class LevelRepository : ILevelRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Level level = new Level();
        public bool Delete(int? id)
        {
            var result = 0;
            var level = Get(id);
            level.IsDelete = true;
            level.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<Level> Get()
        {
            return _context.Levels.Where(x => x.IsDelete == false).ToList();
        }

        public Level Get(int? id)
        {
            return _context.Levels.Find(id);
        }

        public bool Insert(LevelParam LevelParam)
        {
            var result = 0;
            level.Name = LevelParam.Name;
            level.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Levels.Add(level);
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

        public List<Level> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.Levels.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Levels.Where(x => (x.IsDelete == false) && (x.Name.Contains(keywoard))).ToList();
            }
            //else if (category == "Level")
            //{
            //    return _context.Levels.Where(x => (x.IsDelete == false) && (x.level.Contains(keywoard))).ToList();
            //}
            //else if (category == "Department")
            //{
            //    return _context.Levels.Where(x => (x.IsDelete == false) && (x.departements.Name.Contains(keywoard))).ToList();
            //}
            else
            {
                return _context.Levels.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, LevelParam LevelParam)
        {
            var result = 0;
            var level = Get(id);
            level.Name = LevelParam.Name;
            level.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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
    }
}
