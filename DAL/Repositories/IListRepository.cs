using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IListRepository
    {
        TodoItem GetItemByID(int id);
        List<TodoItem> GetItemsList();
        TodoItem AddItem(TodoItem item);
        object? GetItemsList(int userId);
    }
}
