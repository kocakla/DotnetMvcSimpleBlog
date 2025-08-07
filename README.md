# DotnetMvcSimpleBlog

**DotnetMvcSimpleBlog** is a basic blog management system built with ASP.NET MVC. It allows administrators to create, update, and delete blog posts through a simple admin panel, while users can browse and view blog posts on the public-facing pages.

---

## 🔧 Technologies Used

- ASP.NET MVC
- Entity Framework
- SQL Server
- Bootstrap
- HTML & CSS

---

## ✨ Features

- Admin login and secure panel
- User registration and login system (using ASP.NET Identity)
- Role-based authorization (admin vs. regular users)
- Clean and organized structure following MVC architecture
- Create / Read / Update / Delete (CRUD) operations for blog posts
- Public view for listing and reading blog posts
- Responsive design with Bootstrap
- Simple and clean layout for both admin and users

---

## 🚀 Getting Started

To run this project on your local machine:

1. Clone the repository:
   ```bash
   git clone https://github.com/kocakla/DotnetMvcSimpleBlog.git
2. Open the solution in Visual Studio.
3. Update the database connection string in appsettings.json to match your local SQL Server instance.
4. Open Package Manager Console and run the following commands:
   Add-Migration InitialCreate
   Update-Database
   Run without debugging

---

## 🎨 UI Templates & Credits

This project uses the following UI templates:

- **Admin Panel**: Based on [AdminLTE](https://startbootstrap.com/theme/sb-admin-2)
  SB Admin 2 is a free, open source, Bootstrap 4 based admin theme perfect for quickly creating dashboards and web applications. It's modern design style with subtle shadows and a card-based layout could be described as flat material, and is inspired by the principles of material design along with a simple, attractive color system.
- **Public Blog View**: Inspired by [Start Bootstrap - Clean Blog](https://startbootstrap.com/theme/clean-blog)
  Clean blog is a carefully styled Bootstrap blog theme that is perfect for personal or company blogs. This theme features four HTML pages including a blog index, an about page, a sample post, and a contact page.

All templates have been customized for the purpose of this project.

