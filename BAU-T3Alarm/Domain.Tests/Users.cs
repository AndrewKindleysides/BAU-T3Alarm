using Xunit;

namespace Domain.Tests
{
    public class Users
    {
        [Fact]
        public void authentication_token_is_encoded_from_username_and_password()
        {
            var expected = new User
            {
                Username = "Username", 
                Password = "Password123"
            }.AuthenticationToken();
            Assert.Equal("VXNlcm5hbWU6UGFzc3dvcmQxMjM=", expected);
        }
    }
}
