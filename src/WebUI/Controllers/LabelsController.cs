using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using micro_api.Application.Labels.Commands.CreateLabel;

namespace micro_api.WebUI.Controllers
{
    public class LabelsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(CreateLabelCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
