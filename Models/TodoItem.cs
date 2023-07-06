using Microsoft.AspNetCore.Datasync.EFCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My.Datasync.Server.Db
{
    /// <summary>
    /// The fields in this class must match the fields in Models/TodoItem.cs
    /// for the TodoApp.Data project.
    /// </summary>
    public class TodoItem : EntityTableData
    {
        [Required, MinLength(1)]
        public string Title { get; set; } = "";

        public bool IsComplete { get; set; }

        //public virtual ICollection<TodoItemList> Items { get; set; }
    }
    
    public class TodoItemList : EntityTableData
    {
        public string TodoItemId { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public AllTodoItems TodoItem { get; set; }
    }

    public class AllTodoItems : EntityTableData
    {
        [Required, MinLength(1)]
        public string Title { get; set; } = "";

        public bool IsComplete { get; set; }
        public Guid AutoId { get; set; }

        // public virtual ICollection<TodoItemList> Items { get; set; }
        public virtual ICollection<qCost> QuoteLines { get; set; }
    }

    [Table("qCost", Schema = "tbl_Rep")]
    public class qCost : EntityTableData
    {
        [Required, MinLength(1)]
        public string Title { get; set; } = "";

        public bool IsComplete { get; set; }

        public Guid TodoItemAutoId { get; set; }

        //[ForeignKey("TodoItemAutoId")]
        //[NotMapped]
        //public AllTodoItems AllTodoItems { get; set; }
    }
}