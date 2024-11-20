using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace С1App.Data
{
	public class C1DbContext:DbContext
	{
		public void AppContext()
		{
			if(!Database.CanConnect())
			{
				Database.EnsureDeleted();
				Database.EnsureCreated();
				var db = new C1DbContext();
					db.Users.Add(new User
				{
					Name = "Vitalia",
					Login = "Root",
					Password = "Root",
					Adress = "Красный проспект",
					Role = "Admin"
				});
				db.SaveChanges();
			}
		}
		public DbSet<User> Users => Set<User>();
		public DbSet<CategoriaItem> CategoriaItems => Set<CategoriaItem>();
		public DbSet<Item> Items => Set<Item>();
		public DbSet<Zakaz> Zakazs => Set<Zakaz>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=C1;Trusted_connection=True;");
		}
		public void addUser(User user)
		{
			var db = new C1DbContext();
			db.Users.Add(user);
			db.SaveChanges();
		}
		public User authorize(string login, string password)
		{
			var db = new C1DbContext();
			User user = db.Users.ToList()
				.Find(x => x.Login == login && x.Password==password);
			return user;
		}
		public List<Item> getItems()
		{
			return new C1DbContext().Items.ToList();
		}

		public void addCatt(string name)
		{
			var db = new C1DbContext();
			db.CategoriaItems.Add(new CategoriaItem { Name = name });
			db.SaveChanges();
		}

		public void addItem(Item item)
		{
			var db = new C1DbContext();
			db.Items.Add(item);
			db.SaveChanges();
		}
		public List<string> getCategories()
		{
			List<string> categ = new List<string>();
			var db = new C1DbContext();
			foreach(CategoriaItem a in db.CategoriaItems.ToList())
			{
				categ.Add(a.Name);
			}
			return categ;
		}

	}
}
