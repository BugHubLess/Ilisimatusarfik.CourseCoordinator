using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ilisimatusarfik.CourseCoordinator.Tests.DB
{
    [TestClass()]
    public class TestSPEditCourse : SqlDatabaseTestClass
    {

        public TestSPEditCourse()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_SPEditCourseTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestSPEditCourse));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition ECTS;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition rowCount;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_SPEditCourseTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction testInitializeAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_SPEditCourseTest_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction testCleanupAction;
            this.dbo_SPEditCourseTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_SPEditCourseTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ECTS = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            rowCount = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            dbo_SPEditCourseTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            testInitializeAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_SPEditCourseTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            testCleanupAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // dbo_SPEditCourseTest_TestAction
            // 
            dbo_SPEditCourseTest_TestAction.Conditions.Add(ECTS);
            dbo_SPEditCourseTest_TestAction.Conditions.Add(rowCount);
            resources.ApplyResources(dbo_SPEditCourseTest_TestAction, "dbo_SPEditCourseTest_TestAction");
            // 
            // ECTS
            // 
            ECTS.ColumnNumber = 1;
            ECTS.Enabled = true;
            ECTS.ExpectedValue = "10";
            ECTS.Name = "ECTS";
            ECTS.NullExpected = false;
            ECTS.ResultSet = 1;
            ECTS.RowNumber = 1;
            // 
            // rowCount
            // 
            rowCount.ColumnNumber = 2;
            rowCount.Enabled = true;
            rowCount.ExpectedValue = "1";
            rowCount.Name = "rowCount";
            rowCount.NullExpected = false;
            rowCount.ResultSet = 1;
            rowCount.RowNumber = 1;
            // 
            // dbo_SPEditCourseTest_PretestAction
            // 
            resources.ApplyResources(dbo_SPEditCourseTest_PretestAction, "dbo_SPEditCourseTest_PretestAction");
            // 
            // testInitializeAction
            // 
            resources.ApplyResources(testInitializeAction, "testInitializeAction");
            // 
            // dbo_SPEditCourseTest_PosttestAction
            // 
            resources.ApplyResources(dbo_SPEditCourseTest_PosttestAction, "dbo_SPEditCourseTest_PosttestAction");
            // 
            // dbo_SPEditCourseTestData
            // 
            this.dbo_SPEditCourseTestData.PosttestAction = dbo_SPEditCourseTest_PosttestAction;
            this.dbo_SPEditCourseTestData.PretestAction = dbo_SPEditCourseTest_PretestAction;
            this.dbo_SPEditCourseTestData.TestAction = dbo_SPEditCourseTest_TestAction;
            // 
            // testCleanupAction
            // 
            resources.ApplyResources(testCleanupAction, "testCleanupAction");
            // 
            // TestSPEditCourse
            // 
            this.TestCleanupAction = testCleanupAction;
            this.TestInitializeAction = testInitializeAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void dbo_SPEditCourseTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_SPEditCourseTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        private SqlDatabaseTestActions dbo_SPEditCourseTestData;
    }
}
