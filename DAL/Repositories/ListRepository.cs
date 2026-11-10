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
        public TodoItem addItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return item;
        }
        public TodoItem getItemByID(int id)
        {
            return _context.TodoItems.FirstOrDefault(i => i.Id == id);
        }
        public List<TodoItem> getItemsList()
        {
            return _context.TodoItems.ToList();
        }

    }
}
