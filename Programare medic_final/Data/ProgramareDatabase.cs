using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Programare_medic_final.Models;

namespace Programare_medic_final.Data
{
    public class ProgramareDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ProgramareDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Programare>().Wait();
            _database.CreateTableAsync<Serviciu>().Wait();
            _database.CreateTableAsync<ListServiciu>().Wait();
        }

        //--------------------------------------------------------------
        public Task<int> SaveServiciuAsync(Serviciu serviciu)
        {
            if (serviciu.ID != 0)
            {
                return _database.UpdateAsync(serviciu);
            }
            else
            {
                return _database.InsertAsync(serviciu);
            }
        }
        public Task<int> DeleteServiciuAsync(Serviciu serviciu)
        {
            return _database.DeleteAsync(serviciu);
        }
        public Task<List<Serviciu>> GetServiciiAsync()
        {
            return _database.Table<Serviciu>().ToListAsync();
        }

        //-----------------------------------------------------------
        
        public Task<List<Programare>> GetProgramariAsync()
        {
            return _database.Table<Programare>().ToListAsync();
        }
        public Task<Programare> GetProgramareAsync(int id)
        {
            return _database.Table<Programare>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        
        public Task<int> SaveProgramareAsync(Programare slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteProgramareAsync(Programare slist)
        {
            return _database.DeleteAsync(slist);
        }

        //---------------------------------------------------------------
        public Task<int> SaveListServiciuAsync(ListServiciu lists)
        {
            if (lists.ID != 0)
            {
                return _database.UpdateAsync(lists);
            }
            else
            {
                return _database.InsertAsync(lists);
            }
        }
        public Task<List<Serviciu>> GetListServiciiAsync(int programareID)
        {
            return _database.QueryAsync<Serviciu>(
            "select S.ID, S.Description from Serviciu S"
            + " inner join ListServiciu LS"
            + " on S.ID = LS.ServiciuID where LS.ProgramareID = ?",
            programareID);
        }

    }
}
