using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ClassLibrary1
{

    public class Rating : IComponent
    {
        private RenderHandle _renderHandle;

        void IComponent.Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }

        Task IComponent.SetParametersAsync(ParameterView parameters)
        {
            _renderHandle.Render(RenderDelegate);
            return Task.CompletedTask;
        }

        private void RenderDelegate(RenderTreeBuilder builder)
        {
            int max = Math.Min(4, 5);
            int seq = 1;
            for (var i = 0; i < max; i++)
            {
                builder.OpenElement(seq++, "span");
                builder.AddAttribute(seq++,
                          "style", "color:#f49813;font-size:30px");
                builder.AddContent(seq++, "★");
                builder.CloseElement();
            }
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            throw new NotImplementedException();
        }
    }

    public class Rating2 : IComponent
    {
        private RenderHandle _renderHandle;

        void IComponent.Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }

        Task IComponent.SetParametersAsync(ParameterView parameters)
        {
            _renderHandle.Render(RenderDelegate);
            return Task.CompletedTask;
        }

        private void RenderDelegate(RenderTreeBuilder builder)
        {
                builder.OpenElement(1, "span");
                builder.AddAttribute(60,
                          "style", "color:#f49813;font-size:30px");
                builder.AddContent(30, "★");
                builder.CloseElement();
        }

    }

}
