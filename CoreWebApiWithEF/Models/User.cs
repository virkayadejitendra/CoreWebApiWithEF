using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiWithEF.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Intrests { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        //public ICollection<Photo> Photos { get; set; }
        public List<Blog> Blogs { get; } = new List<Blog>();

    }

    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }


        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlite(@"Data Source=C:\blogging.db");
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
}
       
public class Grade
{
    public int GradeId { get; set; }
    public string GradeName { get; set; }
    public string Section { get; set; }
}
}