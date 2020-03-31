/*Database Class
 * This class is meant to handle all database instantiation, singleton design,
 * private functions and API for front end.
 * One object of this class is called when its launched and is interacted with throughout the whole app
 *
 * Database is designed based off tutorial provided by Microsoft at https://docs.microsoft.com/en-us/xamarin/get-started/tutorials/local-database/?tabs=vswin
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace Fit.Natic
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);


            /*using the DailyTarget class as the object type is tentative,
             * may need to create a Metrics model or Performance model that
             * combines some features of the dailytarget and performance and excludes others
             * (eg: we dont need to store a list of meals from the daily target for every single day,
             *  just store the calories consumed and calorie deficit or calorie target)
             */
            _database.CreateTableAsync<DailyTarget>().Wait();
        }

        public Task<List<DailyTarget>> GetDailyTargetsAsync()
        {
            return _database.Table<DailyTarget>().ToListAsync();
        }

        public Task<int> SaveTargetAsync(DailyTarget entry)
        {
            return _database.InsertAsync(entry);
        }
    }

}
