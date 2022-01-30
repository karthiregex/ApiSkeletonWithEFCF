
using DatingApp.BusinessLayer.Interfaces;
using DatingApp.BusinessLayer.Services;
using DatingApp.BusinessLayer.Services.Repository;
using Moq;
using System;
using System.Threading.Tasks;
using DatingApp.BusinessLayer.ViewModels;
using DatingApp.Entities;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DatingApp.Tests.TestCases
{
    public class ExceptionalTest
    {
        /// <summary>
        /// Creating Reference Variable and Mocking repository class
        /// </summary>

        private readonly IAdminServices _adminServices;
        private readonly IDateService _dateServices;
        private readonly IUserService _userServices;

        public readonly Mock<IAdminRepository> AdminService = new Mock<IAdminRepository>();
        public readonly Mock<IDateRepository> DateService = new Mock<IDateRepository>();
        public readonly Mock<IUserRepository> UserService = new Mock<IUserRepository>();

        private UserMaster _userMaster;
        private DateDetail _dateDetails;
        private User _user;
        private Profile _profile;

        private CreateRoleViewModel _createRoleViewModel;
        private UserRoleViewModel _userRoleViewModel;
        private ChangePasswordViewModel _changePasswordViewModel;
        private EditRoleViewModel _editRoleViewModel;

        private readonly ITestOutputHelper _output;
        private static readonly string type = "Exceptional";
        private IdentityResult identiyResult;
        public ExceptionalTest(ITestOutputHelper output)
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
                Email = "karthiregex@gmail.com"
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
        /// Test to validate if RoleViewModel pass as null object while create new Role, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_InvalidRole()
        {
            //Arrange
            bool res = false;
            _createRoleViewModel = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                //Act
                AdminService.Setup(service => service.CreateRole(_createRoleViewModel)).ReturnsAsync(identiyResult = null);
                var result = await _adminServices.CreateRole(_createRoleViewModel);
                if (result == null)
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
        /// Test to validate if User Password passed as null object while change password, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_InvalidUserPassword()
        {
            //Arrange
            bool res = false;
            _changePasswordViewModel = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                //Act
                AdminService.Setup(service => service.ChangeUserPassword(_changePasswordViewModel)).ReturnsAsync(identiyResult = null);
                var result = await _adminServices.ChangeUserPassword(_changePasswordViewModel);
                if (result == null)
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
        /// Test to validate if UserId passed as null object while deactivate user, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_InvalidUserId()
        {
            //Arrange
            bool res = false;
            string userId = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                //Act
                AdminService.Setup(service => service.DisableUser(userId)).ReturnsAsync(identiyResult = null);
                var result = await _adminServices.DisableUser(userId);
                if (result == null)
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
        /// Test to validate if _editRoleViewModel passed as null object while Edit role, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_editRoleViewModel()
        {
            //Arrange
            bool res = false;
            _editRoleViewModel = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                //Act
                AdminService.Setup(service => service.EditRole(_editRoleViewModel)).ReturnsAsync(identiyResult = null);
                var result = await _adminServices.EditRole(_editRoleViewModel);
                if (result == null)
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
        /// Test to validate if EditUsersInRole passed as null object while Edit role, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_EditUsersInRole()
        {
            //Arrange
            bool res = false;
            _editRoleViewModel = null;
            string roleId = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                //Act
                AdminService.Setup(service => service.EditUsersInRole(_userRoleViewModel, roleId)).ReturnsAsync(identiyResult = null);
                var result = await _adminServices.EditUsersInRole(_userRoleViewModel, roleId);
                if (result == null)
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
        /// Test to validate if userId passed as null object while enable user, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_EnableUser()
        {
            //Arrange
            bool res = false;
            _editRoleViewModel = null;
            string userId = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                //Act
                AdminService.Setup(service => service.EnableUser(userId)).ReturnsAsync(identiyResult = null);
                var result = await _adminServices.EnableUser(userId);
                if (result == null)
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
        /// Test to validate if email passed as null object while Find user ByEmail, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_Email()
        {
            //Arrange
            bool res = false;
            _editRoleViewModel = null;
            string email = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                //Act
                AdminService.Setup(service => service.FindByEmailAsync(email)).ReturnsAsync(_userMaster = null);
                var result = await _adminServices.FindByEmailAsync(email);
                if (result == null)
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
        /// Test to validate if DateDetails passed as null object while add DateDetails, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_InvalidDateDetails()
        {
            //Arrange
            bool res = false;
            _dateDetails = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(service => service.AddDateDetail(_dateDetails)).ReturnsAsync(res);
                var result = await _dateServices.AddDateDetail(_dateDetails);
                if (result == null)
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
        /// Test to validate if DateDetails passed as null object while add CancelDateDetail, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_cancelDateDetails()
        {
            //Arrange
            bool res = false;
            _dateDetails = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(service => service.CancelDateDetail(_dateDetails)).ReturnsAsync(_dateDetails = null);
                var result = await _dateServices.CancelDateDetail(_dateDetails);
                if (result == null)
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
        /// Test to validate if sender passed as null object while get DateDetailByUser, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_DateDetailByUser()
        {
            //Arrange
            bool res = false;
            string sender = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(service => service.GetDateDetailByUser(sender)).ReturnsAsync(_dateDetails = null);
                var result = await _dateServices.GetDateDetailByUser(sender);
                if (result == null)
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
        /// Test to validate if _dateDetails passed as null object while Send Request, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_SendRequest()
        {
            //Arrange
            bool res = false;
            _dateDetails = null;
            string outcome = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(service => service.SendRequest(_dateDetails)).ReturnsAsync(outcome);
                var result = await _dateServices.SendRequest(_dateDetails);
                if (result == null)
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
        /// Test to validate if _dateDetails passed as null object while Update DateDetail, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_UpdateDateDetail()
        {
            //Arrange
            bool res = false;
            _dateDetails = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(service => service.UpdateDateDetail(_dateDetails)).ReturnsAsync(_dateDetails = null);
                var result = await _dateServices.UpdateDateDetail(_dateDetails);
                if (result == null)
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
        /// Test to validate if _profile passed as null object while Add Profile, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_AddProfile()
        {
            //Arrange
            bool res = false;
            _profile = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(service => service.AddProfile(_profile)).ReturnsAsync(res);
                var result = await _userServices.AddProfile(_profile);
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
        /// Test to validate if username and password passed as null object while Change Password, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_ChangePassword()
        {
            //Arrange
            bool res = false;
            string username = null;
            string password = null;
            string outCome = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(service => service.ChangePassword(username, password)).ReturnsAsync(outCome);
                var result = await _userServices.ChangePassword(username, password);
                if (result == null)
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
        /// Test to validate if _profile passed as null object while Create NewUser, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_CreateNewUser()
        {
            //Arrange
            bool res = false;
            _user = null;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(service => service.CreateNewUser(_user)).ReturnsAsync(res);
                var result = await _userServices.CreateNewUser(_user);
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
        /// Test to validate if username and password passed as null object while Change Password, return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Invalid_VerifyUser()
        {
            //Arrange
            bool res = false;
            string username = null;
            string password = null;

            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(service => service.VerifyUser(username, password)).ReturnsAsync(_user = null);
                var result = await _userServices.VerifyUser(username, password);
                if (result == null)
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
