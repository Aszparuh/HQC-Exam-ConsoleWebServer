using ConsoleWebServer.Framework.ActionResults.Contracts;

namespace ConsoleWebServer.Framework
{
    internal class NewActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }
    }
}
