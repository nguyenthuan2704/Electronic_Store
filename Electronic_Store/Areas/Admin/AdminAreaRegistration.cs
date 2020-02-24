using System.Web.Mvc;

namespace Electronic_Store.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Admin_default",
                url: "Admin/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Charts",
                url: "Charts/{id}",
                defaults: new { controller = "Home", action = "Chart", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );
            //Product Management
            context.MapRoute(
                name: "Product",
                url: "Product/{id}",
                defaults: new { controller = "Home", action = "Product", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Add_Product",
                url: "Add_Product/{id}",
                defaults: new { controller = "Home", action = "Add_Product", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Delete_Product",
                url: "Delete_Product/{id}",
                defaults: new { controller = "Home", action = "Delete_Product", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Update_Product",
                url: "Update_Product/{id}",
                defaults: new { controller = "Home", action = "Update_Product", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );
            //Category Management
            context.MapRoute(
                name: "Category",
                url: "Category/{id}",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Add_Category",
                url: "Add_Category/{id}",
                defaults: new { controller = "Category", action = "Add_Category", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Update_Category",
                url: "Update_Category/{id}",
                defaults: new { controller = "Category", action = "Update_Category", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Delete_Category",
                url: "Delete_Category/{id}",
                defaults: new { controller = "Category", action = "Delete_Category", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            //Contact Management
            context.MapRoute(
                name: "Contact",
                url: "Contact/{id}",
                defaults: new { controller = "Contact", action = "Contact", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Delete_Contact",
                url: "Delete_Contact/{id}",
                defaults: new { controller = "Contact", action = "Delete_Contact", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Detail_Contact",
                url: "Detail_Contact/{id}",
                defaults: new { controller = "Contact", action = "Detail_Contact", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Reply_Contact",
                url: "Reply_Contact/{id}",
                defaults: new { controller = "Contact", action = "Reply_Contact", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            //User Management
            context.MapRoute(
                name: "User",
                url: "User/{id}",
                defaults: new { controller = "User", action = "Users", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Add_User",
                url: "Add_User/{id}",
                defaults: new { controller = "User", action = "Add_User", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Delete_User",
                url: "Delete_User/{id}",
                defaults: new { controller = "User", action = "Delete_User", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            //Customer Management
            context.MapRoute(
                name: "Customer",
                url: "Customer/{id}",
                defaults: new { controller = "Customer", action = "Customer", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                name: "Delete_Customer",
                url: "Delete_Customer/{id}",
                defaults: new { controller = "Customer", action = "Delete_Customer", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Areas.Admin.Controllers" }
            );

            //context.MapRoute(
            //    "Admin_default",
            //    "Admin/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional },
            //    new[] { "Electronic_Store.Areas.Admin.Controllers" }
            //);
        }
    }
}