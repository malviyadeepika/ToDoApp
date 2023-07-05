using CoreLogic.Services;

namespace CoreTest
{
    public class UserTests
    {
        private int count;
        [SetUp]
        public void Setup()
        {
            userService userservice=new userService();
            //var result=userservice.GetAll();
            //count=result.Count();
            
        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(count > 0);
        }
    }
}