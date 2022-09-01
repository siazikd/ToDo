using ToDoAPI.Models;

namespace ToDoAPI.Repository
{
    public interface IToDoRepository
    {
         Task<IEnumerable<ToDoItem>> GetToDoItemsAsync();
         Task<ToDoItem> GetToDoItemByIdAsync(int id);
         Task<ToDoItem> AddToDoItemAsync(ToDoItem item);

         Task<ToDoItem> UpdateToDoItemAsync(ToDoItem item );
         Task<bool> DeleteToDoItemAsync(int id);



    }
}
