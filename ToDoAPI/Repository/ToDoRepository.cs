using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        public async Task<bool> AddToDoItemAsync(ToDoItem item)
        {
            using(var db = new AppDbContext())
            {
                try
                {
                    var result = await db.ToDoItems.AddAsync(item);

                    return await db.SaveChangesAsync() >= 1;

                }catch(Exception) {
                    return false;
                }
               
            }   
        }

        public async Task<bool> DeleteToDoItemAsync(int id)
        {
            using(var db = new AppDbContext())
            {
                try
                {
                    var result = await GetToDoItemByIdAsync(id);
                    db.Remove(result);
                    return await db.SaveChangesAsync() >= 1; 
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            using(var db = new AppDbContext())
            {
                return await db.ToDoItems.FirstOrDefaultAsync(item => item.Id == id);
            }
        }

        public async Task<IEnumerable<ToDoItem>> GetToDoItemsAsync()
        {
            using(var db = new AppDbContext())
            {
                return await db.ToDoItems.ToListAsync();
            }
        }

        public async Task<bool> UpdateToDoItemAsync(ToDoItem item)
        {
            using(var db = new AppDbContext())
            {
                try
                {
                    db.ToDoItems.Update(item);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
