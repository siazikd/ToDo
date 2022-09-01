using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        public async Task<ToDoItem> AddToDoItemAsync(ToDoItem item)
        {
            using(var db = new AppDbContext())
            {
                try
                {
                    var result = await db.ToDoItems.AddAsync(item);
                    await db.SaveChangesAsync();
                    return result.Entity;

                }catch(Exception) {
                    return null;
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

        public async Task<ToDoItem> UpdateToDoItemAsync(ToDoItem item)
        {
            using(var db = new AppDbContext())
            {
                try
                {
                    var result = db.ToDoItems.Update(item);
                    await db.SaveChangesAsync();

                    return result.Entity;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
