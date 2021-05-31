using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingDomain.Models;

namespace SEDC.TimeTrackingServices.Interfaces
{
    public interface IUserService<T> where T : Users
    {
        void ChangePassword(int userId, string oldPassword, string newPassword);
        void ChangeFirstName(int userId, string newFirstName);
        void ChangeLastName(int userId, string newLastName);
        void DeactivateAccount(int userId);
        void AddUser(T users);
        void LogIn();
        void ShowMainMenu();
        void ShowActivities();
        void UserStatistics();
        void UserOptions();
        void AccountManagement();
        void BackOption();
        void AddingReading(int userId);
        void AddingHobbies(int userId);
        void AddingWorking(int userId);
        void AddingExercising(int userId);
        void Global(int userId);
    }
}
