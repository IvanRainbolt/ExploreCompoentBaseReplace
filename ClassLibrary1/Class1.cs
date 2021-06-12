using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ClassLibrary1
{

    public class Rating2 : IComponent
    {
        private RenderHandle _renderHandle;

        void IComponent.Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }

        Task IComponent.SetParametersAsync(ParameterView parameters)
        {
            //for this example, trigger the render here.
            _renderHandle.Render(RenderDelegate);
            return Task.CompletedTask;
        }

        private void RenderDelegate(RenderTreeBuilder builder)
        {
                builder.OpenElement(1, "span");
                builder.AddAttribute(2,
                          "style", "color:#f49813;font-size:30px");
                builder.AddContent(3, "★");
                builder.CloseElement();
        }

    }

}
