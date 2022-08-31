using ToDoAPI.Models;

namespace ToDoAPI.Repository
{
    public interface IToDoRepository
    {
         Task<IEnumerable<ToDoItem>> GetToDoItemsAsync();
         Task<ToDoItem> GetToDoItemByIdAsync(int id);
         Task<bool> AddToDoItemAsync(ToDoItem item);

         Task<bool> UpdateToDoItemAsync(ToDoItem item );
         Task<bool> DeleteToDoItemAsync(int id);



    }
}
