module Fhash


type HashApp() =

  let mutable _renderHandle = ()

  interface Microsoft.AspNetCore.Components.IComponent with
    member this.Attach renderHandle = 
      _renderHandle <- renderHandle



open System.Threading.Tasks
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Rendering

//type Rating() =
//    let mutable _renderHandle = Unchecked.defaultof<RenderHandle>
//    member val Value: int = Unchecked.defaultof<int> with get, set


//    member this.Attach(renderHandle: RenderHandle) = _renderHandle <- renderHandle


//    member this.SetParametersAsync(parameters: ParameterView): Task =
//        for entry in parameters do
//            ``Not supported: switch (entry.Name)
//                {
//                    case nameof(Value):
//                        Value = (int)entry.Value;
//                        break;
//                } Line:16, Col:0``

//        _renderHandle.Render(this.RenderDelegate)
//        Task.CompletedTask


//    member private this.RenderDelegate(builder: RenderTreeBuilder) =
//        let mutable max = Math.Min(Value, 5)
//        let mutable seq = 1
//        for i = 0 to (max - 1) do
//            builder.OpenElement(seq <- seq + 1, "span")
//            builder.AddAttribute(seq <- seq + 1, "style", "color:#f49813;font-size:30px")
//            builder.AddContent(seq <- seq + 1, "★")
//            builder.CloseElement()

//    interface IComponent with

//        member this.Todo() = ()


type MyAddingService() =

    interface IAddingService with
        member this.Add x y =
            x + y

    interface System.IDisposable with
        member this.Dispose() =
            printfn "disposed"