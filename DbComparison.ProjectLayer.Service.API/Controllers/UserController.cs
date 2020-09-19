using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DbComparison.DataLayer.Base;
using DbComparison.ProjectLayer.Helper.Methods;
using DbComparison.ProjectLayer.Data.Common.Model;
using DbComparison.ProjectLayer.Business.Operation.Base;

namespace DbComparison.ProjectLayer.Service.API.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        IUserOperation _userOperation;
        TimeMeasurement _timeMeasurement;

        public UserController(IUserOperation userOperation)
        {
            _userOperation = userOperation;
            _timeMeasurement = new TimeMeasurement();
        }

        [Route("user")]
        [HttpPost]
        public IActionResult NewUser([FromBody] User user)
        {
            #region InsertingOnSqlServer
            _timeMeasurement.StartWatch();

            _userOperation.InsertUser(user, DbType.SqlServer);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnSqlServer = _timeMeasurement.PrintTimeSpent();
            #endregion

            _timeMeasurement.ResetWatch();

            #region InsertingOnMongoDB
            _timeMeasurement.StartWatch();

            _userOperation.InsertUser(user, DbType.MongoDB);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnMongoDB = _timeMeasurement.PrintTimeSpent();
            #endregion

            return Json(new { elapsed_Time_On_SQL_Server = spentTimeOnSqlServer.ToString(), elapsed_Time_On_MongoDB = spentTimeOnMongoDB.ToString() });
        }

        [Route("user")]
        [HttpPost]
        public IActionResult NewUsers([FromBody] List<User> userList)
        {
            #region InsertingOnSqlServer
            _timeMeasurement.StartWatch();

            _userOperation.InsertUsers(userList, DbType.SqlServer);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnSqlServer = _timeMeasurement.PrintTimeSpent();
            #endregion

            _timeMeasurement.ResetWatch();

            #region InsertingOnMongoDB
            _timeMeasurement.StartWatch();

            _userOperation.InsertUsers(userList, DbType.MongoDB);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnMongoDB = _timeMeasurement.PrintTimeSpent();
            #endregion

            return Json(new { elapsed_Time_On_SQL_Server = spentTimeOnSqlServer.ToString(), elapsed_Time_On_MongoDB = spentTimeOnMongoDB.ToString() });
        }

        [Route("user/{id}")]
        [HttpGet]
        public IActionResult UserInfo([FromRoute] string id)
        {
            #region FindingOnSqlServer
            _timeMeasurement.StartWatch();

            _userOperation.GetSingleUser(id, DbType.SqlServer);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnSqlServer = _timeMeasurement.PrintTimeSpent();
            #endregion

            _timeMeasurement.ResetWatch();

            #region FindingOnMongoDB
            _timeMeasurement.StartWatch();

            _userOperation.GetSingleUser(id, DbType.MongoDB);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnMongoDB = _timeMeasurement.PrintTimeSpent(); 
            #endregion

            return Json(new { elapsed_Time_On_SQL_Server = spentTimeOnSqlServer.ToString(), elapsed_Time_On_MongoDB = spentTimeOnMongoDB.ToString() });
        }

        [Route("user")]
        [HttpGet]
        public IActionResult UsersInfo()
        {
            #region FindingOnSqlServer
            _timeMeasurement.StartWatch();

            _userOperation.GetAllUsers(DbType.SqlServer);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnSqlServer = _timeMeasurement.PrintTimeSpent();
            #endregion

            _timeMeasurement.ResetWatch();

            #region FindingOnMongoDB
            _timeMeasurement.StartWatch();

            _userOperation.GetAllUsers(DbType.MongoDB);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnMongoDB = _timeMeasurement.PrintTimeSpent();
            #endregion

            return Json(new { elapsed_Time_On_SQL_Server = spentTimeOnSqlServer.ToString(), elapsed_Time_On_MongoDB = spentTimeOnMongoDB.ToString() });
        }

        [Route("user")]
        [HttpPut]
        public IActionResult ExistingUser([FromBody] User user)
        {
            #region UpdatingOnSqlServer
            _timeMeasurement.StartWatch();

            _userOperation.UpdateUser(user, DbType.SqlServer);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnSqlServer = _timeMeasurement.PrintTimeSpent(); 
            #endregion

            _timeMeasurement.ResetWatch();

            #region UpdatingOnMongoDB
            _timeMeasurement.StartWatch();

            _userOperation.UpdateUser(user, DbType.MongoDB);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnMongoDB = _timeMeasurement.PrintTimeSpent();
            #endregion

            return Json(new { elapsed_Time_On_SQL_Server = spentTimeOnSqlServer.ToString(), elapsed_Time_On_MongoDB = spentTimeOnMongoDB.ToString() });
        }

        [Route("user/{id}")]
        [HttpDelete]
        public IActionResult PreviousUser([FromRoute] string id)
        {
            #region DeletingOnSqlServer
            _timeMeasurement.StartWatch();

            _userOperation.DeleteUser(id, DbType.SqlServer);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnSqlServer = _timeMeasurement.PrintTimeSpent();
            #endregion

            _timeMeasurement.ResetWatch();

            #region DeletingOnMongoDB
            _timeMeasurement.StartWatch();

            _userOperation.DeleteUser(id, DbType.MongoDB);

            _timeMeasurement.StopWatch();

            TimeSpan spentTimeOnMongoDB = _timeMeasurement.PrintTimeSpent();
            #endregion

            return Json(new { elapsed_Time_On_SQL_Server = spentTimeOnSqlServer.ToString(), elapsed_Time_On_MongoDB = spentTimeOnMongoDB.ToString() });
        }
    }
}