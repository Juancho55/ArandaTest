using Microsoft.AspNetCore.Mvc;

namespace ArandaTest.Result
{
    public class CreateResult : IActionResult
    {
        private readonly CreateContent _content = new CreateContent();

        public CreateResult(object data)
        {
            _content.data = data;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_content.data)
            {
                StatusCode = StatusCodes.Status201Created
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }

    public class CreateContent
    {
        public object data { get; set; }
    }
}