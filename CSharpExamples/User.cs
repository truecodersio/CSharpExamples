using System;
namespace CSharpExamples
{
    public enum UserRole
    {
        Admin, Contributor, Viewer
    }

    public class User
    {
        public string Name { get; set; }
        public UserRole Role { get; internal set; }

        public void ChangeRole(UserRole role)
        {
            if (this.Role < role)
            {
                this.Role = role;
            }
        }
    }
}
