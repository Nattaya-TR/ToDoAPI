using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models.Data;

namespace TodoApi.Models.Data
{
	public class TodoMusicContext : DbContext
	{
		public TodoMusicContext(DbContextOptions<TodoMusicContext> options)
			: base(options)
		{
		}

		public DbSet<TodoMusic> TodoMusics { get; set; }
	}
}
