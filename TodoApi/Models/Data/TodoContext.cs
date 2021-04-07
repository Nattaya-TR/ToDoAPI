using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models.Data;

namespace TodoApi.Models.Data
{ 
	public class TodoContext : DbContext
	{
		public TodoContext(DbContextOptions<TodoContext> options)
			: base(options)
		{
		}

		public DbSet<TodoItem> TodoItems { get; set; }
	}
}