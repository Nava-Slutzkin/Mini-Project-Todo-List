using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly AppDB _context;
        public ListRepository(AppDB context)
        {
            _context = context;
        }
        public TodoItem AddItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return item;
        }
        public TodoItem GetItemByID(int id)
        {
            return _context.TodoItems.FirstOrDefault(i => i.Id == id);
        }
        public List<TodoItem> GetItemsList()
        {
            return _context.TodoItems.ToList();
        }

        public object? GetItemsList(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
