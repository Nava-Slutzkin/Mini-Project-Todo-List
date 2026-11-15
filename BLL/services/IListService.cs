using DAL.Data;
using System.Collections.Generic;

namespace BLL.services
{
    public interface IListService
    {
        TodoItem AddItem(TodoItem item);
        TodoItem? GetItemByID(int id);
        List<TodoItem> GetItemsList();
        List<TodoItem> GetItemsList(int userId);
    }
}