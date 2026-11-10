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
        TodoItem getItemByID(int id);
        List<TodoItem> getItemsList();
        TodoItem addItem(TodoItem item);
    }
}
