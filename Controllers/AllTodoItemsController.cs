using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;
using My.Datasync.Server.Db;

namespace My.Datasync.Server.Controllers
{
    [Route("tables/alltodoitems")]
    public class AllTodoItemsController : TableController<AllTodoItems>
    {
        public AllTodoItemsController(AppDbContext context)
            : base(new EntityTableRepository<AllTodoItems>(context))
        {
        }
    }
}