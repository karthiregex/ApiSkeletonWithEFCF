using DatingApp.BusinessLayer.Interfaces;
using DatingApp.BusinessLayer.Services;
using DatingApp.BusinessLayer.Services.Repository;
using DatingApp.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using Microsoft.AspNetCore.Identity;

namespace DatingApp.Tests.TestCases
{
    public class FunctionalTests
    {
        /// <summary>
        /// Creating reference Variable and Mocking repository class
        /// </summary>

        private readonly IAdminServices _adminServices;
        private readonly IDateService _dateServices;
        private readonly IUserService _userServices;
        public readonly Mock<IAdminRepository> AdminService = new Mock<IAdminRepository>();
        public readonly Mock<IDateRepository> DateService = new Mock<IDateRepository>();
        public readonly Mock<IUserRepository> UserService = new Mock<IUserRepository>();

        private readonly UserMaster _userMaster;
        private readonly DateDetail _dateDetails;
        private readonly User _user;
        private readonly Profile _profile;
        private List<User> _userList;

        private readonly CreateRoleViewModel _createRoleViewModel;
        private readonly UserRoleViewModel _userRoleViewModel;
        private readonly ChangePasswordViewModel _changePasswordViewModel;
        private readonly EditRoleViewModel _editRoleViewModel;

        private IdentityResult identiyResult;
        private readonly ITestOutputHelper _output;
        private static readonly string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            /// <summary>
            /// Injecting service object into Test class constructor
            /// </summary>
            _dateServices = new DateService(DateService.Object);
            _userServices = new UserService(UserService.Object);

            _createRoleViewModel = new CreateRoleViewModel();
            _adminServices = new AdminServices(AdminService.Object);
            identiyResult = new IdentityResult();
            _output = output;
            _user = new User()
            {
                Email = "Test@gmail.com",
                MobileNumber = 242342345655,
                Password = "Pass@123",
                UserId = 1,
                UserName = "UserTest",
                UserStatus = UserStatus.Active,
                UserType = UserType.Guest
            };

            _profile = new Profile()
            {
                AlternateEmail = "Test@gmail.com",
                FirstName = "UserFname",
                LastName = "UserLname",
                Gender = "Male",
                MobileNumber = 23432342346,
                Occupation = "Business",
                ProfileId = 1
            };

            _createRoleViewModel = new CreateRoleViewModel
            {
                RoleName = "Admin"
            };
            _userRoleViewModel = new UserRoleViewModel
            {
                UserId = "1b232594-4f44-4777-9008-480746341378",
                Email = "umakumarsingh@gmail.com"
            };
            _changePasswordViewModel = new ChangePasswordViewModel
            {
                Name = "Uma",
                Email = "umakumarsingh@iiht.com",
                Password = "Password@123",
                ConfirmPassword = "Password@123"
            };
            _editRoleViewModel = new EditRoleViewModel
            {
                Id = "7f737659-aa03-4633-ad16-4c1ac83cfe98",
                RoleName = "Admin",
            };
        }
        /// <summary>
        /// Add/Create New User using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_CreateNewUser()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                UserService.Setup(service => service.CreateNewUser(_user)).ReturnsAsync(res);
                var result = await _userServices.CreateNewUser(_user);

