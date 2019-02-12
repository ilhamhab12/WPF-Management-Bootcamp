using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces;
using Microservice.Common.Interfaces.Master;
using System.Windows.Forms;

namespace Microservice.BussinessLogic.Services.Master
{
    public class LevelService : ILevelService
    {
        bool status = false;
        ILevelRepository _levelRepository = new LevelRepository();
        public bool Delete(int? id)
        {
            if (_levelRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _levelRepository.Delete(id);
            }
            return status;
        }

        public List<Level> Get()
        {
            return _levelRepository.Get();
        }

        public Level Get(int? id)
        {
            return _levelRepository.Get(id);
        }

        public bool Insert(LevelParam levelParam)
        {
            if (levelParam.Name.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _levelRepository.Insert(levelParam);
            }
            return status;
        }

        public List<Level> Search(string keywoard, string category)
        {
            return _levelRepository.Search(keywoard, category);
        }

        public bool Update(int? id, LevelParam levelParam)
        {
            if (_levelRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (levelParam.Name.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _levelRepository.Update(id, levelParam);
                }
            }
            return status;
        }
    }
}
