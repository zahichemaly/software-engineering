using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class AdminUser : BaseUser
    {
        public AdminUser(int id, string firstName, string lastName, DateTime dateOfBirth, Status status)
            : base(id, firstName, lastName, dateOfBirth, status)
        {
            // Additional initialization for AdminUser if needed
        }

        // Method to update a permanent banner
        public void UpdatePermanentBanner(PermanentBanner banner, string newName)
        {
            // Implement logic to update the permanent banner
            banner.Name = newName;
            Console.WriteLine($"Permanent banner updated: {newName}");
        }

        // Method to add or update an exclusive banner
        public void AddOrUpdateExclusiveBanner(List<ExclusiveBanner> exclusiveBanners, ExclusiveBanner newBanner)
        {
            // Implement logic to add or update the exclusive banner
            var existingBanner = exclusiveBanners.Find(b => b.ID == newBanner.ID);
            if (existingBanner != null)
            {
                // Update an existing banner
                existingBanner.Name = newBanner.Name;
                existingBanner.StartDate = newBanner.StartDate;
                existingBanner.EndDate = newBanner.EndDate;
                existingBanner.Items = newBanner.Items;
                existingBanner.Cost = newBanner.Cost;
                Console.WriteLine($"Exclusive banner updated: {newBanner.Name}");
            }
            else
            {
                // Add a new banner
                exclusiveBanners.Add(newBanner);
                Console.WriteLine($"Exclusive banner added: {newBanner.Name}");
            }
        }

        // Method to delete an exclusive banner
        public void DeleteExclusiveBanner(List<ExclusiveBanner> exclusiveBanners, int bannerId)
        {
            // Implement logic to delete the exclusive banner
            var bannerToRemove = exclusiveBanners.Find(b => b.ID == bannerId);
            if (bannerToRemove != null)
            {
                exclusiveBanners.Remove(bannerToRemove);
                Console.WriteLine($"Exclusive banner deleted: {bannerToRemove.Name}");
            }
            else
            {
                Console.WriteLine($"Exclusive banner with ID {bannerId} not found.");
            }
        }

        // Method to add or remove users from the system
        public void ManageUsers(List<BaseUser> users, bool addUser, BaseUser userToAddOrRemove)
        {
            if (addUser)
            {
                users.Add(userToAddOrRemove); // Add user to the system
                Console.WriteLine($"User added: {userToAddOrRemove.GetFullName()}");
            }
            else
            {
                users.Remove(userToAddOrRemove); // Remove user from the system
                Console.WriteLine($"User removed: {userToAddOrRemove.GetFullName()}");
            }
        }

        // Method to update the system version
        public void UpdateSystemVersion(Version currentVersion, string newVersionNumber)
        {
            // Implement logic to update the system version
            currentVersion.VersionNumber = newVersionNumber;
            Console.WriteLine($"System version updated to: {newVersionNumber}");
        }
    
}
}