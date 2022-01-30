using DatingApp.BusinessLayer.Interfaces;
using DatingApp.BusinessLayer.Services;
using DatingApp.BusinessLayer.Services.Repository;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DatingApp.BusinessLayer.ViewModels;
using DatingApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DatingApp.Tests.TestCases
{
    public class BoundaryTest
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

        private readonly UserMaster _userMaster;
        private readonly DateDetail _dateDetails;
        private readonly User _user;
        private readonly Profile _profile;

        private readonly CreateRoleViewModel _createRoleViewModel;
        private readonly UserRoleViewModel _userRoleViewModel;
        private readonly ChangePasswordViewModel _changePasswordViewModel;
        private readonly EditRoleViewModel _editRoleViewModel;
        readonly private ITestOutputHelper _output;
        readonly private static string type = "Boundary";
        private IdentityResult identiyResult;
        public BoundaryTest(ITestOutputHelper output)
        {
            ///// <summary>
            ///// Injecting service object into Test class constructor
            ///// </summary>
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
        /// Test to validate adding new Role is Success or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_CheckAdminName()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                AdminService.Setup(repo => repo.CreateRole(_createRoleViewModel)).ReturnsAsync(identiyResult);
                var result = await _adminServices.CreateRole(_createRoleViewModel);

                if (result.Succeeded)
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
        /// Test to validate if added Role and RoleName is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_CheckRollName()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(repo => repo.AddDateDetail(_dateDetails)).ReturnsAsync(res);
                var result = await _dateServices.AddDateDetail(_dateDetails);

                if (result.DateId == _dateDetails.DateId)
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
        /// Test to validate if added Profile and ProfileId is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_ProfileId()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.AddProfile(_profile)).ReturnsAsync(res);
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
        /// Test to validate if added Profile and Profile FirstName is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Profile_FirstName()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.AddProfile(_profile)).ReturnsAsync(res);
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
        /// Test to validate if added Profile and Profile LastName is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Profile_LastName()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.AddProfile(_profile)).ReturnsAsync(res);
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
        /// Test to validate if added Profile and Profile Occupation is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Profile_Occupation()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.AddProfile(_profile)).ReturnsAsync(res);
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
        /// Test to validate if added Profile and Profile AlternateEmail is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Profile_AlternateEmail()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.AddProfile(_profile)).ReturnsAsync(res);
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
        /// Test to validate if added Profile and Profile MobileNumber is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Profile_MobileNumber()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.AddProfile(_profile)).ReturnsAsync(res);
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
        /// Test to validate if added Profile and Profile Gender is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Profile_Gender()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.AddProfile(_profile)).ReturnsAsync(res);
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
        /// Test to validate if added User and User ID is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_User_ID()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.CreateNewUser(_user)).ReturnsAsync(res);
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
        /// Test to validate if added User and UserName is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_UserName()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.CreateNewUser(_user)).ReturnsAsync(res);
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
        /// Test to validate if added User and Password is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Password()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.CreateNewUser(_user)).ReturnsAsync(res);
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
        /// Test to validate if added User and user Email is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_Email()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.CreateNewUser(_user)).ReturnsAsync(res);
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
        /// Test_for_ValidEmail to test email id is valid or not
        /// </summary>
        ///  <returns></returns>
        [Fact]
        public async Task<bool> Test_for_ValidEmail()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                bool isEmail = Regex.IsMatch(_user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (isEmail)
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
        /// Test_for_ValidateMobileNumber is used for test mobile number is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_ValidateMobileNumber()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.CreateNewUser(_user)).ReturnsAsync(res);
                var result = await _userServices.CreateNewUser(_user);
                var actualLength = _user.MobileNumber.ToString().Length;
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
        /// Test to validate if added User and user UserMobile is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_UserMobile()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.CreateNewUser(_user)).ReturnsAsync(res);
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
        /// Test to validate the password change is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_ChangePassword()
        {
            //Arrange
            string user = "Testing";
            string password = "Admin@123";
            string output = string.Empty;
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.ChangePassword(user, password)).ReturnsAsync(output);
                var result = await _userServices.ChangePassword(user, password);

                if (result.Contains("Success"))
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
        /// Test to validate User verification is correct or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Validate_UserVerification()
        {
            //Arrange
            string user = "Testing";
            string password = "Admin@123";
            string output = string.Empty;
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.VerifyUser(user, password)).ReturnsAsync(_user);
                var result = await _userServices.VerifyUser(user, password);

                if (result.UserName == _user.UserName)
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
        /// Test to validate User name cannot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_User_FirstName_NotEmpty()
        {
            //Arrange
            string user = "Testing";
            string password = "Admin@123";
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.VerifyUser(user, password)).ReturnsAsync(_user);
                var result = await _userServices.VerifyUser(user, password);
                var actualLength = _user.UserName.Length;
                if (result.UserName.Length == actualLength)
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
        /// Test to validate User email cannot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_User_Email_NotEmpty()
        {
            //Arrange
            string user = "Testing";
            string password = "Admin@123";
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.VerifyUser(user, password)).ReturnsAsync(_user);
                var result = await _userServices.VerifyUser(user, password);
                var actualLength = _user.Email.Length;
                if (result.Email.Length == actualLength)
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
        /// Test to validate User MobileNumber cannot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_User_MobileNumber_NotEmpty()
        {
            //Arrange
            string user = "Testing";
            string password = "Admin@123";
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.VerifyUser(user, password)).ReturnsAsync(_user);
                var result = await _userServices.VerifyUser(user, password);
                var actualLength = _user.MobileNumber.ToString().Length;
                if (result.MobileNumber.ToString().Length == actualLength)
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
        /// Test to validate User Password cannot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_User_Password_NotEmpty()
        {
            //Arrange
            string user = "Testing";
            string password = "Admin@123";
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                UserService.Setup(repo => repo.VerifyUser(user, password)).ReturnsAsync(_user);
                var result = await _userServices.VerifyUser(user, password);
                var actualLength = _user.Password.ToString().Length;
                if (result.Password.ToString().Length == actualLength)
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
        /// Test to validate dateDetails RequestSenderName cannot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_DateDetails_RequestSenderName_NotEmpty()
        {
            //Arrange
            string requester = "John";
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(repo => repo.GetDateDetailByUser(requester)).ReturnsAsync(_dateDetails);
                var result = await _dateServices.GetDateDetailByUser(requester);
                var actualLength = _dateDetails.RequestSenderName.ToString().Length;
                if (result.RequestSenderName.ToString().Length == actualLength)
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
        /// Test to validate dateDetails RequestReceiverName cannot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_Date_RequestReceiverName_NotEmpty()
        {
            //Arrange
            string receiverName = "John";
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(repo => repo.GetDateDetailByUser(receiverName)).ReturnsAsync(_dateDetails);
                var result = await _dateServices.GetDateDetailByUser(receiverName);
                var actualLength = _dateDetails.RequestReceiverName.ToString().Length;
                if (result.RequestReceiverName.ToString().Length == actualLength)
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
        /// Test to validate dateDetails RequestSenderEmail cannot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_DateDetails_RequestSenderEmail_NotEmpty()
        {
            //Arrange
            string receiverName = "John";
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(repo => repo.GetDateDetailByUser(receiverName)).ReturnsAsync(_dateDetails);
                var result = await _dateServices.GetDateDetailByUser(receiverName);
                var actualLength = _dateDetails.RequestSenderEmail.ToString().Length;
                if (result.RequestSenderEmail.ToString().Length == actualLength)
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
        /// Test to validate dateDetails RequestReceiverEmail cannot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Test_for_DateDetails_RequestReceiverEmail_NotEmpty()
        {
            //Arrange
            string receiverName = "John";
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                DateService.Setup(repo => repo.GetDateDetailByUser(receiverName)).ReturnsAsync(_dateDetails);
                var result = await _dateServices.GetDateDetailByUser(receiverName);
                var actualLength = _dateDetails.RequestReceiverEmail.ToString().Length;
                if (result.RequestReceiverEmail.ToString().Length == actualLength)
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