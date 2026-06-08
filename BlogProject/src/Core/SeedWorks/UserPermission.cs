using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlogProject.Core.SeedWorks
{
    public static class UserPermission
    {
        public static class Dashboard
        {
            [Description("View Dashboard")]
            public const string View = "Permission.Dashboard.View";
        }

        public static class Roles
        {
            [Description("View Roles")]
            public const string View = "Permission.Roles.View";

            [Description("Create Roles")]
            public const string Create = "Permission.Roles.Create";

            [Description("Edit Roles")]
            public const string Edit = "Permission.Roles.Edit";

            [Description("Delete Roles")]
            public const string Delete = "Permission.Roles.Delete";
        }

        public static class Users
        {
            [Description("View Users")]
            public const string View = "Permission.Users.View";

            [Description("Create Users")]
            public const string Create = "Permission.Users.Create";

            [Description("Edit Users")]
            public const string Edit = "Permission.Users.Edit";

            [Description("Delete Users")]
            public const string Delete = "Permission.Users.Delete";
        }

        public static class Posts
        {
            [Description("View Posts")]
            public const string View = "Permission.Posts.View";

            [Description("Create Posts")]
            public const string Create = "Permission.Posts.Create";

            [Description("Edit Posts")]
            public const string Edit = "Permission.Posts.Edit";

            [Description("Delete Posts")]
            public const string Delete = "Permission.Posts.Delete";
        }
    }
}
