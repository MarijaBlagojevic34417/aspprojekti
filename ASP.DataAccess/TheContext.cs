using ASP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ASP.DataAccess
{
    public class TheContext : DbContext

    {
        private readonly string _connectionString;
        public TheContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TheContext()
        {
            _connectionString = "Data Source=MACA;Initial Catalog=recepti;Integrated Security=True;Trust Server Certificate=True";
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


            modelBuilder.Entity<RecipeCategory>().HasKey(x => new { x.IdCategory, x.IdRecipe });
            modelBuilder.Entity<RecipeFood>().HasKey(x => new { x.IdRecipe, x.IdFood });
            modelBuilder.Entity<UserRecipeReaction>().HasKey(x => new { x.IdRecipe, x.IdReaction, x.IdUser });
            modelBuilder.Entity<UserCommentReaction>().HasKey(x => new { x.IdComment, x.IdReaction, x.IdUser });
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RecipeFood> RecipeFoods { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<UserCommentReaction> UserCommentReactions { get; set; }
        public DbSet<UserRecipeReaction> UserRecipeReactions { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }





    }
}