                //Assertion
                if (result)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Verify User using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_VerifyUser()
        {
            //Arrange
            var res = false;
            string user = "John";
            string passWord = "Admin@123";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                UserService.Setup(service => service.VerifyUser(user, passWord)).ReturnsAsync(_user);
                var result = await _userServices.VerifyUser(user, passWord);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Suspend User using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_SuspendUser()
        {
            //Arrange
            var res = false;
            string user = "John";
            string outCome = string.Empty;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                UserService.Setup(service => service.SuspendUser(user, UserStatus.Active)).ReturnsAsync(outCome);
                var result = await _userServices.SuspendUser(user, UserStatus.Active);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// verify the List Of Members using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_ListOfMembers()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                UserService.Setup(service => service.ListOfMembers()).ReturnsAsync(_userList);
                var result = await _userServices.ListOfMembers();

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Add new Profile using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_AddProfile()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                UserService.Setup(service => service.AddProfile(_profile)).ReturnsAsync(res);
                var result = await _userServices.AddProfile(_profile);

                //Assertion
                if (result)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Change Password using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_ChangePassword()
        {
            //Arrange
            var res = false;
            string user = "John";
            string passWord = "Admin@123";
            string outcome = string.Empty;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                UserService.Setup(service => service.ChangePassword(user, passWord)).ReturnsAsync(outcome);
                var result = await _userServices.ChangePassword(user, passWord);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Add Date Detail using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Date_AddDateDetail()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                DateService.Setup(service => service.AddDateDetail(_dateDetails)).ReturnsAsync(res);
                var result = await _dateServices.AddDateDetail(_dateDetails);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Cancel Date Detail using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Date_CancelDateDetail()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                DateService.Setup(service => service.CancelDateDetail(_dateDetails)).ReturnsAsync(_dateDetails);
                var result = await _dateServices.CancelDateDetail(_dateDetails);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Get DateDetail By the dateId using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Date_GetDateDetailById()
        {
            //Arrange
            var res = false;
            long dateId = 89786;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                DateService.Setup(service => service.GetDateDetailById(dateId)).ReturnsAsync(_dateDetails);
                var result = await _dateServices.GetDateDetailById(dateId);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Get DateDetail By the user name using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Date_GetDateDetailByUser()
        {
            //Arrange
            var res = false;
            string requester = "John";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                DateService.Setup(service => service.GetDateDetailByUser(requester)).ReturnsAsync(_dateDetails);
                var result = await _dateServices.GetDateDetailByUser(requester);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// send new date Request using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Date_SendRequest()
        {
            //Arrange
            var res = false;
            string requester = "John";
            string testName; string status;
            string outCome = string.Empty;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                DateService.Setup(service => service.SendRequest(_dateDetails)).ReturnsAsync(outCome);
                var result = await _dateServices.SendRequest(_dateDetails);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Update DateDetail using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Date_UpdateDateDetail()
        {
            //Arrange
            var res = false;
            string requester = "John";
            string testName; string status;
            string outCome = string.Empty;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                DateService.Setup(service => service.UpdateDateDetail(_dateDetails)).ReturnsAsync(_dateDetails);
                var result = await _dateServices.UpdateDateDetail(_dateDetails);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary> 
        /// Change User Password using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Admin_ChangeUserPassword()
        {
            //Arrange
            var res = false;
            string testName; string status;
            string outCome = string.Empty;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                AdminService.Setup(service => service.ChangeUserPassword(_changePasswordViewModel)).ReturnsAsync(identiyResult);
                var result = await _adminServices.ChangeUserPassword(_changePasswordViewModel);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Create new Role using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Admin_CreateRole()
        {
            //Arrange
            var res = false;
            string testName; string status;
            string outCome = string.Empty;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                AdminService.Setup(service => service.CreateRole(_createRoleViewModel)).ReturnsAsync(identiyResult);
                var result = await _adminServices.CreateRole(_createRoleViewModel);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Disable any User using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Admin_DisableUser()
        {
            //Arrange
            var res = false;
            string userId = "32423";
            string testName; string status;
            string outCome = string.Empty;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                AdminService.Setup(service => service.DisableUser(userId)).ReturnsAsync(identiyResult);
                var result = await _adminServices.DisableUser(userId);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        /// Edit User Role using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Admin_EditRole()
        {
            //Arrange
            var res = false;
            string userId = "32423";
            string testName; string status;
            string outCome = string.Empty;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                AdminService.Setup(service => service.EditRole(_editRoleViewModel)).ReturnsAsync(identiyResult);
                var result = await _adminServices.EditRole(_editRoleViewModel);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        ///Edit Users In Role using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Admin_EditUsersInRole()
        {
            //Arrange
            var res = false;
            string roleId = "32423";
            string testName; string status;
            string outCome = string.Empty;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                AdminService.Setup(service => service.EditUsersInRole(_userRoleViewModel, roleId)).ReturnsAsync(identiyResult);
                var result = await _adminServices.EditUsersInRole(_userRoleViewModel, roleId);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        ///Enable any User using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Admin_EnableUser()
        {
            //Arrange
            var res = false;
            string userId = "32423";
            string testName; string status;
            string outCome = string.Empty;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                AdminService.Setup(service => service.EnableUser(userId)).ReturnsAsync(identiyResult);
                var result = await _adminServices.EnableUser(userId);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary> 
        ///Register User using this function testing below method or test case.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Admin_Register()
        {
            //Arrange
            var res = false;
            string password = "Admin@123";
            string testName; string status;
            string outCome = string.Empty;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                AdminService.Setup(service => service.Register(_userMaster, password)).ReturnsAsync(identiyResult);
                var result = await _adminServices.Register(_userMaster, password);

                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + " Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + " Passed");
            }
            else
            {
                _output.WriteLine(testName + " Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}