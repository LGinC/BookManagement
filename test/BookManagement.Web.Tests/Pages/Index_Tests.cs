using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace BookManagement.Pages
{
    public class Index_Tests : BookManagementWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
