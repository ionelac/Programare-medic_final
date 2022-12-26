using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
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
    }
}
